using DocumentFormat.OpenXml.Office2013.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow.Model
{
    class QuestionData
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "userDefined")]
        public bool UserDefined { get; set; } = false;
    }
}
