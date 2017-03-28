using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.ViewModel
{
    class CourseInfo : INotifyPropertyChanged
    {
        private String id;
        public String ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        private long endDate;
        public long EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged();
            }
        }
        private long startDate;
        public long StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged();
            }
        }
        private long finalExam;
        public long FinalExam
        {
            get
            {
                return finalExam;
            }
            set
            {
                finalExam = value;
                OnPropertyChanged();
            }
        }
        private String introduction;
        public String Introduction
        {
            get
            {
                return introduction;
            }
            set
            {
                introduction = value;
                OnPropertyChanged();
            }
        }
        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public List<LectureTime> LectureTimes;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public CourseInfo(String _id,long start,long end,long final,String intro,String _name,List<LectureTime> times)
        {
            ID = _id;
            StartDate = start;
            EndDate = end;
            FinalExam = final;
            Introduction = intro;
            Name = _name;
            LectureTimes = times;
        }
    }
}
