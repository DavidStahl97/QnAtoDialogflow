using LTRSimulation.Infrastructure.Files;
using QnaDialogflowConverter.Dialogflow.Model;
using QnaDialogflowConverter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow
{
    class DialogflowWriter
    {
        public static void Write(IEnumerable<Intent> intents, string folderName)
        {
            foreach(var intent in intents)
            {
                var intentQuestion = ConvertToQuestionIntent(intent);
                var intentAnswer = ConvertToAnswerIntent(intent);

                var dialogFlowFileName = $"{ folderName }\\{ intentAnswer.Name }";
                FileStorage.Write(intentAnswer, $"{ dialogFlowFileName }.json");
                FileStorage.Write(intentQuestion.Questions.ToList(), $"{ dialogFlowFileName }_usersays_de.json");
            }
        }

        private static IntentQuestion ConvertToQuestionIntent(Intent intent)
        {
            var questions = intent.Questions.Select(q =>
            {
                var question = new Question();
                question.Data.Add(new QuestionData { Text = q });
                return question;
            });

            var intentQuestions = new IntentQuestion();
            intentQuestions.Questions.AddRange(questions);
            return intentQuestions;
        }

        private static IntentAnswer ConvertToAnswerIntent(Intent intent)
        {
            var intentAnswer = new IntentAnswer
            {
                Name = $"qna.{ Guid.NewGuid() }",
            };

            var response = new Response
            {
                Action = intentAnswer.Name,
            };

            var message = new Message();
            message.Speech.AddRange(intent.Answers);
            response.Messages.Add(message);

            intentAnswer.Responses.Add(response);
            return intentAnswer;
        }
    }
}
