using System;
//Let 's look at answer box preload. 

//You have a class Invoice here with a simple InvoiceType property. This property decided if this is a “Final” Or “Proposed” invoice. Depending on the same it calculates discount.  

//Have a look at the GetDiscount() method which returns discount accordingly to the value of InvoiceType property .

//The problem is if we add a new invoice type RecurringInvoice with the 10% discount, we need to go and add one more “IF” condition in the GetDiscount() method.In other words we need to change the Invoice class.

//Among all a client wants to know the ordinary discount 1% of amount in times of season sale.

//If we are changing the Invoice class again and again, we need to ensure that the previous conditions with new one’s are tested again , existing client’s which are referencing this class are working properly as before.  So whatever is the current code they are untouched and we just need to test and check the new classes.

//Let’s refactor the solution.
namespace Task08
{
    abstract class Invoice
    {
        public abstract double GetDiscount(double sum);
    }
    class FinalInvoice : Invoice
    {
        public override double GetDiscount(double sum)
        {
            return sum -= sum * 0.03;
        }
    }
    class ProposedInvoice : Invoice
    {
        public override double GetDiscount(double sum)
        {
            return sum -= sum * 0.05;
        }
    }
    class RecurringInvoice : Invoice
    {
        public override double GetDiscount(double sum)
        {
            return sum -= sum * 0.1;
        }
    }
    class OrdinaryInvoice : Invoice
    {
        public override double GetDiscount(double sum)
        {
            return sum -= sum * 0.01;
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
