using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace MidExam.WinApp
{
     public static class Conn
    {
         public static String VfpConnection = 
             ConfigurationManager.ConnectionStrings["VfpConnectionString"].ToString();
        //Provider=Microsoft.Jet.OLEDB.4.0; Data Source=
         //public static String AccessConnection =
         //    ConfigurationManager.ConnectionStrings["AccessConnectionString"].ToString();
    }
}
