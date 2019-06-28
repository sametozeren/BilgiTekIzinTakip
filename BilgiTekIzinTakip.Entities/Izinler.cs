using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiTekIzinTakip.Entities
{
   [Table("Izinler")]
   public class Izinler:MyEntityBase
   {
        [DisplayName("İzin Başlangıç Tarihi"),Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime BaslangicTarihi { get; set; }
        [DisplayName("İzin Bitiş Tarihi"),Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime BitisTarihi { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual IzinTipi IzinTipi { get; set; }

   }
}
