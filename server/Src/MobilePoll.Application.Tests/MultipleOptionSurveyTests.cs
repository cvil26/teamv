using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePoll.Application.Parsers;
using MobilePoll.Application.Tests.StubData;
using MobilePoll.Application.Tests.Stubs;
using MobilePoll.MessageContracts.Events;
using Shouldly;

namespace MobilePoll.Application.Tests
{
    [TestClass]
    public class MultipleOptionSurveyTests
    {
        private static readonly Guid Id = Guid.NewGuid();
        private MultipleOptionQuestionParser parser;
        private LocalBusStub bus;

        [TestInitialize]
        public void Initialize()
        {
            bus = new LocalBusStub();
            parser = new MultipleOptionQuestionParser();
            parser.Bus = bus;
        }

        [TestMethod]
        public void Parser_must_be_able_to_identify_a_multiple_option_question()
        {
            parser.Parse(Id, "TestSurvey", TestQuestions.MultipleOptionQuestion);
            bus.EventTypeWasRaised<MultipleOptionAnswerReceived>().ShouldBe(true);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Parser_must_fail_if_question_is_null()
        {
            parser.Parse(Id, "TestSurvey", null);
        }

        [TestMethod]
        public void Question_must_contain_answer_if_mandatory()
        {
            parser.Parse(Id, "TestSurvey", TestQuestions.MultipleOptionQuestion);
            bus.EventTypeWasRaised<MultipleOptionAnswerReceived>().ShouldBe(true);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Parser_must_fail_if_mandatory_question_not_answered()
        {
            parser.Parse(Id, "TestSurvey", TestQuestions.NoAnswerMultipleOptionQuestion);
        }

        [TestMethod]
        public void Answer_event_is_raised()
        {
            parser.Parse(Id, "TestSurvey", TestQuestions.MultipleOptionQuestion);

            bus.EventTypeWasRaised<MultipleOptionAnswerReceived>().ShouldBe(true);
            var answer = bus.GetFirstEventOfType<MultipleOptionAnswerReceived>();
            answer.SelectedOptions[0].ShouldBe("Red");
            answer.SelectedOptions[1].ShouldBe("Green");
        }
    }
}