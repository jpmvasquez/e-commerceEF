using E_Commerce_Project.Models.Users;
using static E_Commerce_Project.Models.Users.Person;
using System.Net.Mail;
using System.Net;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using E_Commerce_Project.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Data
{
    public class InitializeDB
    {
        //public static void seed(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        context.Database.EnsureCreated();

        //        if (!context.User.Any())
        //        {
        //            context.User.Add(new User()
        //            {
        //                firstName = "JP",
        //                lastName = "M",
        //                address = new Address()
        //                {
        //                    streetNumber = "21",
        //                    streetName = "rue de la Boétie",
        //                    city = "Paris",
        //                    zipCode = "75011",
        //                    country = "France",
        //                },
        //                role = User.eRole.Admin,
        //                emailAddress = "jepim84@yahoo.fr",
        //                civility = User.eCivility.Monsieur,
        //                password = "toto"
        //            });
        //            context.SaveChanges();
        //        }
        //        if (!context.Brand.Any())
        //        {
        //            context.Brand.AddRange(new List<Brand>()
        //            {
        //                new Brand()
        //                {
        //                    name = "Sony"
        //                },
        //                new Brand()
        //                {
        //                    name = "Kodak"
        //                },
        //                new Brand()
        //                {
        //                    name = "Panasonic"
        //                },
        //                new Brand()
        //                {
        //                    name = "Nikon"
        //                },
        //                new Brand()
        //                {
        //                    name = "Olympus"
        //                },
        //                new Brand()
        //                {
        //                    name = "Fujifilm"
        //                },
        //                new Brand()
        //                {
        //                    name = "Canon"
        //                }
        //            });
        //            context.SaveChanges();
        //        }
        //        if (!context.Techno.Any())
        //        {
        //            context.Techno.AddRange(new List<Techno>()
        //            {
        //                new Techno()
        //                {
        //                    name = "Numérique"
        //                },
        //                new Techno()
        //                {
        //                    name = "Argentique"
        //                },
        //                new Techno()
        //                {
        //                    name = "Instantanée"
        //                },
        //                new Techno()
        //                {
        //                    name = "Jetable"
        //                }
        //            });
        //            context.SaveChanges();
        //        }
        //        if (!context.ProductType.Any())
        //        {
        //            context.ProductType.AddRange(new List<ProductType>()
        //            {
        //                new ProductType()
        //                {
        //                    name = "Reflex"
        //                },
        //                new ProductType()
        //                {
        //                    name = "Hybride"
        //                },
        //                new ProductType()
        //                {
        //                    name = "Bridge"
        //                },
        //                new ProductType()
        //                {
        //                    name = "Compact"
        //                }
        //            });
        //            context.SaveChanges();
        //        }
        //    }
        //}
        public static void seed(ModelBuilder modelBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            //    context.Database.EnsureCreated();
            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    id = 1,
                    streetNumber = "21",
                    streetName = "rue de la Boétie",
                    city = "Paris",
                    zipCode = "75011",
                    country = "France",
                });
            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    id = 1,
                    firstName = "JP",
                    lastName = "M",
                    addressId = 1,
                    role = Person.eRole.Admin,
                    emailAddress = "jepim84@yahoo.fr",
                    civility = Person.eCivility.Monsieur,
                    password = "toto"
                });

            modelBuilder.Entity<Brand>().HasData(new List<Brand>()
                    {
                        new Brand()
                        {
                            id = 1,
                            name = "Sony"
                        },
                        new Brand()
                        {
                            id = 2,
                            name = "Kodak"
                        },
                        new Brand()
                        {
                            id = 3,
                            name = "Panasonic"
                        },
                        new Brand()
                        {   
                            id = 4,
                            name = "Nikon"
                        },
                        new Brand()
                        {   
                            id = 5,
                            name = "Olympus"
                        },
                        new Brand()
                        {   
                            id = 6,
                            name = "Fujifilm"
                        },
                        new Brand()
                        {   
                            id = 7,
                            name = "Canon"
                        }
                    });

            modelBuilder.Entity<Techno>().HasData(new List<Techno>()
                    {
                        new Techno()
                        {
                            id = 1,
                            name = "Numérique"
                        },
                        new Techno()
                        {   
                            id = 2,
                            name = "Argentique"
                        },
                        new Techno()
                        {   
                            id = 3,
                            name = "Instantanée"
                        },
                        new Techno()
                        {
                            id = 4,
                            name = "Jetable"
                        }
                    });

                modelBuilder.Entity<ProductType>().HasData(new List<ProductType>()
                    {
                        new ProductType()
                        {
                            id = 1,
                            name = "Reflex"
                        },
                        new ProductType()
                        {
                            id = 2,
                            name = "Hybride"
                        },
                        new ProductType()
                        {
                            id = 3,
                            name = "Bridge"
                        },
                        new ProductType()
                        {
                            id = 4,
                            name = "Compact"
                        }
                    });
        }
    }
}
