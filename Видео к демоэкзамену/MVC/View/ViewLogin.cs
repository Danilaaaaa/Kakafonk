using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Видео_к_демоэкзамену.MVC.Controller;

namespace Видео_к_демоэкзамену.MVC.View
{
    class ViewLogin
    {
        public string GetLogin(string loginCheckOdb)
        {
            return DataBaseHelpController.GetLoginMain(loginCheckOdb);
        }
    }
}
