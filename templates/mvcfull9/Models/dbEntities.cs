using Microsoft.EntityFrameworkCore;

namespace mvcfull9.Models
{
    public partial class dbEntities : Microsoft.EntityFrameworkCore.DbContext
    {
        public dbEntities()
        {

        }
        public dbEntities(DbContextOptions<dbEntities> options) : base(options)
        {

        }
    }
}
