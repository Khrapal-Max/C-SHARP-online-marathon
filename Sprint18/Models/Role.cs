using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskAuthenticationAuthorization.Models
{

    public class Role
    {         
        public int Id { get; set; }

        [Display(Name = "Role name")]
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>() ;
        }        
    }
}
