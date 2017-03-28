using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using SmartClass.Lib;
using System.Diagnostics;
using Windows.Data.Json;

namespace SmartClass.ViewModel
{
    class CourseList : ObservableCollection<CourseInfo>
    {
        public event DataLoadingEventHandler Loading;
        public event DataLoadedEventHandler Loaded;
        public async Task Refresh()
        {
            Parameters result = await WebConnection.ConnectWithGet(Constants.Domain + "/api/course/all"+"?_id="+Constants.UserID);
            if (result.Name != "200")
            {
                Debug.WriteLine("连接网络失败");
                return;
            }
            HandleJson(result.Value);
        }
        private void HandleJson(String jsonStr)
        {
            String _id = "", intro = "", _name = "";
            long start = 0, end = 0, final = 0;
            List<LectureTime> times = new List<LectureTime>();
            try
            {
                JsonObject allJson = JsonObject.Parse(jsonStr);
                bool success = allJson.GetNamedBoolean("success");
                if (!success) throw new Exception();
                JsonArray courses = allJson.GetNamedArray("courses");
                foreach(var courseVal in courses)
                {
                    JsonObject json = courseVal.GetObject();
                    _id = json.GetNamedString("course_id");
                    intro = json.GetNamedString("introduction");
                    _name = json.GetNamedString("name");
                    start = (long)json.GetNamedNumber("startDate");
                    end = (long)json.GetNamedNumber("endDate");
                    final = (long)json.GetNamedNumber("finalExam");
                    JsonArray array = json.GetNamedArray("lectureTime");
                    foreach (var val in array)
                    {
                        JsonObject obj = val.GetObject();
                        int e = (int)obj.GetNamedNumber("endTime");
                        int s = (int)obj.GetNamedNumber("startTime");
                        int w = (int)obj.GetNamedNumber("weekday");
                        times.Add(new LectureTime(e, s, w));
                    }
                    this.Add(new CourseInfo(_id, start, end, final, intro, _name, times));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("fail to parse json " + e.StackTrace);
            }
        }
    }
}
