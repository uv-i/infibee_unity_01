using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaCoreLoopFramework
{
    // Renamed to Answer_Practice to avoid the GitHub duplicate conflict!
    public class Answer_Practice : MonoBehaviour
    {
        [Header("UI Component References")]
        [SerializeField] private Button buttonComponent;
        [SerializeField] private TMP_Text answerTextDisplay;

        public bool IsCorrect { get; private set; }

        public void OnInit(bool isCorrect, string answerText)
        {
            this.IsCorrect = isCorrect;

            if (answerTextDisplay != null)
            {
                answerTextDisplay.text = answerText;
            }

            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners();
                buttonComponent.onClick.AddListener(HandleButtonClick);
            }
        }

        private void HandleButtonClick()
        {
            if (TriviaGameManager.Instance != null)
            {
                TriviaGameManager.Instance.OnAnswerSelected(IsCorrect);
            }

            Debug.Log($"[Practice Answer Button] Clicked! Choice: '{answerTextDisplay.text}'");
        }
    }
}