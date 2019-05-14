using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    public class Task : ITask
    {
        public IPerson assigned { get; set; }
        public string status { get; set; }
        IMessageSender _messageSender;
        public Task(IMessageSender messageSender)
        {
            _messageSender = messageSender; 
        }
        public void sendEmail(IPerson person, string msg)
        {
            _messageSender.sendEmail(person, msg);
        }
    }
}
