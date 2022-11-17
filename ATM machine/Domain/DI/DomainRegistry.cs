using DAL.DI;
using Domain.Concrete;
using Domain.Contracts;
using Lamar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DI
{
    public class DomainRegistry : ServiceRegistry
    {
        public DomainRegistry()
        {
            
            IncludeRegistry<DomainUnitOfWorkRegistry>();
          For<ICreditCardDomain>().Use<CreditCardDomain>();


            For<IWithdrawDomain>().Use<WithdrawDomain>();

            For<IDepositDomain>().Use<DepositDomain>();
            //  For<IUserDomain>().Use<UserDomain>();
            
            AddRepositoryRegistries();
            AddHttpContextRegistries();
        }

        private void AddRepositoryRegistries()
        {
            IncludeRegistry<RepositoryRegistry>();
        }

        private void AddHttpContextRegistries()
        {
            For<IHttpContextAccessor>().Use<HttpContextAccessor>();
        }
    }
}
