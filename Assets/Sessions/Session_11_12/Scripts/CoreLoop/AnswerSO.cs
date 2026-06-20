
using System.Collections.Generic;
using UnityEngine;
using static TriviaCoreLoop.Framework;

[CreateAssetMenu ( fileName = "Answers", menuName = "TriviaMVP/Answers" )] 
public class AnswerSO : ScriptableObject
{
    public List<AnswerDatum> AnswerData;
}
