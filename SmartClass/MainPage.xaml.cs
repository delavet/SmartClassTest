using SmartClass.Lib;
using SmartClass.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace SmartClass
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Constants.BoxPage = this;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Parameters result = await WebConnection.ConnectWithGet(Constants.Domain + "/api/pushTest");
            /*JsonObject json = new JsonObject();
            json.Add("name", JsonValue.CreateStringValue("1400012944"));
            json.Add("password", JsonValue.CreateStringValue("Delavet0719"));*/
            //if (Constants.Name == "" || Constants.Password == "") return;
            //await Login(Constants.Name, Constants.Password);  
            //await CourseAll();
        }
        private async Task RegistCourse()
        {
            JsonObject obj = new JsonObject();
            obj.Add("_id", JsonValue.CreateStringValue(Constants.UserID));
            obj.Add("name", JsonValue.CreateStringValue("上神大人概论"));
            obj.Add("introduction", JsonValue.CreateStringValue("上神大人就是屌，根本赢不了"));
            obj.Add("midterm", JsonValue.CreateNumberValue(Util.GetTimeStamp(DateTime.Now)));
            obj.Add("finalExam", JsonValue.CreateNumberValue(Util.GetTimeStamp(DateTime.Now)));
            obj.Add("maxStudentsNumber", JsonValue.CreateNumberValue(30));
            obj.Add("term", JsonValue.CreateStringValue("2016秋季"));
            obj.Add("startDate", JsonValue.CreateNumberValue(Util.GetTimeStamp(DateTime.Now)));
            obj.Add("endDate", JsonValue.CreateNumberValue(Util.GetTimeStamp(DateTime.Now.AddDays(30))));
            JsonObject lec = new JsonObject();
            lec.Add("startTime", JsonValue.CreateNumberValue(1));
            lec.Add("endTime", JsonValue.CreateNumberValue(4));
            lec.Add("weekday", JsonValue.CreateNumberValue(3));
            JsonArray lecs = new JsonArray();
            lecs.Add(lec);
            obj.Add("lectureTime",lecs);
            Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/private/course/register", obj);
            int i = 0;
        }
        private async Task CourseAll()
        {
            Parameters result = await WebConnection.ConnectWithGet(Constants.Domain + "/api/course/all?_id="+Constants.UserID+"&token="+Constants.Token);
            String str = result.Value;
        }
        private async Task SelectCourse()
        {
            List<Parameters> param = new List<Parameters>();
            param.Add(new Parameters("_id", Constants.UserID));
            param.Add(new Parameters("course_id", "58316127c811cb140af78198"));
            Parameters result = await WebConnection.ConnectWithPut(Constants.Domain + "/api/user/attend", param);
            String str = result.Value;
        }
        private async Task AddLesson()
        {
            List<Parameters> param = new List<Parameters>();
            param.Add(new Parameters("_id", Constants.UserID));
            param.Add(new Parameters("course_id", "58316127c811cb140af78198"));
            param.Add(new Parameters("lesson_id", "2"));
            param.Add(new Parameters("lesson_name", "上神无敌"));
            Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/private/lesson/add", param);
            String str = result.Value;
        }
        private async Task PostNotice()
        {
                List<Parameters> param = new List<Parameters>();
                param.Add(new Parameters("_id", Constants.UserID));
                param.Add(new Parameters("course_id", "58316127c811cb140af78198"));
                param.Add(new Parameters("title", "null"));
                param.Add(new Parameters("content", "我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了我编不下去了"));
                Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/private/notification/post", param);          
        }
        private async Task SignUp(String name,String pswd)
        {
            List<Parameters> param = new List<Parameters>();
            param.Add(new Parameters("name", name));
            param.Add(new Parameters("password", pswd));
            param.Add(new Parameters("email", ""));
            param.Add(new Parameters("phone", ""));
            param.Add(new Parameters("realName", ""));
            Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/api/user/register", param);
            if (result.Name != "200")
            {
                Util.DealWithDisConnect(result);
                return;
            }
        }
        private async Task Login(String name,String pswd)
        {
            List<Parameters> param = new List<Parameters>();
            param.Add(new Parameters("name", name));
            param.Add(new Parameters("password", pswd));
            Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/api/user/login", param);
            
            if (result.Name != "200")
            {
                Util.DealWithDisConnect(result);
                return;
            }
            HandleLoginJson(result.Value);
            //await RegistCourse();
            //await CourseAll();
            //await SelectCourse();
            //await AddLesson();
            //await PostNotice();
        }
        private void HandleLoginJson(String jsonStr)
        {
            JsonObject json;
            try
            {
                json = JsonObject.Parse(jsonStr);
            }catch(Exception e)
            {
                Debug.WriteLine("Parse json failed!" + e.StackTrace);
                MSGlogin.ShowMsg("登录失败，数据解析出错:\n"+jsonStr);
                return;
            }
            try
            {
                Boolean success = json.GetNamedBoolean("success");
                if (!success) throw new Exception();
                //Constants.Name = json.GetNamedString("name");
                //Constants.RealName = json.GetNamedString("realName");
                //Constants.Admin = json.GetNamedBoolean("admin");
                //Constants.CreateAt = (long)json.GetNamedNumber("createdAt");
                Constants.UserID = json.GetNamedString("_id");
                Constants.Token = json.GetNamedString("token");
                //Constants.Type = json.GetNamedString("type");
            }catch
            {
                MSGlogin.ShowMsg("获取信息出错:\n" + jsonStr);
                return;
            }
            FinishLogin();
        }

        private void FinishLogin()
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private async void BTNsubmit_Click(object sender, RoutedEventArgs e)
        {
            await Login(TXTBXid.Text,TXTBXpassword.Password);
            
        }

        private async void BTNsignUp_Click(object sender, RoutedEventArgs e)
        {
            await SignUp(TXTBXid.Text, TXTBXpassword.Password);
        }
    }
}
