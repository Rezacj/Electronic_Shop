using MyEShop_Core8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MyEShop_Core8.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }
    public class GroupRepository : IGroupRepository
    {
        private MyEShopContext _context;

        public GroupRepository(MyEShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return (from c in _context.categories
                    select new ShowGroupViewModel
                    {
                        GroupId = c.id,
                        Name = c.name,
                        ProductCount = (from g in _context.categoryToProducts
                                        where g.Categoryid == c.id
                                        select g).Count()
                    }).ToList();

        }
    }
}
