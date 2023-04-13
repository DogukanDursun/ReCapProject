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
        public static string CarsListed = "Sistem Bakımda";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string RentalNotAdded="Kayıt Eklenmedi";
        public static string RentalAdded="Kayıt Eklendi";
        public static string RentalDeleted="Kayıt Silindi";
        public static string RentalUpdated = "Kayıt Güncellendi";
        public static string UsersAdded="Kullanıcı Eklendi";
        public static string UsersDeleted="Kullanıcı Silindi";
        public static string UsersUpdated="Kullanıcı Güncellendi";
        public static string CarImagesAdded= "Yeni Araç Resmi Eklendi";
        public static string AuthorizationDenied = " Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string CarNameAlreadyExists="Araba Adı Zaten Var";
        public static string CarCountOfCategoryError="Bu Kategoriye Çok Fazla Araç Eklediniz";
        public static string CarUpdated="Araba Güncellendi";
        internal static string SuccesAdded="Ekleme Başarılı";
        internal static string SuccesDeleted;
        internal static string SuccesUpdated;
        internal static string CarDetails;
        internal static string CarGetAll;
        internal static string CarListed;
        internal static string ThisCarIsAlreadyRentedInSelectedDateRange;
        internal static string CarDeleted;
    }

}

