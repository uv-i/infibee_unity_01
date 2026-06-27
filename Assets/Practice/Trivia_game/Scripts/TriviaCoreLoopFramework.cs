using System;
using System.Collections.Generic;

namespace TriviaCoreLoopFramework
{
    [Serializable]
    public class answerItem
    {
        public string answer;
        public bool isCorrect;
    }

    [Serializable]
    public class QuestionItem
    {
        public string question;
        public List<AnswerDatum> answers = new();
    }
}