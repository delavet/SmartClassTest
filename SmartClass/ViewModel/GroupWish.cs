using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.ViewModel
{
    public class member
    {
        public String id;
        public String name;
    }

    public class GroupWish
    {
        public member requirer;
        public List<member> wishes;
    }

    public class Group
    {
        public String name;
        public String leader_id;
        public String leader_name;
        public List<member> members;
    }
}
