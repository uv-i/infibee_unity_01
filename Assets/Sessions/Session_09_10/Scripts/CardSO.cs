using UnityEngine;
using System.Collections.Generic;
using Framework;

[CreateAssetMenu(fileName ="CardSO", menuName ="Uno/CardSO")]
public class CardSO : ScriptableObject
{
    public List<CardData> CardData = new List<CardData>();
}
