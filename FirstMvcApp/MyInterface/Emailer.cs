using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.MyInterface
{
    public class Emailer : IEmailer
    {
        public void Send(string message)
        {
            Console.WriteLine("Message sent at" + DateTime.Now);
        }
    }
}