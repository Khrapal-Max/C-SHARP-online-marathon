using System;
/*Consider the previous tasks (1) and(2) with the SRP and OCP principles applied. Let’s say that we want to add additional functionality to the NotificationService class for writing notification records to Database but this records to be only for emails.
t3_1
Changes in MailService class
t3_2
and in SmsService class
t3_3
and as the result in Customer class:
t3_4
Above code in the Customer class will fail because of the AddNotificationToDB method in the smsService class called. One solution is not to call the above method but we raise another problem. We have a class that implements method that is not used. According to LSP you have to ensure that new derived classes extend the base classes without changing their behavior.
Your task is to fix this issue by the implementation in the following way:
-create an interface INotification with the method SendNotification();
-create an interface INotificationToDB with the method AddNotificationToDB();
-the class MailService have to implement both interfaces INotification and INotificationToDB;
-the class SmsService have to implement INotification;
-change the class Customer. You may comment the code that uses the call of method AddNotificationToDB().
Note.You may use the console notification from method  SendNotification() in the classes MailService and SmsService as it was described in previous tasks.*/


namespace Task03
{
    interface INotification
    {
        void SendNotification();
    }
    interface INotificationToDB
    {
        void AddNotificationToDB();
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
                smsService.SendNotification();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class MailService : INotification, INotificationToDB
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
        public void AddNotificationToDB() {}
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
            Customer.Register("some@my.com", "12233");
            Console.WriteLine("Hello World!");
        }
    }
}
