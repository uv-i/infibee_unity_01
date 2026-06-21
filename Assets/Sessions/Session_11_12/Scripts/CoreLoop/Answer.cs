using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    }
}
