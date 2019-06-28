using BilgiTekIzinTakip.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        //dbsetler
        public DbSet<Baskanlik> Baskanlik { get; set; }
        public DbSet<Mudurluk> Mudurluk { get; set; }
        public DbSet<Seflik> Seflik { get; set; }
        public DbSet<Izinler> Izinler { get; set; }
        public DbSet<IzinTipi> IzinTipi { get; set; }

        public DbSet<Personel> Personel { get; set; }


        //public DatabaseContext()
        //{
        //    Database.SetInitializer(new MyInitializer());
        //}
    }
}
