using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OZI_lab1
{
    class UserCopyContext:DbContext
    {
        public UserCopyContext()
            : base("DbCopyConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}
