using Contracts;
using Contracts.Helpers;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository: RepositoryBase<Owner>, IOwnerRepository
    {
        private ISortHelper<Owner> _sortHelper;
        public OwnerRepository(RepositoryContext repositoryContext, ISortHelper<Owner> sortHelper) : base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }

        

        //Second add here
        //then go to Controller
        public PagedList<Owner> GetAllOwners(OwnerParameters ownerParameters)
        {
            //filtering Date of births
            var owners = FindByCondition(o => o.DateOfBirth.Year >= ownerParameters.MinYearOfBirth &&
                                                o.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth);
                        

            //search for name
            SearchByName(ref owners, ownerParameters.Name);

            //sort not working
           // _sortHelper.ApplySort(owners, ownerParameters.OrderBy);

            //pagination
            return PagedList<Owner>.ToPagedList(owners,
                ownerParameters.PageNumber,
                ownerParameters.PageSize);                
        }

        private void SearchByName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;

            if (string.IsNullOrEmpty(ownerName))
                return;

            owners = owners.Where(o => o.Name.ToLowerInvariant().Contains(ownerName.Trim().ToLowerInvariant()));
            
        }

       

        public Owner GetOwnerById(Guid ownerId)
        {
            return  FindByCondition(o => o.Id.Equals(ownerId))
                .DefaultIfEmpty(new Owner())
                .FirstOrDefault();
        }

        //Add mappings to MappingProfile
        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(o => o.Id.Equals(ownerId))
                .Include(acc => acc.Accounts)
                .FirstOrDefault();
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}
