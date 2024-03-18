using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetProject_1.Models
{
    public class PortletContext : DbContext
    {
        public DbSet<GlobalModule> GlobalModules { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class PortletDbInitializer : DropCreateDatabaseAlways<PortletContext>
    {
        protected override void Seed(PortletContext db)
        {
            var user1 = new User { FullName = "Громов Платон Ильич", Uid = "0DA5ADBA-4D04-4656-9125-38ADFBA97DEC" };
            var user2 = new User { FullName = "Петров Петр Петрович", Uid = "29E58F77-1C62-43D1-BC7F-96D9039B2D9D" };

            db.Users.Add(user1);
            db.Users.Add(user2);

            db.GlobalModules.Add(new GlobalModule { Name = "Глобальный модуль 1", Uid = "110C96CA-4F0D-4B08-8795-4445A0E2DD86", UsingUser = user1 });
            db.GlobalModules.Add(new GlobalModule { Name = "Глобальный модуль 2", Uid = "63CD4421-A71B-44D2-AE25-4B28297242FC", UsingUser = user2 });



            base.Seed(db);
        }
    }
}