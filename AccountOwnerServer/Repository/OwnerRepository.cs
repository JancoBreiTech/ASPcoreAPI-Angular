using Contracts;
using Entities;
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
        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            return await FindAll()
                .OrderBy(ow => ow.Name)
                .ToListAsync();
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId))
                .FirstOrDefaultAsync();
        }

        //Add mappings to MappingProfile
        public async Task<Owner> GetOwnerWithDetails(Guid ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId))
                .Include(acc => acc.Accounts)
                .FirstOrDefaultAsync();
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
