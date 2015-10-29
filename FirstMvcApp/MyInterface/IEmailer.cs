using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcApp.MyInterface
{
    public interface IEmailer
    {
        void Send(string message);
    }
}
