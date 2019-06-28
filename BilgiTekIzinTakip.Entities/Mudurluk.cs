using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Entities
{
    public class Mudurluk
    {
        public String Isim { get; set; }

        public virtual Baskanlik BaskanlikID { get; set; }
    }
}
