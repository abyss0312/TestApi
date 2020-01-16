using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
      
        public static class Customers
        {
            public const string GetAll = Base + "/customers";
            public const string Get = Base + "/customer/{customerId}";
            public const string Create = Base + "/Addcustomers";
            public const string Delete = Base + "/DeleteCustomer";
            public const string Update = Base + "/UpdateCustomer";
        }
        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string register = Base + "/identity/register";
        }
    }
}
