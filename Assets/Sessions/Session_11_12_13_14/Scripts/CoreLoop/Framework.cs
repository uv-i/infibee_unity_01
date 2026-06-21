
using System;
using System.Collections.Generic;

namespace TriviaCoreLoopFramework
{
    [Serializable]
    public class AnswerDatum
    {
        public string answer;
        public bool isCorrect;
    }

    [Serializable]
    public class QuestionDatum
    {
        public string question;
        public List<AnswerDatum> answers =  new ();
    }
}