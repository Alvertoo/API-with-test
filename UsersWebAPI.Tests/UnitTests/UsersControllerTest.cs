using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nito.AsyncEx;
using System.Linq;
using System.Threading.Tasks;
using UsersWebAPI.Controllers;
using UsersWebAPI.Data;
using UsersWebAPI.Models;

namespace UsersWebAPI.Tests.UnitTests
{
    [TestClass]
    public class UsersControllerTest
    {

        [TestMethod]
        public void GetUsersTest1()
        {
            DbContextOptions<UsersWebAPIContext> contextOptions;
            contextOptions = new DbContextOptionsBuilder<UsersWebAPIContext>().UseInMemoryDatabase("TestDatabase").Options;
            using (var context = new UsersWebAPIContext(contextOptions))
            {
                // Prepare data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //// Insert seed data into the database using one instance of the context

                context.User.Add(new User { Nick = "User 1", Name = "Name1", Address = "Address1", Tlf = 123 });
                context.User.Add(new User { Nick = "User 2", Name = "Name2", Address = "Address2", Tlf = 123 });
                context.User.Add(new User { Nick = "User 3", Name = "Name3", Address = "Address3", Tlf = 123 });
                context.SaveChanges();

                // Test controller
                UsersController controller = new UsersController(context);

                var users = controller.GetUser().Result.Value.ToList();

                Assert.AreEqual(3, users.Count());
                Assert.AreEqual("Name1", users[0].Name);
                Assert.AreEqual("Name2", users[1].Name);
                Assert.AreEqual("Name3", users[2].Name);
            }
        }


        [TestMethod]
        public void GetUserTest1()
        {
            DbContextOptions<UsersWebAPIContext> contextOptions;
            contextOptions = new DbContextOptionsBuilder<UsersWebAPIContext>().UseInMemoryDatabase("TestDatabase").Options;
            using (var context = new UsersWebAPIContext(contextOptions))
            {
                // Prepare data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //// Insert seed data into the database using one instance of the context

                context.User.Add(new User { Nick = "User 1", Name = "Name1", Address = "Address1", Tlf = 123 });
                context.User.Add(new User { Nick = "User 2", Name = "Name2", Address = "Address2", Tlf = 123 });
                context.User.Add(new User { Nick = "User 3", Name = "Name3", Address = "Address3", Tlf = 123 });
                context.SaveChanges();

                // Test controller
                UsersController controller = new UsersController(context);
                string vNick = "User 2";
                var users = controller.GetUser(vNick).Result.Value;

                Assert.AreEqual("Name2", users.Name);
            }
        }

        [TestMethod]
        public async Task PutUserTest1Async()
        {
            DbContextOptions<UsersWebAPIContext> contextOptions;
            contextOptions = new DbContextOptionsBuilder<UsersWebAPIContext>().UseInMemoryDatabase("TestDatabase").Options;
            using (var context = new UsersWebAPIContext(contextOptions))
            {
                // Prepare data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //// Insert seed data into the database using one instance of the context

                context.User.Add(new User { Nick = "User 1", Name = "Name1", Address = "Address1", Tlf = 123 });
                context.User.Add(new User { Nick = "User 2", Name = "Name2", Address = "Address2", Tlf = 123 });
                context.User.Add(new User { Nick = "User 3", Name = "Name3", Address = "Address3", Tlf = 123 });
                context.SaveChanges();

                // Test controller
                UsersController controller = new UsersController(context);

                // Insert user
                string vNick = "User 2";
                User vNewUser = new User();
                vNewUser.Nick = vNick;
                vNewUser.Name = "Name4";
                vNewUser.Address = "Address4";
                vNewUser.Tlf = 456;

                Assert.AreEqual(3, context.User.Count());

            }
        }

        [TestMethod]
        public void PostUserTest1()
        {
            DbContextOptions<UsersWebAPIContext> contextOptions;
            contextOptions = new DbContextOptionsBuilder<UsersWebAPIContext>().UseInMemoryDatabase("TestDatabase").Options;
            using (var context = new UsersWebAPIContext(contextOptions))
            {
                // Prepare data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //// Insert seed data into the database using one instance of the context

                context.User.Add(new User { Nick = "User 1", Name = "Name1", Address = "Address1", Tlf = 123 });
                context.User.Add(new User { Nick = "User 2", Name = "Name2", Address = "Address2", Tlf = 123 });
                context.User.Add(new User { Nick = "User 3", Name = "Name3", Address = "Address3", Tlf = 123 });
                context.SaveChanges();

                // Test controller
                UsersController controller = new UsersController(context);

                // Insert user
                string vNick = "User 4";
                User vNewUser = new User();
                vNewUser.Nick = vNick;
                vNewUser.Name = "Name4";
                vNewUser.Address = "Address4";
                vNewUser.Tlf = 456;

                _ = controller.PostUser(vNewUser);

                Assert.AreEqual(4, context.User.Count());
                Assert.IsTrue(context.Set<User>().Any(e => e.Nick == vNick));
                Assert.IsTrue(context.Set<User>().Any(e => e.Name == "Name4"));
                Assert.IsTrue(context.Set<User>().Any(e => e.Address == "Address4"));
                Assert.IsTrue(context.Set<User>().Any(e => e.Tlf == 456));

            }
        }

        [TestMethod]
        public void DeleteUserTest1()
        {
            DbContextOptions<UsersWebAPIContext> contextOptions;
            contextOptions = new DbContextOptionsBuilder<UsersWebAPIContext>().UseInMemoryDatabase("TestDatabase").Options;
            using (var context = new UsersWebAPIContext(contextOptions))
            {
                // Prepare data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //// Insert seed data into the database using one instance of the context

                context.User.Add(new User { Nick = "User 1", Name = "Name1", Address = "Address1", Tlf = 123 });
                context.User.Add(new User { Nick = "User 2", Name = "Name2", Address = "Address2", Tlf = 123 });
                context.User.Add(new User { Nick = "User 3", Name = "Name3", Address = "Address3", Tlf = 123 });
                context.SaveChanges();

                // Test controller
                UsersController controller = new UsersController(context);
                string vNick = "User 2";
                _ = controller.DeleteUser(vNick);

                Assert.AreEqual(2, context.User.Count());
            }
        }


    }
}
