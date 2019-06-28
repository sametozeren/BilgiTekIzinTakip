﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Entities
{

    [Table("Baskanlik")]
    public class Baskanlik :MyEntityBase
    {
        [DisplayName("İsim"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public String Isim { get; set; }
    }
}
