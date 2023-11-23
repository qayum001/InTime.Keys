using InTime.Keys.Infrastructure.Refit.InTimeModels.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Keys.Infrastructure.Refit.InTimeModels
{
    public class InTimeSchedule
    {
        public DateTime Date { get; set; }
        public IEnumerable<EmptyLessonGrid> Lessons { get; set; }
    }
}
