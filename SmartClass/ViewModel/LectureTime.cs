using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.ViewModel
{
    class LectureTime
    {
        public int EndTime;
        public int StartTime;
        public int WeekDay;
        public LectureTime(int e, int s,int w)
        {
            EndTime = e;
            StartTime = s;
            WeekDay = w;
        }
    }
}
