using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AccountRepository: RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }

        public IEnumerable<Account> GetAccountByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

            return PagedList<Account>.ToPagedList(
                accounts,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
