using Kursach_TP_Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_TP_Core.Forms.User
{
    internal class User_
    {
        public int CheckDepartment(int index)
        {
            KursachDbContext db = new();

            var departments = db.Departments.ToList();
            foreach (var el in departments)
            {
                if (el.Index == index)
                {
                    if (el.IsOpen)
                        return 1;
                    else
                        return 2;
                }
            }

            return 0;
        }
    }
}