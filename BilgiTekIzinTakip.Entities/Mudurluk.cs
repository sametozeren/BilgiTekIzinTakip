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

    [Table("Mudurluk")]
    public class Mudurluk:MyEntityBase
    {
        [DisplayName("İsim"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Isim { get; set; }
        public List<Personel> Personel { get; set; }
        public virtual Baskanlik Baskanlik { get; set; }
        public virtual List<Seflik> Seflik { get; set; }
    }
}
