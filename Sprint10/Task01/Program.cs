using System;
/*Following SRP principle, the responsibility of the Customer class should be only the Register method. The Customer class should not worry with the definition of Validation Rules of the Email address and sending messages.

Please change the class Customer and create the class MailService following the SRP principle.*/
namespace Task01
{
    public class Customer
    {
        private MailService mailService;
        public void Register(string email, string password)
        {
            try
            {
                if (mailService.ValidEmail(email))
                {
                    mailService.SendEmail(email, "Email title", "Email body");
                }            
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
    public class MailService
    { 
        public bool ValidEmail(string email)
        {
            return email.Contains("@");
        }
        public void SendEmail(string mail, string emailTitle, string emailBody)
        {
            Console.WriteLine($"Mail:{mail}, Title:{emailTitle}, Body:{emailBody}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MailService ms = new MailService();
            ms.SendEmail("myemail@net.ua", "Say Hello!", "Hello, my dear ..");
            Console.WriteLine("Hello World!");
        }
    }
}
