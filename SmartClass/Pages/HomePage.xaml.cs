using SmartClass.Lib;
using SmartClass.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace SmartClass.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public int min_member_cnt
        {
            get
            {
                return 2;
            }
        }
        public int max_member_cnt
        {
            get
            {
                return 4;
            }
        }
        private String cid = "";
        private List<Group> groups = new List<Group>();
        private List<GroupWish> GroupWishes = new List<GroupWish>();
        private CourseList courses = new CourseList();
        Dictionary<String, member> allMembers = new Dictionary<String, member>();
        Dictionary<String, int> welcome = new Dictionary<string, int>();
        Dictionary<String, Dictionary<String, int>> like = new Dictionary<string, Dictionary<string, int>>();
        private BackgroundWorker backGroundWorker;
        public HomePage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await courses.Refresh();
            LSTVWcourse.ItemsSource = courses;
        }

        private BackgroundWorker MakeBackgroundWorker(DoWorkEventHandler handler)
        {
            BackgroundWorker bw = new BackgroundWorker();

            bw.ProgressChanged += delegate (object sender, ProgressChangedEventArgs e)
            {
                if (e.ProgressPercentage >= 0)
                    progress_bar.Value = e.ProgressPercentage;
                statusBox.Text = e.UserState.ToString();
            };
            bw.RunWorkerCompleted += async delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                progress_bar.Value = 100;
                /*if (e.Error == null)
                    temp_block.Text = "完成!";
                else temp_block.Text = "错误: " + e.Error.Message;*/
                //UseWaitCursor = false;
                await saveGroup();
            };
            bw.WorkerReportsProgress = true;
            bw.DoWork += handler;

            return bw;
        }

        private async void LSTVWcourse_ItemClick(object sender, ItemClickEventArgs e)
        {
            groups.Clear();
            GroupWishes.Clear();
            allMembers.Clear();
            like.Clear();
            welcome.Clear();
            cid = (e.ClickedItem as CourseInfo).ID;
            Parameters result = await WebConnection.ConnectWithGet(Constants.Domain + "/api/group/givewish?_id="+Constants.UserID+"&course_id="+ cid);
            if (result.Name != "200")
            {
                Debug.WriteLine("连接网络失败");
                return;
            }
            HandleJson(result.Value);
        }

        private async Task saveGroup()
        {
            foreach(var g in groups)
            {
                JsonObject send = new JsonObject();
                send.Add("group_name", JsonValue.CreateStringValue(g.name));
                send.Add("course_id", JsonValue.CreateStringValue(cid));
                send.Add("leader_id", JsonValue.CreateStringValue(g.leader_id));
                send.Add("leader_name", JsonValue.CreateStringValue(g.leader_name));
                JsonArray array = new JsonArray();
                foreach(var m in g.members)
                {
                    JsonObject obj = new JsonObject();
                    obj.Add("member_id", JsonValue.CreateStringValue(m.id));
                    obj.Add("member_name", JsonValue.CreateStringValue(m.name));
                    array.Add(obj);
                }
                send.Add("member",array);
                Parameters result = await WebConnection.ConnectWithPost(Constants.Domain + "/api/group/savegroup?_id=" + Constants.UserID,send);
                if (result.Name != "200")
                {
                    Debug.WriteLine("连接网络失败");
                    return;
                }
                else Debug.WriteLine("提交小组成功");
            }
        }

        private void HandleJson(string value)
        {
            try
            {
                JsonObject json = JsonObject.Parse(value);
                JsonArray wshes = json.GetNamedArray("wishes");
                foreach(var wish in wshes)
                {
                    GroupWish w = new GroupWish();
                    w.wishes = new List<member>();
                    JsonObject obj = wish.GetObject();
                    String require_id = obj.GetNamedString("require_id");
                    String require_name = obj.GetNamedString("require_name");
                    JsonArray target = obj.GetNamedArray("target");
                    w.requirer = new member { id = require_id, name = require_name };
                    foreach(var t in target)
                    {
                        JsonObject tob = t.GetObject();
                        String mid = tob.GetNamedString("member_id");
                        String mname = tob.GetNamedString("member_name");
                        w.wishes.Add(new member { id = mid, name = mname });
                    }
                    GroupWishes.Add(w);
                }
            }
            catch
            {
                return;
            }
            finally
            {
                autoGroup();
            }
        }

        private int getGood(String id1,String id2)
        {
            return like[id1][id2] * like[id2][id1];
        }

        private String getNextWelcome()
        {
            String ret = "";
            int temp = -1;
            foreach(var w in welcome)
            {
                if (w.Value > temp)
                {
                    temp = w.Value;
                    ret = w.Key;
                }
            }
            return ret;
        }

        private void autoGroup()
        {
            backGroundWorker = MakeBackgroundWorker(delegate
            {            
                foreach(var wish in GroupWishes)
                {
                    if (!allMembers.ContainsKey(wish.requirer.id))
                    {
                        allMembers[wish.requirer.id] = wish.requirer;
                    }
                    foreach(var t in wish.wishes)
                    {
                        if (!allMembers.ContainsKey(t.id))
                            allMembers[t.id] = t;
                    }
                }
                foreach(var member1 in allMembers.Values)
                {
                    like[member1.id] = new Dictionary<string, int>();
                    foreach(var member2 in allMembers.Values)
                    {
                        if (member1.id == member2.id)
                            like[member1.id][member2.id] = 0;
                        else like[member1.id][member2.id] = 1;
                    }
                }
                foreach (var wish in GroupWishes)
                {
                    foreach (var t in wish.wishes)
                    {
                        like[wish.requirer.id][t.id] = 2;
                    }
                }
                foreach (var member in allMembers.Values)
                {
                    int wel = 0;
                    foreach(var member2 in allMembers.Values)
                    {
                        wel += getGood(member.id, member2.id);
                    }
                    welcome[member.id] = wel;
                }
                while (welcome.Count > 0)
                {
                    String next = getNextWelcome();
                    welcome.Remove(next);
                    Group g = new Group();
                    member leader = allMembers[next];
                    g.leader_id = leader.id;
                    g.leader_name = leader.name;
                    g.name = leader.name + " group";
                    g.members = new List<member>();
                    foreach(var member_id in allMembers.Keys)
                    {
                        if (g.members.Count >= max_member_cnt) break;
                        if (!welcome.ContainsKey(member_id)) continue;
                        if (getGood(leader.id, member_id) > 2)
                        {
                            g.members.Add(allMembers[member_id]);
                            welcome.Remove(member_id);
                        }
                    }
                    if (g.members.Count < min_member_cnt)
                    {
                        foreach (var member_id in allMembers.Keys)
                        {
                            if (g.members.Count >= max_member_cnt) break;
                            if (!welcome.ContainsKey(member_id)) continue;
                            if (like[leader.id][member_id]>1)
                            {
                                g.members.Add(allMembers[member_id]);
                                welcome.Remove(member_id);
                            }
                        }
                    }
                    if (g.members.Count < min_member_cnt)
                    {
                        foreach (var member_id in allMembers.Keys)
                        {
                            if (g.members.Count >= max_member_cnt) break;
                            if (!welcome.ContainsKey(member_id)) continue;
                            if (getGood(leader.id,member_id) > 1)
                            {
                                g.members.Add(allMembers[member_id]);
                                welcome.Remove(member_id);
                            }
                        }
                    }
                    if (g.members.Count < min_member_cnt)
                    {
                        foreach (var member_id in allMembers.Keys)
                        {
                            if (g.members.Count >= min_member_cnt) break;
                            if (!welcome.ContainsKey(member_id)) continue;
                            if (getGood(leader.id, member_id) > 0)
                            {
                                g.members.Add(allMembers[member_id]);
                                welcome.Remove(member_id);
                            }
                        }
                    }
                    groups.Add(g);
                    double prog = (1 - ((double)welcome.Count) / ((double)allMembers.Count)) * 100;
                    backGroundWorker.ReportProgress((int)prog, "剩余"+welcome.Count+"/"+allMembers.Count);
                }
            });
            backGroundWorker.RunWorkerAsync();
        }
    }
}
