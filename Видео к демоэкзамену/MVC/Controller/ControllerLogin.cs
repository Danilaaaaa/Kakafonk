using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Видео_к_демоэкзамену.MVC.View;

namespace Видео_к_демоэкзамену.MVC.Controller
{
    class ControllerLogin
    {
        public static string CheckLoginOdb(string loginCheck)
        {
            ViewLogin viewLogin = new ViewLogin();
            return viewLogin.GetLogin(loginCheck);
        }
    }
}
