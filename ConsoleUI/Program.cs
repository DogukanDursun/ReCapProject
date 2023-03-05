using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager();
            //UsersAdd();

        }

        private static void UsersAdd()
        {
            UsersManager user1 = new UsersManager(new EfUsersDal());
            Console.WriteLine(user1.Add(new Users
            {
                FirstName = "Doğukan",
                LastName = "Dursun",
                Email = "dogukandursun@gmail.com",
                Password = "12345"
            }).Message);
            Console.ReadLine();
        }

        private static void CarManager()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice + " TL");

                }
            }
            else
                Console.WriteLine(result.Message);
        }
    }
}
