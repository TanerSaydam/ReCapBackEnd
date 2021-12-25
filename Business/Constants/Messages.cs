using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarDeleted = "Araba Silindi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandDeleted = "Marka Silindi.";

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string ColorDeleted = "Renk Silindi.";

        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";

        public static string RentalAdded = "Araç Kiralama Oluşturuldu.";
        public static string RentalUpdated = "Araç Kiralama Güncellendi.";
        public static string RentalDeleted = "Araç Kiralama Silindi.";

        public static string CarImageAdded = "Araç Resmi Eklendi";
        public static string CarImageUpdated = "Araç Resmi Güncellendi.";
        public static string CarImageDeleted = "Araç Resmi Silindi.";
        public static string CarImageExtended = "Araç Resmi Sayısı En Fazla 5 Olabilir.";

        public static string AuthorizationDenied = "İşlem yapmaya yetkiniz yok";

        public static string UserRegistered = "Kullanıcı kayıtı oluşturuldu";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu bilgilere ait bir kullanıcı var";
        public static string AccessTokenCreated = "Token oluşturuldu";        
    }
}
