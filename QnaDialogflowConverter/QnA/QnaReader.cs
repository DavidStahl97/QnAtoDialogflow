using LTRSimulation.Common.Services;
using QnaDialogflowConverter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.QnA
{
    class QnaReader
    {
        public static IEnumerable<Intent> ReadFile(string fileName)
        {
            var qnaReader = new ClosedXmlTable(fileName);
            var intends = new List<Intent>();

            for (int i = 2; i < qnaReader.RowCount; i++)
            {
                var question = qnaReader.GetStringOfField(i, 1);
                var answer = qnaReader.GetStringOfField(i, 2);

                var existingIntent = intends.FirstOrDefault(intend => intend.Answers.Any(a => a == answer));
                if (existingIntent is null)
                {
                    var newIntent = new Intent();
                    newIntent.Answers.Add(answer);
                    newIntent.Questions.Add(question);
                    intends.Add(newIntent);
                }
                else
                {
                    existingIntent.Questions.Add(question);
                }
            }

            return intends;
        }
    }
}
