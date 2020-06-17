using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow.Model
{
    class IntentAnswer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "auto")]
        public bool Auto { get; set; } = true;

        [JsonProperty(PropertyName = "responses")]
        public ICollection<Response> Responses { get; } = new List<Response>();

        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; } = 500000;

        [JsonProperty(PropertyName = "webhookUser")]
        public bool WebhookUser { get; set; } = false;

        [JsonProperty(PropertyName = "webhookForSlotFilling")]
        public bool WebhookForSlotFilling { get; set; } = false;

        [JsonProperty(PropertyName = "fallbackIntent")]
        public bool FallbackIntent { get; set; } = false;

        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; } = "";
    }
}
