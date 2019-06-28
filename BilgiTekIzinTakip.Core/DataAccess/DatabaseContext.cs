using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Core.DataAccess
{
    public class DatabaseContext : DbContext
    {
        //dbsetler

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
