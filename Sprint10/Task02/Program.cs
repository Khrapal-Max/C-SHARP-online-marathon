using System;
/*Consider the class Customer from the previous  task(1) with the SRP principle applied. 
t2_1
Let’s say that we want to add additional functionality. After user registration  we want to send email and sms to that user. According to the SRP principle we would add additional classes. You have to create:
1) public abstract class NotificationService with abstract method SendNotification().
2) public class MailService (inherited from class NotificationService) with:
-three string properties: Email, EmailTitle and EmailBody;
-boolean method ValidEmail() that returns True if the Email contains "@";
-overriden method SendNotification() that output in console formatted string ("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody).
3) public class SmsService (inherited from class NotificationService) with:
-two string properties Number, SmsText;
-overriden method SendNotification() that output in console formatted string ("Number:{0}, Message:{1}", Number, SmsText).
The result of the registration of the new user would be as follows:*/
namespace Task02
{
    public abstract class NotificationService
    {
        public abstract void SendNotification();
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
                }
                smsService.SendNotification();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class MailService : NotificationService
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public bool ValidEmail()
        {
            return Email.Contains("@");
        }        
        public override void SendNotification()
        {
            Console.WriteLine($"Mail:{Email}, Title:{EmailTitle}, Body:{EmailBody}");
        }
    }
    public class SmsService : NotificationService
    {       
        public string Number { get; set; }
        public string SmsText { get; set; }
        public override void SendNotification()
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
