using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Entities
{ [Table("Seflik")]
    public class Seflik
    {

        [DisplayName("İsim"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public String Isim { get; set; }
       
        public virtual Baskanlik BaskanlikID { get; set; }
  
        public virtual Mudurluk MudurlukID { get; set; }


    }
}
