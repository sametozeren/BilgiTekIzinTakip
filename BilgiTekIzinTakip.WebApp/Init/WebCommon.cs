using BilgiTekIzinTakip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgiTekIzinTakip.WebApp.Init
{
    public class WebCommon : ICommon
    {
        /* örnekkk kullanıcı session kontrolu
        public string GetCurrentUsername()
        {
            EvernoteUser user = CurrentSession.User;

            if (user != null)
                return user.Username;
            else
                return "system";
        }
        */
        public string GetCurrentUsername()
        {
            throw new NotImplementedException();
        }
    }
}