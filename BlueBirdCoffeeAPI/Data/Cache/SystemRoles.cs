using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Cache
{
    public class SystemRoles
    {
        public const string ADMIN = "ADMIN";
        public const string CASHIER = "CASHIER";
        public const string BARTENDER = "BARTENDER";
        public const string EMPLOYEE = "EMPLOYEE";
        public const string CUSTOMER = "CUSTOMER";
        public const string EXCEPT_CUSTOMER = "ADMIN, CASHER, BARTENDER, EMPLOYEE";
    }
}
