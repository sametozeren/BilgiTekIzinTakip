using BilgiTekIzinTakip.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BilgiTekIzinTakip.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            
            Personel admin = new Personel()
            {

                SicilNo = FakeData.NumberData.GetNumber(8),
                Ad = "Nuray",
                Soyad = "Bilmiyorum",
                Email = "bilmiyorum@gmail.com",
                DahiliNumarasi = "2007",
                KullaniciAdi = "nuray",
                Sifre = Crypto.HashPassword("123"),
                IsAdmin = true,
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "nuray",
            };
            context.Personel.Add(admin);
            context.SaveChanges();
            IzinTipi tip = new IzinTipi()
            {
                IzinTuru = "Günlük",
                RenkKodu = "#000",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "nuray",
            };
            context.IzinTipi.Add(tip);
            context.SaveChanges();
            IzinTipi tip2 = new IzinTipi()
            {
                IzinTuru = "Saatlik",
                RenkKodu = "#000",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "nuray",
            };
            context.IzinTipi.Add(tip2);
            context.SaveChanges();

            for (int i = 0; i < 5; i++)
            {
                Baskanlik bas = new Baskanlik()
                {
                    Isim = FakeData.NameData.GetCompanyName(),
                    CreatedOn = DateTime.Now.AddHours(1),
                    ModifiedOn = DateTime.Now.AddMinutes(65),
                    ModifiedUsername = "nuray"
                };
                context.Baskanlik.Add(bas);
                context.SaveChanges();
                Mudurluk mud = new Mudurluk()
                {
                    Isim = FakeData.NameData.GetCompanyName(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "nuray",
                    Baskanlik = bas,
                };
                context.Mudurluk.Add(mud);
                context.SaveChanges();
                Seflik sef = new Seflik()
                {
                    Isim = FakeData.NameData.GetCompanyName(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "nuray",
                    Baskanlik = bas,
                    Mudurluk = mud,
                };
                context.Seflik.Add(sef);
                context.SaveChanges();
                Personel calisan = new Personel()
                {
                    SicilNo = FakeData.NumberData.GetNumber(8),
                    Ad = FakeData.NameData.GetFirstName(),
                    Soyad = FakeData.NameData.GetSurname(),
                    Email = "bilmiyorum@gmail.com",
                    DahiliNumarasi = "2007",
                    KullaniciAdi = FakeData.NameData.GetFirstName()+FakeData.NameData.GetSurname(),
                    Sifre = "123",
                    IsAdmin = false,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "nuray",
                    Baskanlik=bas,
                    Mudurluk=mud,
                    Seflik=sef,
                };
                context.Personel.Add(calisan);
                context.SaveChanges();
                for (int j = 0; j < 2; j++)
                {
                    Izinler mola = new Izinler()
                    {
                        BaslangicTarihi =DateTime.Now,
                        BitisTarihi = DateTime.Now.AddDays(1),
                        Personel = calisan,
                        IzinTipi = tip,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        ModifiedUsername = "nuray",
                    };
                    context.Izinler.Add(mola);
                    Izinler mola2 = new Izinler()
                    {
                        BaslangicTarihi = DateTime.Now,
                        BitisTarihi = DateTime.Now.AddDays(1),
                        Personel = calisan,
                        IzinTipi = tip2,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        ModifiedUsername = "nuray",
                    };
                    context.Izinler.Add(mola2);
                }
                context.SaveChanges();
            }
            



            /*
            // Adding admin user..
            Personel admin = new Personel()
            {
                
                SicilNo = FakeData.NumberData.GetNumber(8),
                Ad = "Nuray",
                Soyad="Bilmiyorum",
                Email="bilmiyorum@gmail.com",
                DahiliNumarasi="2007",
                KullaniciAdi="nuray",
                Sifre="123",
                IsAdmin=true,
                CreatedOn=DateTime.Now.AddHours(1),
                ModifiedOn=DateTime.Now.AddMinutes(65),
                ModifiedUsername="nuray",

            };*/

        }
    }
}
