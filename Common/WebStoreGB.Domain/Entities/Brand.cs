using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Base;
using WebStoreGB.Domain.Entities.Base.Interfaces;

namespace WebStoreGB.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
