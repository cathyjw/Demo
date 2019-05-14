using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //person.Address = ".....";

            //Manager manager = new Manager();
            //manager.Address = ",,,,";

            IPerson person = Factory.CreatePerson();
            person.Name = "Shenyi Bao";
            person.Address = "11715 26 AVE NW Edmonton";

            ITask task = Factory.CreateTask();
            task.assigned = person;
            task.status = "I am good";

            //thousand lines of codes like this
            Emailer emailer = new Emailer();
            emailer.sendEmail(person, "ABC");

            task.sendEmail(person, task.status);
            Console.ReadLine();
        }
    }
}
