using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OwnerDTO
    {
        //only add properties we want to show the client
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        //get info for joining table
        //Modify interface
        public IEnumerable<AccountDTO> Accounts { get; set; }
    }
}
