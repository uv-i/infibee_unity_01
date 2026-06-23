
using System.Collections.Generic;
using UnityEngine;

namespace TriviaCoreLoopFramework
{
    [CreateAssetMenu ( fileName = "Answers", menuName = "TriviaMVP/Answers" )]
    public class AnswerSO : ScriptableObject
    {
        public List<AnswerDatum> AnswerData;
    }
}