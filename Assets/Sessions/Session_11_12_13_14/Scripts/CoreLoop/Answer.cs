using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaCoreLoopFramework
{
    public class Answer : MonoBehaviour
    {
        public bool IsCorrect;
        public Button button;
        public TMP_Text text;

        public void OnInit ( bool IsCorrect, string answerText )
        {
            this.IsCorrect = IsCorrect;

            button.onClick.RemoveAllListeners ( );
            button.onClick.AddListener ( OnClickButton );
            text.text = answerText;
        }

        void OnClickButton ( )
        {
            Trivia_MVP.Instance.OnAnswered ( IsCorrect );
            Debug.Log ( $"Player answered {IsCorrect}" );
        }
    }
}