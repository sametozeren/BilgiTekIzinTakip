﻿using BilgiTekIzinTakip.Core.DataAccess;
using BilgiTekIzinTakip.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BilgiTekIzinTakip.BusinessLayer
{
    public class Test
    {
        public Test()
        {
            DatabaseContext db = new DatabaseContext();
            db.Baskanlik.ToList();
        }

    }
}
