using UnityEngine;
using System;

namespace Framework 
{
    public enum CardType
    {
        One, Two, Two_Plus, Flip, Skip
    }

    [Serializable]
    public class CardData
    {
        public string Name;
        public Color Color;
        public Sprite Sprite;
        public CardType Type;
    }
}
