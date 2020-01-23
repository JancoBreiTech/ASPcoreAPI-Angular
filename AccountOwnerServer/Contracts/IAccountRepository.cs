using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
        IEnumerable<Account> GetAccountByOwner(Guid Id);
        PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters);
    }
}
