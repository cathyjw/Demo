using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    public class Emailer : IMessageSender
    {
        public void sendEmail(IPerson person, string message)
        {
            Console.WriteLine($"{person.Name} send {message}");
        }
    }
}
