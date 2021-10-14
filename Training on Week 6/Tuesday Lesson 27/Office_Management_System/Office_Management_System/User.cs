using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Management_System
{
    class User
    {
        public string user_id { get; private set; }
        public string user_name { get; private set; }

        public string user_pw { get; private set; }
        public string user_email { get; private set; }

        public string task_assigned { get; set; }
        

        public User(string id, string name, string pw, string email)
        {
            user_id = id;
            user_name = name;
            user_pw = pw;            
            user_email = email;
        }
        public User(string id, string name, string pw, string email, string task)
        {
            user_id = id;            
            user_name = name;
            user_pw = pw;
            user_email = email;
            task_assigned = task;
        }

        public override string ToString()
        {
            return user_id + "_" + user_name + "_" + user_pw + "_" + user_email + "_" + task_assigned;
        }
    }
}
