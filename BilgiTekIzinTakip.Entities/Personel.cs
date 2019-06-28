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
        public string Ad { get; set; }
        [DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Soyad { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Dahili Numarası")]
        public string DahiliNumarasi { get; set; }
        [DisplayName("Kullanıcı Adı"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string KullaniciAdi { get; set; }
        [DisplayName("Şifre"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Sifre { get; set; }
        public virtual Baskanlik Baskanlik { get; set; }
        public virtual Mudurluk Mudurluk { get; set; }
        public virtual Seflik Seflik { get; set; }
        public virtual List<Izinler> Izinler { get; set; }

    }
}
