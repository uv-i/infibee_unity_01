using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] CardSO cardSO;
    [SerializeField] GameObject card;
    [SerializeField] Transform table;

    private void Start ( )
    {
        foreach ( var data in cardSO.CardData)
        {
            Instantiate ( card ).GetComponent<BaseCard>().OnSpawn(data.Name, data.Color, data.Sprite, data.Type, table);
        }
    }
}
