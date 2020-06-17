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
        public static IEnumerable<Intend> ReadFile(string fileName)
        {
            var qnaReader = new ClosedXmlTable(fileName);
            var intends = new List<Intend>();

            for (int i = 2; i < qnaReader.RowCount; i++)
            {
                var question = qnaReader.GetStringOfField(i, 1);
                var answer = qnaReader.GetStringOfField(i, 2);

                var existingIntend = intends.FirstOrDefault(intend => intend.Answers.Any(a => a == answer));
                if (existingIntend is null)
                {
                    var newIntend = new Intend();
                    newIntend.Answers.Add(answer);
                    newIntend.Questions.Add(question);
                    intends.Add(newIntend);
                }
                else
                {
                    existingIntend.Questions.Add(question);
                }
            }

            return intends;
        }
    }
}
