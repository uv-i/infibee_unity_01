using System.Collections.Generic;
using UnityEngine;

namespace TriviaCoreLoopFramework
{
    [CreateAssetMenu(fileName = "Questions", menuName = "TriviaMVP/Questions")]
    public class QuestionSO_Practice : ScriptableObject
    {
        // Make sure this points to your new QuestionItem name!
        public List<QuestionItem> QuestionData;
    }
}