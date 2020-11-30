using System;

//From the previous tasks (1) -(4) we had the following situations with the Customer class:
//t5_1
//We have a lot of code here.DIP says that high-level modules/classes should not depend upon low-level modules/classes.Both should depend upon abstractions.Secondly, abstractions should not depend upon details.Details should depend upon abstractions
//Let’s isolate this class Customer as a separate component.You have to define within this class
//-the constructor with INotification parameter;
//-leave method Register() with two string input parameters email and password. Leave only empty "try ... catch ..." statement in the body of method;
//-leave method SendNotification() with INotification notification parameter. It will initiate the console output of notification (as in the previous tasks).
//Classes MailService, SmsService and interfaces INotification, INotificationToDB and INotificationToDBRead use without any change.
//The instantiation of the classes will cause the output as follows:
namespace Task05
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
    class Customer
    {
        INotification notification;
        public Customer(INotification notification)
        {
            this.notification = notification;
        }
        public void Register(string email, string password)
        {
            try { }
            catch { }
        }
        public void SendNotification(INotification notification)
        {
            notification.SendNotification();
        }
    }
    class MailService : INotification, INotificationToDB, INotificationToDBRead
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
    class SmsService : INotification
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
            var service = new MailService();
            service.Email = "mytest@test.com";
            service.EmailTitle = "User registration";
            service.EmailBody = "Body of message...";
            var smsService = new SmsService();
            smsService.Number = "111 111 111";
            smsService.SmsText = "User successfully registered...";
            if (service.ValidEmail())
            {
                var customer = new Customer(service);

                customer.Register("mytest@test.com", "12345");
                customer.SendNotification(service);

               // customer.AddNotificationToDB();
            }

            

            var customer1 = new Customer(smsService);
            customer1.SendNotification(smsService);
            Console.WriteLine("Hello World!");
        }
    }
}
