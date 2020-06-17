using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Domain
{
    class Intend
    {
        public ICollection<string> Answers { get; } = new List<string>();

        public ICollection<string> Questions { get; } = new List<string>();
    }
}
