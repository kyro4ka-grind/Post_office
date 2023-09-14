using Kursach_TP_Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_TP_Core.Forms.Postman
{
    internal class Postman_
    {
        //Изменение статуса посылки на принято к доставке
        public bool PackageInDelivered(string packId)
        {
            KursachDbContext db = new();
            var packages = db.Packages.ToList();

            foreach (var package in packages)
            {
                if (package.IdPack == packId)
                {
                    package.Status = 1;
                    db.Update(package);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        //Изменение статуса посылки на доаставлено
        public bool PackageDelivered(string packId)
        {
            KursachDbContext db = new();
            var packages = db.Packages.ToList();

            foreach (var package in packages)
            {
                if (package.IdPack == packId)
                {
                    package.Status = 2;
                    db.Update(package);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}