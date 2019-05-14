namespace OOD
{
    public interface ITask
    {
        IPerson assigned { get; set; }
        string status { get; set; }

        void sendEmail(IPerson person, string msg);
    }
}