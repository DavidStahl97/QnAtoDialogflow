using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow.Model
{
    class Response
    {
        [JsonProperty(PropertyName = "resetContexts")]
        public bool ResetContexts { get; set; } = false;

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
