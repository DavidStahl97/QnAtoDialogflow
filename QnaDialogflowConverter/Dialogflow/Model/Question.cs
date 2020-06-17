using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnaDialogflowConverter.Dialogflow.Model
{
    class Question
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "data")]
        public ICollection<QuestionData> Data { get; } = new List<QuestionData>();

        [JsonProperty(PropertyName = "isTemplate")]
        public bool IsTemplate { get; set; } = false;

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; } = 0;

        [JsonProperty(PropertyName = "updated")]
        public int Updated { get; set; } = 0;
    }
}
