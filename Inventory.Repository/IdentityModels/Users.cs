using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.IdentityModels
{
    public class Users : IdentityUser<int>
    {
        public ICollection<Roles> Roles { get; set; }
    }
}
