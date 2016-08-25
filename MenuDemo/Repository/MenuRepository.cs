using System.Data.Entity;
using MenuDemo.Models;

namespace MenuDemo.Repository
{
    public class MenuRepository : Repository<MenuItem>
    {
        public MenuRepository(DbContext objectContext)
            : base(objectContext)
        {
        }
        public MenuRepository() : this(new MenuDatabaseEntities())
        {
        }
    }
}