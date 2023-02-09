using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.ViewModels;

namespace WebStoreGB.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _ProdctData;
        public SectionsViewComponent(IProductData productData) { _ProdctData = productData; }
        public IViewComponentResult Invoke(string SectionId)
        {
            var section_id = int.TryParse(SectionId, out var id) ? id : (int?)null;


            var sections = GetSections(section_id, out var parent_section_id);
            return View(new SelectableSectionsViewModel
            {
                Sections = sections,
                SectionId = section_id,
                ParentSectionId = parent_section_id,
            });
        }

        private IEnumerable<SectionViewModel> GetSections(int? SectionId, out int? ParentSectionId)
        {
            ParentSectionId = null;

            var sections = _ProdctData.GetSections();
            var parent_sections = sections.Where(x => x.ParentId is null);

            var parent_sections_views = parent_sections
                .Select(x => new SectionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Order = x.Order,
                }).ToList();

            foreach (var parent_section in parent_sections_views)
            {
                var childs = sections.Where(x => x.ParentId == parent_section.Id);
                foreach (var child_section in childs)
                {
                    if (SectionId == child_section.Id)
                        ParentSectionId = child_section.ParentId;

                    parent_section.ChildSections
                        .Add(new SectionViewModel
                        {
                            Id = child_section.Id,
                            Name = child_section.Name,
                            Order = child_section.Order,
                            Parent = parent_section
                        });
                }

                parent_section.ChildSections.Sort((a, b)
                    => Comparer<int>.Default.Compare(a.Order, b.Order));
            }

            parent_sections_views.Sort((a, b)
                    => Comparer<int>.Default.Compare(a.Order, b.Order));
            return parent_sections_views;
        }
    }
}
