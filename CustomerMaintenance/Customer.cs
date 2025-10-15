using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    internal class Customer
    {
    }

    public record struct theCusomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string GetDisplayText(string sep) => $"{FirstName} {LastName}: {Email}";

        public object CustomerInfo(string firstName, string lastName, string email) => (this.FirstName, this.LastName, this.Email) = (firstName, lastName, email);
    }
}
