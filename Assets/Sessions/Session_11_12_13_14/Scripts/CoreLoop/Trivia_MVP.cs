using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TriviaCoreLoopFramework
{
    public class Trivia_MVP : MonoBehaviour
    {
        static Trivia_MVP instance;
        public static Trivia_MVP Instance;

        public QuestionSO questionSO;
        public GameObject questionTextObj, feedbackTextObj, answerPanelObj, answerPrefab;
        public TMP_Text questionTextTMP;

        string questionText;

        int currentQuestion = 0;

        private void Awake ( )
        {
            if ( instance == null )
                instance = this;
            else
            {
                if(instance != this )
                    Destroy ( this.gameObject );
                DontDestroyOnLoad ( this );
            }
            Instance = instance;
        }

        void Start ( )
        {
            OnLoad ( );
        }
        void OnLoad ( )
        {
            foreach ( var item in questionSO.QuestionData [ currentQuestion ].answers )
            {
                GameObject go = Instantiate ( answerPrefab );
                go.transform.SetParent ( answerPanelObj.transform, false );
                go.GetComponent<Answer> ( ).OnInit ( item.isCorrect, item.answer );
            }

            questionText = questionSO.QuestionData [ currentQuestion ].question;
            questionTextTMP.text = questionText;

            OnInit ( );
        }

        void OnInit ( )
        {
            answerPanelObj.SetActive ( true );
            questionTextObj.SetActive ( true );

            feedbackTextObj.SetActive ( false );
        }

        void OnCompleteQuestion ( )
        {
            for ( int i = 0; i < answerPanelObj.transform.childCount; i++ )
            {
                Destroy ( answerPanelObj.transform.GetChild ( i ).gameObject );
            }
            
            currentQuestion++;
            if ( currentQuestion < questionSO.QuestionData.Count )
            {
                OnLoad ( );
                return;
            }

            feedbackTextObj.GetComponent<TMP_Text>().text = "CONGRATS ! ! !";
            feedbackTextObj.SetActive ( true );
            return;
        }

        public void OnAnswered ( bool isCorrect )
        {
            if ( isCorrect )
                StartCoroutine ( OnCorrectAnswer ( ) );
            else
                StartCoroutine ( OnWrongAnswer ( ) );
        }

        IEnumerator OnCorrectAnswer ( ) 
        {
            answerPanelObj.SetActive ( false );
            questionTextObj.SetActive ( false );
            feedbackTextObj.SetActive ( true );
            yield return new WaitForSeconds ( 1.0f );
            OnCompleteQuestion ( );
        }

        IEnumerator OnWrongAnswer ( )
        {
            questionTextTMP.text = "OOPS :( Please Try Again !!! ";
            answerPanelObj.SetActive ( false );
            yield return new WaitForSeconds ( 1.0f );
            questionTextTMP.text = questionText;
            answerPanelObj.SetActive ( true );
        }
    }
}