using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Identity;

namespace WebStoreGB.Interfaces.Services.Identity
{
    public interface IRolesClient: IRoleStore<Role>
    {

    }
}
