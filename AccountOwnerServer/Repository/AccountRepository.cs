using Contracts;
using Contracts.Helpers;
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
        private ISortHelper<Account> _sortHelper;

        public AccountRepository(RepositoryContext repositoryContext, ISortHelper<Account> sortHelper) : base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }

        public IEnumerable<Account> GetAccountByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

            //not working
            //_sortHelper.ApplySort(accounts, parameters.OrderBy);


            return PagedList<Account>.ToPagedList(
                accounts,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
