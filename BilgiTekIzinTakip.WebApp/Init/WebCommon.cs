using BilgiTekIzinTakip.Common;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgiTekIzinTakip.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            Personel user = CurrentSession.User;

            if (user != null)
                return user.KullaniciAdi;
            else
                return "system";
        }
    }
}