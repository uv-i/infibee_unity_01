using System.Collections;
using TMPro;
using UnityEngine;

namespace TriviaCoreLoop
{
    public class Trivia_MVP : MonoBehaviour
    {
        public AnswerSO answerS0;
        public GameObject questionTextObj, feedbackTextObj, answerPanelObj, answerPrefab;
        public TMP_Text questionTextTMP;

        string questionText;

        void Start ( )
        {
            OnInit ( );
        }

        void OnInit ( )
        {
            foreach ( var item in answerS0.AnswerData )
            {
                GameObject go = Instantiate ( answerPrefab );
                go.transform.SetParent ( answerPanelObj.transform, false );
                go.GetComponent<Answer>().OnInit ( item.isCorrect, item.answer );
            }

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