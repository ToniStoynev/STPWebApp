namespace STPTask.Domain
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class STPUser : IdentityUser
    {
        public STPUser()
        {
            this.Companies = new HashSet<Company>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Company> Companies{ get; set; }
    }
}
