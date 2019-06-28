using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiTekIzinTakip.Entities
{ [Table("Izinler")]
   public class Izinler :MyEntityBase
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime BaslangicTarihi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime BitisTarihi { get; set; }

       public virtual Personel PersonalID { get; set; }

       public virtual List<IzinTipi> IzinID { get; set; }

    }
}
