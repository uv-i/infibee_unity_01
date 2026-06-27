using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaCoreLoopFramework
{
    public class TriviaGameManager : MonoBehaviour
    {
        // Singleton Instance for global access
        public static TriviaGameManager Instance { get; private set; }

        [Header("Data Configuration")]
        [Tooltip("The ScriptableObject holding all the trivia questions.")]
        [SerializeField] private QuestionSO questionDatabase;

        [Header("UI Text Components")]
        [SerializeField] private TMP_Text questionTextDisplay;
        [SerializeField] private TMP_Text feedbackTextDisplay;
        [SerializeField] private TMP_Text scoreTextDisplay;

        [Header("UI Panel Components")]
        [SerializeField] private GameObject questionPanel;
        [SerializeField] private GameObject answerContainerPanel;
        [SerializeField] private GameObject feedbackPanel;

        [Header("Prefabs")]
        [Tooltip("The button prefab that has the 'Answer' script attached.")]
        [SerializeField] private GameObject answerButtonPrefab;

        [Header("Game Settings")]
        [SerializeField] private float feedbackDelayDuration = 1.5f;

        // Internal Game State Variables
        private int currentQuestionIndex = 0;
        private int playerScore = 0;
        private string cachedQuestionText;
        private bool isProcessingAnswer = false;

        private void Awake()
        {
            Debug.Log("[Game Manager] Awake running...");
            // Establish Singleton Pattern and safeguard against duplicates
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("[Game Manager] Singleton successfully established.");
            }
            else
            {
                Debug.LogWarning("[Game Manager] Duplicate Manager detected! Self-destructing.");
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            InitializeGame();
        }

        /// <summary>
        /// Resets game variables and loads the very first question.
        /// </summary>
        public void InitializeGame()
        {
            Debug.Log("[Game Manager] Initializing Game State...");
            playerScore = 0;
            currentQuestionIndex = 0;
            isProcessingAnswer = false;

            UpdateScoreUI();
            LoadQuestion(currentQuestionIndex);
        }

        /// <summary>
        /// Pulls question data from the ScriptableObject and populates the UI.
        /// </summary>
        private void LoadQuestion(int index)
        {
            Debug.Log($"[Game Manager] Attempting to load question at index: {index}");

            // Safety check: Ensure database has questions and index is valid
            if (questionDatabase == null)
            {
                Debug.LogError("[Game Manager] CRITICAL: Question Database field is completely EMPTY in the Inspector!");
                return;
            }

            if (questionDatabase.QuestionData == null || questionDatabase.QuestionData.Count == 0)
            {
                Debug.LogError("[Game Manager] CRITICAL: Database file found, but its QuestionData list is EMPTY! No questions exist.");
                return;
            }

            // Clean up any remaining answer buttons from the previous question
            ClearAnswerContainer();

            // Fetch current question data
            var currentQuestionData = questionDatabase.QuestionData[index];
            cachedQuestionText = currentQuestionData.question;

            if (questionTextDisplay != null)
            {
                questionTextDisplay.text = cachedQuestionText;
                Debug.Log($"[Game Manager] Set Question UI Text to: \"{cachedQuestionText}\"");
            }
            else
            {
                Debug.LogError("[Game Manager] ERROR: 'Question Text Display' variable is missing in Inspector!");
            }

            if (answerButtonPrefab == null)
            {
                Debug.LogError("[Game Manager] CRITICAL: 'Answer Button Prefab' field is EMPTY in the Inspector! Cannot spawn options.");
                return;
            }

            Debug.Log($"[Game Manager] Found {currentQuestionData.answers.Count} choices for this question. Spawning buttons...");

            // Dynamically build and instantiate answer buttons
            foreach (var answerItem in currentQuestionData.answers)
            {
                Debug.Log($"[Game Manager] Spawning button for string: '{answerItem.answer}' | Secret Correct Identity: {answerItem.isCorrect}");

                GameObject spawnedButton = Instantiate(answerButtonPrefab, answerContainerPanel.transform, false);

                // Set up the Answer component on the spawned prefab
                Answer_Practice answerComponent = spawnedButton.GetComponent<Answer_Practice>();
                if (answerComponent != null)
                {
                    answerComponent.OnInit(answerItem.isCorrect, answerItem.answer);
                }
                else
                {
                    Debug.LogError("[Game Manager] CRITICAL DETECTED: The Answer Button Prefab was successfully spawned, but it does NOT have your 'Answer' script attached to its inspector components! Fix your prefab file.");
                }
            }

            // Set default visibility states for UI elements
            SetUIVisibility(showGameplay: true, showFeedback: false);
        }

        /// <summary>
        /// This is the entry point called globally when a player clicks an answer button.
        /// </summary>
        public void OnAnswerSelected(bool isCorrect)
        {
            Debug.Log($"[Game Manager] OnAnswerSelected caught! Player chose a choice that is: {isCorrect}");

            // Prevent multiple rapid clicks while the feedback delay is active
            if (isProcessingAnswer)
            {
                Debug.LogWarning("[Game Manager] Input ignored. Already processing another option sequence.");
                return;
            }

            if (isCorrect)
            {
                StartCoroutine(HandleCorrectAnswerSequence());
            }
            else
            {
                StartCoroutine(HandleWrongAnswerSequence());
            }
        }

        private IEnumerator HandleCorrectAnswerSequence()
        {
            isProcessingAnswer = true;
            playerScore += 10; // Award points
            UpdateScoreUI();

            Debug.Log($"[Game Manager] Playing Correct Sequence. New Score: {playerScore}");

            if (feedbackTextDisplay != null) feedbackTextDisplay.text = "CORRECT!";
            SetUIVisibility(showGameplay: false, showFeedback: true);

            yield return new WaitForSeconds(feedbackDelayDuration);

            AdvanceToNextQuestion();
        }

        private IEnumerator HandleWrongAnswerSequence()
        {
            isProcessingAnswer = true;
            Debug.Log("[Game Manager] Playing Wrong Sequence. Prompting try-again behavior.");

            if (questionTextDisplay != null) questionTextDisplay.text = "INCORRECT! Try this question again.";
            if (answerContainerPanel != null) answerContainerPanel.SetActive(false); // Disable choices temporarily

            yield return new WaitForSeconds(feedbackDelayDuration);

            // Reset the layout to let them try the same question again
            if (questionTextDisplay != null) questionTextDisplay.text = cachedQuestionText;
            if (answerContainerPanel != null) answerContainerPanel.SetActive(true);
            isProcessingAnswer = false;
            Debug.Log("[Game Manager] Layout reset. Player can click again.");
        }

        private void AdvanceToNextQuestion()
        {
            currentQuestionIndex++;
            isProcessingAnswer = false;

            // Check if there are more questions remaining
            if (currentQuestionIndex < questionDatabase.QuestionData.Count)
            {
                LoadQuestion(currentQuestionIndex);
            }
            else
            {
                HandleGameCompletion();
            }
        }

        private void HandleGameCompletion()
        {
            Debug.Log("[Game Manager] All questions cleared! Showing Win/Completion Layout.");
            ClearAnswerContainer();
            if (questionTextDisplay != null) questionTextDisplay.text = "GAME OVER";
            if (feedbackTextDisplay != null) feedbackTextDisplay.text = $"CONGRATULATIONS!\nFinal Score: {playerScore}";
            SetUIVisibility(showGameplay: true, showFeedback: true);
            if (answerContainerPanel != null) answerContainerPanel.SetActive(false);
        }

        private void ClearAnswerContainer()
        {
            if (answerContainerPanel == null) return;

            Debug.Log($"[Game Manager] Clearing out old buttons. Found {answerContainerPanel.transform.childCount} active nodes.");
            foreach (Transform child in answerContainerPanel.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void UpdateScoreUI()
        {
            if (scoreTextDisplay != null)
            {
                scoreTextDisplay.text = $"Score: {playerScore}";
            }
        }

        private void SetUIVisibility(bool showGameplay, bool showFeedback)
        {
            if (questionPanel != null) questionPanel.SetActive(showGameplay);
            if (answerContainerPanel != null) answerContainerPanel.SetActive(showGameplay);
            if (feedbackPanel != null) feedbackPanel.SetActive(showFeedback);
        }
    }
}