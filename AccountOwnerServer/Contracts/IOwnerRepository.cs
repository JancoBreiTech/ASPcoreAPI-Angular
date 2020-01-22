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
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);

        Owner GetOwnerWithDetails(Guid ownerId);

        void CreateOwner(Owner owner);

        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
