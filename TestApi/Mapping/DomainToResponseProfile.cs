using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Contracts.Response;
using TestApi.Domain;

namespace TestApi.Mapping
{
    public class DomainToResponseProfile :Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Customers, CustomerResponse>();
        }
    }
}
