using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiTekIzinTakip.Entities
{ [Table("Izinler")]
   public class Izinler :MyEntityBase
    {
        [Required]
        public DateTime BaşlangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

       public virtual Personal PersonalID { get; set; }

       public virtual IzinTipi IzinID { get; set; }

    }
}
