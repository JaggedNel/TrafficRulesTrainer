using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficRulesTrainer {
    public class UserData {
        public string Login;
        public string Password;

        public UserData(string login, string password) {
            Login = login;
            Password = password;
        }
    }
}
