using System.Collections;
using System.Collections.Generic;
using WebStoreGB.Domain.ViewModels;

namespace WebStoreGB.ViewModels
{
    public class SelectableSectionsViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }

        public int? SectionId { get; set; }

        public int? ParentSectionId { get; set;}
    }
}
