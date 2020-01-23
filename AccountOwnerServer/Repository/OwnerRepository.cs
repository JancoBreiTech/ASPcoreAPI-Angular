using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository: RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }

        //Second add here
        //then go to Controller
        public PagedList<Owner> GetAllOwners(OwnerParameters ownerParameters)
        {
            //pagination
            return PagedList<Owner>.ToPagedList(FindAll().OrderBy(on => on.Name),
                ownerParameters.PageNumber, ownerParameters.PageSize);                
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
