using System.Collections.Generic;
using UnityEngine;

namespace TriviaCoreLoopFramework
{
    [CreateAssetMenu ( fileName = "Questions", menuName = "TriviaMVP/Questions" )]
    public class QuestionSO : ScriptableObject
    {
        public List<QuestionDatum> QuestionData;
    }
}