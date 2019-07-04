using BilgiTekIzinTakip.BusinessLayer.Abstract;
using BilgiTekIzinTakip.BusinessLayer.Result;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.Entities.Messages;
using BilgiTekIzinTakip.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BilgiTekIzinTakip.BusinessLayer
{
    public class PersonelManager:ManagerBase<Personel>
    {
        public BusinessLayerResult<Personel> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi?
            BusinessLayerResult<Personel> res = new BusinessLayerResult<Personel>();
            res.Result = Find(x => x.KullaniciAdi == data.Username);

            if (res.Result != null)
            {
                if (!res.Result.IsAdmin)
                {
                    res.AddError(ErrorMessageCode.UserIsNotAdmin, "Kullanıcı yönetici yetkisine sahip değildir.");
                }
                else
                {
                    bool verify = Crypto.VerifyHashedPassword(res.Result.Sifre, data.Password);
                    if (!verify)
                    {
                        res.AddError(ErrorMessageCode.PasswordWrong,"Şifrenizi Hatalı Girdiniz");
                    }
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameWrong, "Böyle Bir Kullanıcı Yok veya Kullanıcı Adınızı Hatalı Girdiniz.");
            }

            return res;
        }
    }
}
