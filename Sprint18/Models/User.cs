using System.ComponentModel.DataAnnotations;

namespace TaskAuthenticationAuthorization.Models
{

    public class User
    {
        public enum BuyerType
        {
            None, Regular, Golden, Wholesale
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Display(Name = "Role name")]
        public int? RoleId { get; set; }

        public Role Role { get; set; }

        public Customer Customer { get; set; }

        public BuyerType Type { get; set; } = BuyerType.Regular;
    }
}
