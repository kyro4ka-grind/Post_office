using Kursach_TP_Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_TP_Core.Forms.Operator
{
    internal class Operator_
    {
        public int CheckPackageStatus(string packId)
        {
            KursachDbContext db = new();

            var packages = db.Packages.ToList();
            foreach (var package in packages)
            {
                if (package.IdPack == packId)
                    return package.Status;
            }

            return -1;
        }

        public void NewPackage(string countryOut, string townOut, int indexOut,
            string countryIn, string townIn, int indexIn, string surnameSender,
            string nameSender, int pasport, long phone, string surnameReceiver, string nameReceiver)
        {
            KursachDbContext db = new();
            int lastIdPlace = db.Places.ToList().Last().Id;
            int idOut = 0, idIn = 0;

            //Проверка мест в базе
            var places = db.Places.ToList();
            bool flagOut = false, flagIn = false;
            foreach (var place in places)
            {
                if (place.Index == indexOut)
                {
                    flagOut = true;
                    idOut = place.Id;
                }
                if (place.Index == indexIn)
                {
                    flagIn = true;
                    idIn = place.Id;
                }
            }

            //Добавление новых мест
            if (!flagOut)
            {
                Place placeOut;
                lastIdPlace++;
                idOut = lastIdPlace;
                placeOut = new() { Id = idOut, Country = countryOut, Town = townOut, Index = indexOut };
                db.Places.Add(placeOut);
                db.SaveChanges();
            }
            if (!flagIn)
            {
                Place placeIn;
                lastIdPlace++;
                idIn = lastIdPlace;
                placeIn = new() { Id = lastIdPlace, Country = countryIn, Town = townIn, Index = indexIn };
                db.Places.Add(placeIn);
                db.SaveChanges();
            }

            //Проверка отправителя в базе
            var senders = db.Senders.ToList();
            bool flagSender = false;
            foreach (var sender in senders)
            {
                if (sender.PassportNum == pasport)
                    flagSender = true;
            }

            //Добавление нового пользователя
            if (!flagSender)
            {
                Sender sender = new Sender() { Name = nameSender, Surname = surnameSender, PassportNum = pasport, PhoneNum = phone};
                db.Senders.Add(sender);
                db.SaveChanges();
            }

            //Добавление посылки
            string lastIdPackage = (int.Parse(db.Packages.ToList().Last().IdPack) + 1).ToString();

            Package pack = new()
            {
                IdPack = lastIdPackage,
                IdPlaceOut = idOut,
                IdPlaceIn = idIn,
                Sender = pasport,
                Name = nameReceiver,
                Surname = surnameReceiver,
                Status = 0
            };
            db.Packages.Add(pack);
            db.SaveChanges();
        }

        //Изменение статуса посылки на выдано
        public bool PackageIssued(string packId)
        {
            KursachDbContext db = new();
            var packages = db.Packages.ToList();

            foreach (var package in packages)
            {
                if (package.IdPack == packId)
                {
                    package.Status = 3;
                    db.Update(package);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}