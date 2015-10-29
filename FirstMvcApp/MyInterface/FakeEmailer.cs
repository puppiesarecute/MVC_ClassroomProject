using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.MyInterface
{
    public class FakeEmailer : IEmailer
    {
        public void Send(string message)
        {
            Console.WriteLine("This is the fake class emailer used for testing");
        }
    }
}