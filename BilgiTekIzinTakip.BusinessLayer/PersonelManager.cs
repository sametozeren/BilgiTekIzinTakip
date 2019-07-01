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

namespace BilgiTekIzinTakip.BusinessLayer
{
    public class PersonelManager:ManagerBase<Personel>
    {
        public BusinessLayerResult<Personel> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi?
            BusinessLayerResult<Personel> res = new BusinessLayerResult<Personel>();
            res.Result = Find(x => x.KullaniciAdi == data.Username && x.Sifre == data.Password);

            if (res.Result != null)
            {
                if (!res.Result.IsAdmin)
                {
                    res.AddError(ErrorMessageCode.UserIsNotAdmin, "Kullanıcı yönetici yetkisine sahip değildir.");
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı yada şifre uyuşmuyor.");
            }

            return res;
        }
    }
}
