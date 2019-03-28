using System.Data.Entity;
using System.Configuration;

namespace FirstNP.Db
{
    public class MyDataBase : DbContext
    {
        public DbSet<Adreses> Mies { get; set; }
        public MyDataBase() : base(ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString)
        {

        }
    }
}
