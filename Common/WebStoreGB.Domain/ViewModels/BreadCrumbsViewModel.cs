using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities;

namespace WebStoreGB.Domain.ViewModels
{
    public class BreadCrumbsViewModel
    {
        public Section Section { get; set; }
        public Brand Brand { get; set; }
        public string Product { get; set; }
    }
}
