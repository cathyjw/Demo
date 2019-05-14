using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    public static class Factory
    {
        public static IPerson CreatePerson()
        {
            return new Person();
        }
        public static ITask CreateTask()
        {
            return new Task(CreateMessageSender());
        }
        public static IMessageSender CreateMessageSender()
        {
            return new Chat();
            //return new Email();
        }
    }
}
