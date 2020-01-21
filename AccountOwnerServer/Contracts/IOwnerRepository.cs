using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOwnerRepository: IRepositoryBase<Owner>
    {
        //First Add here
        //Then Go to Repository
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(Guid ownerId);

        Task<Owner> GetOwnerWithDetails(Guid ownerId);

        void CreateOwner(Owner owner);

        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
