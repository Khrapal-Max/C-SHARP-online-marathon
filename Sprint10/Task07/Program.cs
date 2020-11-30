using System;
//An Invoice class might have the responsibility of calculating various amounts based on its data. In that case it probably shouldn’t know about how to retrieve this data from a database, or how to format an invoice for print or display or logging, sending Email etc.

//So in the answer preload you can see Invoice class that contains almost the whole probable logic. This Invoice class has his own responsibility i.e. Add, Delete invoice and also has extra activity like logging and Sending email as well.

//You have to make the refactoring according to the SRP so that Invoice class can happily delegate additional activities to another types.This way Invoice class can concentrate on Invoice related activities.


namespace Task07
{
    public class Invoice
    {        
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public void Add()
        {
            var mailSender = new MailSender();
            Console.WriteLine("Adding amount...");
            // Code for adding invoice
            // Once Invoice has been added , send mail 
            string mailMessage = "Your invoice is ready.";
            mailSender.SendEmail(mailMessage);
        }
        public void Delete()
        {
            Console.WriteLine("Deleting amount...");
            // Code for Delete invoice
        }
    }
    public class MailSender
    { 
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public void SendEmail(string mailMessage)
        {
            Console.WriteLine("Sending Email: {0}", mailMessage);
            // Code for getting Email setting and send invoice mail
        }
    }
    public class FileLogger : IFileLogger
    {
        
    }
    interface IFileLogger
    {
        void Check()
        {
            /// log check result to file
        }
        void Debug()
        {
            /// log debug result to file
        }
        void Info()
        {
            /// log info result to file
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice();
            invoice.Add();
            Console.WriteLine("Hello World!");
        }
    }
}
