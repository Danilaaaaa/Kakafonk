using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Видео_к_демоэкзамену.DataFilesApp;
using Видео_к_демоэкзамену.MVC.HelpController;

namespace Видео_к_демоэкзамену.MVC.Controller
{
    class DataBaseHelpController
    {
        public static string GetLoginMain(string getSetLogin)
        {
            User userObj = odbconnecthelper.entObj.User.FirstOrDefault(x => x.Login == getSetLogin );
            while (true)
            {
                if(userObj !=null)
                {
                    return "Пользователь есть!";
                }
                else
                {
                    return "Такого пользователя нет!";
                }
            }
        }
    }
}
