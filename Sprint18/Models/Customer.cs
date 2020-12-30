using System.Collections.Generic;

namespace TaskAuthenticationAuthorization.Models
{
    public enum Discount
    {
        O, R, V
    }
    public class Customer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<Order> Orders { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
