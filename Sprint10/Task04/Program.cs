using System;
//According to the previous tasks (1), (2), (3) let’s say that we want to add additional functionality to the Notification interface for Reading notification from Database:
//t4_1
//With this definition we obligate the class that inherits from this interface to implement the method for reading notification. Maybe in some cases we don’t want to have this but because of the inheritance we need to define the method in the class even if we don’t want to implement this. The solution for this problem is to separate all the methods that are not used everywhere in a separate interface like as follows:

//-change the interface INotificationToDB and leave only one method in it (as you consider);

//-create the interface INotificationToDBRead and define one method in it  (as you consider);

//-the class MailService will implement three interfaces: INotification, INotificationToDB, INotificationToDBRead.Each of the methods of these interfaces will output some message into console;

//-change class Customer if you need.


namespace Task04
{
    interface INotification
    {
        void SendNotification();
    }
    interface INotificationToDB
    {
        void AddNotificationToDB();
    }
    interface INotificationToDBRead
    {
        void ReadNotification();
    }
    public class Customer
    {
        public static void Register(string email, string password)
        {
            try
            {
                var mailService = new MailService();
                mailService.Email = email;
                mailService.EmailTitle = "User registration";
                mailService.EmailBody = "Body of message...";

                var smsService = new SmsService();
                smsService.Number = "111 111 111";
                smsService.SmsText = "User successfully registered...";

                if (mailService.ValidEmail())
                {
                    mailService.SendNotification();
                    mailService.AddNotificationToDB();
                }
                mailService.ReadNotification();
                smsService.SendNotification();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class MailService : INotification, INotificationToDB, INotificationToDBRead
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public bool ValidEmail()
        {
            return Email.Contains("@");
        }
        public void SendNotification()
        {
            Console.WriteLine($"Mail:{Email}, Title:{EmailTitle}, Body:{EmailBody}");
        }
        public void AddNotificationToDB() 
        {
            Console.WriteLine("IAdd");
        }
        public void ReadNotification() 
        {
            Console.WriteLine("IRead");
        }
    }
    public class SmsService : INotification
    {
        public string Number { get; set; }
        public string SmsText { get; set; }

        public void SendNotification()
        {
            Console.WriteLine($"Number:{Number}, Message:{SmsText}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
