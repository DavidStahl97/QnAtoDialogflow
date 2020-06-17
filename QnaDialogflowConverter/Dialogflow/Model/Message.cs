using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow.Model
{
    class Message
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; } = 0;

        [JsonProperty(PropertyName = "lang")]
        public string Language { get; set; } = "de";

        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; } = "";

        [JsonProperty(PropertyName = "speech")]
        public List<string> Speech { get; } = new List<string>();
    }
}
