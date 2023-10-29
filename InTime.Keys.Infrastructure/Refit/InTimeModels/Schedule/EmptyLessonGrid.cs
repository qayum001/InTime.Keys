using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Keys.Infrastructure.Refit.InTimeModels.Schedule
{
    [JsonConverter(typeof(JsonKnownTypesConverter<EmptyLessonGrid>))]
    [JsonDiscriminator(Name = "type")]
    [JsonKnownThisType("EMPTY")]
    public class EmptyLessonGrid
    {
        public string Type { get; set; }
        public int LessonNumber { get; set; }
        public int Starts { get; set; }
        public int Ends { get; set; }
    }
}
