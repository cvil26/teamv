﻿using System;

namespace MobilePoll.MessageContracts.Events
{
    public class YesNoAnswerReceived : ISurveyAnswerEvent 
    {
        public Guid SurveyId { get; set; }
        public string SurveyName { get; set; }
        public bool Result { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}