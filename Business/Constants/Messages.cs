using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün Eklendi";
        public static string CarNameInvalid = "Ürün İsmi Geçersiz";
        internal static string CarsListed = "Sistem Bakımda";
        internal static string MaintenanceTime = "Sistem Bakımda";
        internal static string RentalNotAdded="Kayıt Eklenmedi";
        internal static string RentalAdded="Kayıt Eklendi";
        internal static string RentalDeleted="Kayıt Silindi";
        internal static string RentalUpdated = "Kayıt Güncellendi";
        internal static string UsersAdded;
        internal static string UsersDeleted;
        internal static string UsersUpdated;
        internal static string CarImagesAdded= "Yeni Araç Resmi Eklendi";
        public static string AuthorizationDenied = " Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }

}

