using Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseCard : MonoBehaviour
{
    [SerializeField] Image border;
    [SerializeField] Image image;
    [SerializeField] TMP_Text text;

    string Name;
    Color Color;
    Sprite Sprite;
    CardType Type;

    public void OnSpawn ( string Name, Color Color, Sprite Sprite, CardType Type, Transform parent )
    {
        this.Name = Name;
        this.Color = Color;
        this.Sprite =Sprite;
        this.Type = Type;

        transform.SetParent ( parent, false );

        border.color = Color;
        text.text = Name;
        image.sprite = Sprite;
    }
}
