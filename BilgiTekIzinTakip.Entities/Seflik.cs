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
    [Table("Seflik")]
    public class Seflik:MyEntityBase
    {

        [DisplayName("Şeflik İsmi"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Isim { get; set; }
        public int BaskanlikId { get; set; }
        public int? MudurlukId { get; set; }
        public virtual Baskanlik Baskanlik { get; set; }
        public virtual Mudurluk Mudurluk{ get; set; }
        public virtual List<Personel> Personel { get; set; }
    }
}
