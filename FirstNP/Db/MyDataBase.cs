using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FirstNP.Db
{
    class MyDataBase : DbContext
    {
        public DbSet<Adreses> Mies { get; set; }
        public MyDataBase() : base(ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString)
        {

        }
    }
}
