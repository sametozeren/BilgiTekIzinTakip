using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Entities
{
    [Table("Personal")]
   public class Personal:MyEntityBase
    {
        public int SicilNo { get; set; }


        [DisplayName("Ad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public String Ad { get; set; }

        public String Soyad { get; set; }

        public String Email { get; set; }

        public String DahiliNumarası { get; set; }

        public virtual Baskanlik BaskanlikID { get; set; }

        public virtual Mudurluk MudurlukID { get; set; }

        public virtual Seflik SeflikID { get; set; }

        public String KullaniciAdı { get; set; }

        public String Sifre { get; set; }

    }
}
