using System;

namespace Models
{
    internal static class DatabaseContextInitializer
    {
        static DatabaseContextInitializer()
        {

        }

        internal static void Seed(DatabaseContext databaseContext)
        {
            Guid roleId = Guid.NewGuid();

            InsertBaseRole(databaseContext, roleId);
            InsertBaseUser(databaseContext, roleId);
            databaseContext.SaveChanges();
        }


        internal static void InsertBaseRole(DatabaseContext databaseContext, Guid roleId)
        {
            Role role = new Role()
            {
                Id = roleId,
                Title = "مدیر وب سایت",
                Name = "Administrator",
                CreationDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
            };

            databaseContext.Roles.Add(role);
        }

        internal static void InsertBaseUser(DatabaseContext databaseContext, Guid roleId)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                CellNum = "09124806404",
                Password = "zavosh327056",
                CreationDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                FullName = "admin",
            };

            databaseContext.Users.Add(user);
        }


    }
}
