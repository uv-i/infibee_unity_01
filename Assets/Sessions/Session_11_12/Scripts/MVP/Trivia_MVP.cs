using System.Collections;
using TMPro;
using UnityEngine;

namespace TriviaMVP
{
    public class Trivia_MVP : MonoBehaviour
    {
        public GameObject questionTextObj, feedbackTextObj, answerPanelObj;
        public TMP_Text questionTextTMP;

        string questionText;

        void Start ( )
        {
            OnInit ( );
        }

        void OnInit ( )
        {
            questionText = questionTextTMP.text;

            answerPanelObj.SetActive ( true );
            questionTextObj.SetActive ( true );

            feedbackTextObj.SetActive ( false );
        }

        public void OnAnswered ( bool isCorrect )
        {
            if ( isCorrect )
            {
                answerPanelObj.SetActive ( false );
                questionTextObj.SetActive ( false );

                feedbackTextObj.SetActive ( true );
            }
            else
                StartCoroutine ( OnWrongAnswer ( ) );
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