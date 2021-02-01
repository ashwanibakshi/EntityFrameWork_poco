using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.dto;

namespace WindowsFormsApplication1
{
    public class empDBContext:DbContext
    {
        public DbSet<department> departments { get; set; }
        public DbSet<employee> employees { get; set; }
    }
}
