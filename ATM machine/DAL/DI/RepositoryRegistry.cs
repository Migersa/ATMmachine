using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Contracts;
using Lamar;

namespace DAL.DI
{
    public class RepositoryRegistry : ServiceRegistry
    {
        public RepositoryRegistry()
        {

            IncludeRegistry<UnitOfWorkRegistry>();
            For<ICreditCardRepository>().Use<CreditCardRepository>();
            For<IDepositRepository>().Use<DepositRepository>();
            For<IWithdrawRepository>().Use<WithdrawRepository>();

           //   For<IUserRepository>().Use<UserRepository>();
        }


    }
}
