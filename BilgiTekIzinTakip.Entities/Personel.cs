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
    [Table("Personel")]
   public class Personel:MyEntityBase
    {
        [DisplayName("Sicil Numarası"),Required(ErrorMessage = "{0} alanı gereklidir.")]

        public int SicilNo { get; set; }


        [DisplayName("Ad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),Required(ErrorMessage = "{0} alanı gereklidir.") ]
        public String Ad { get; set; }

        [DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public String Soyad { get; set; }
        [DisplayName("E-mail")]
        public String Email { get; set; }
        [DisplayName("Dahili Numarası")]
        public String DahiliNumarası { get; set; }


        [DisplayName("Kullanıcı Adı"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public String KullaniciAdı { get; set; }
        [DisplayName("Şifre"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public String Sifre { get; set; }
        



        public virtual Baskanlik BaskanlikID { get; set; }
        public virtual Mudurluk MudurlukID { get; set; }
        public virtual Seflik SeflikID { get; set; }
        
        public virtual List<Izinler> IzinlerId { get; set; }

    }
}
