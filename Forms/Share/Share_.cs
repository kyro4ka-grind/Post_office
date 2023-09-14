using Kursach_TP_Core.Context;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_TP_Core
{
    public class Share_
    {
        public bool Registration(string mail, string login, string password)
        {
            KursachDbContext db = new();

            var users = db.Users.ToList();
            foreach (var user in users)
            {
                if (user.Mail == mail || user.Login == login)
                    return false;
            }

            db.Users.Add(new User { Login = login, Mail = mail, Password = password});
            db.SaveChanges();
            return true;
        }

        public int Login(string login, string password)
        {
            KursachDbContext db = new();

            //Авторизация пользователей
            var users = db.Users.ToList();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                    return 0;
            }

            //Авторизация работников
            var workers = db.Workers.ToList();
            foreach (var worker in workers)
            {
                if (worker.Login == login && worker.Password == password)
                    return worker.Role;
            }

            return -1;
        }

        public string CheckPackage(string packNum)
        {
            KursachDbContext db = new();
            string result = "";

            var packages = db.Packages.ToList();
            foreach (var package in packages)
            {
                if (package.IdPack == packNum)
                {
                    result = "Ваша посылка:\n" + "Id: " + package.IdPack + "\nПолучатель: "
                        + package.Surname + " " + package.Name;

                    switch (package.Status)
                    {
                        case 0:
                            result += "\nВаша посылка принята в отделение.";
                            break;
                        case 1:
                            result += "\nВаша посылка принята в доставке.";
                            break;
                        case 2:
                            result += "\nВаша посылка доставлена.";
                            break;
                        case 3:
                            result += "\nВаша посылка выдана.";
                            break;
                    }

                    //Получаем фамилию и имя получателя
                    var senders = db.Senders.ToList();
                    foreach (var sender in senders)
                    {
                        if (sender.PassportNum == package.Sender)
                        {
                            result += "\nОтправитель: " + sender.Surname + " " + sender.Name;
                            break;
                        }
                    }

                    //Получаем место отправления и место получения
                    var places = db.Places.ToList();
                    foreach (var place in places)
                    {
                        if (place.Id == package.IdPlaceIn)
                        {
                            result += "\nМесто получения: " + place.Country + " " + place.Town + " " + place.Index;
                            break;
                        }
                    }

                    foreach (var place in places)
                    {
                        if (place.Id == package.IdPlaceOut)
                        {
                            result += "\nМесто отправления: " + place.Country + " " + place.Town + " " + place.Index;
                            break;
                        }
                    }
                    break;
                }
            }
            return result;
        }
    }
}
