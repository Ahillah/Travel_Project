
 using DomainLayer.Models.Hotels___Accommodation;
    using DomainLayer.Models.Identity;
    using DomainLayer.Models.User;
    using Microsoft.AspNetCore.Identity;

    namespace Persistance.Identity
    {
        public static class IdentityDataSeed
        {
            public static async Task Initialize(

         RoleManager<ApplicationRole> roleManager,
         UserManager<ApplicationUser> userManager,
         ApplicationDbContext db)
            {
                await SeedRoles(roleManager);
                await SeedHotels(db);
                await SeedUsers(userManager, db);
            }

            // Seed Roles
            private static async Task SeedRoles(RoleManager<ApplicationRole> roleManager)
            {
                string[] roles = { "ADMIN", "HOTEL", "TOURIST" };

                foreach (var roleName in roles)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new ApplicationRole
                        {
                            Name = roleName,
                            NormalizedName = roleName,
                            Description = $"{roleName} default role"
                        });
                    }
                }
            }


            // SEED HOTELS
            private static async Task SeedHotels(ApplicationDbContext db)
            {
                if (!db.Hotels.Any())
                {
                    db.Hotels.AddRange(
                        new Hotel
                        {

                            Name = "Sunrise Grand Resort",
                            Description = "A luxurious beachfront resort offering premium rooms, multiple swimming pools, and exceptional hospitality.",
                            ImageUrel = "https://picsum.photos/seed/hotel1/600/400",
                            Address = "Sheraton Road, Hurghada",
                            City = "Hurghada",
                            Latitude = 27.2579m,
                            Longitude = 33.8116m,
                            StarRating = 5,
                            CheckInTime = new TimeSpan(14, 0, 0),
                            CheckOutTime = new TimeSpan(12, 0, 0)
                        },
                        new Hotel
                        {

                            Name = "Nile View Hotel",
                            Description = "A quiet hotel located directly on the Nile with spacious rooms and relaxing views.",
                            ImageUrel = "https://picsum.photos/seed/hotel2/600/400",
                            Address = "Corniche El Nil, Downtown",
                            City = "Cairo",
                            Latitude = 30.0444m,
                            Longitude = 31.2357m,
                            StarRating = 4,
                            CheckInTime = new TimeSpan(13, 0, 0),
                            CheckOutTime = new TimeSpan(11, 0, 0)
                        },
                        new Hotel
                        {

                            Name = "Alexandria Beach Hotel",
                            Description = "A modern hotel with direct beach access, offering sea-view rooms and family-friendly amenities.",
                            ImageUrel = "https://picsum.photos/seed/hotel3/600/400",
                            Address = "Stanley Bridge Road",
                            City = "Alexandria",
                            Latitude = 31.2417m,
                            Longitude = 29.9668m,
                            StarRating = 4,
                            CheckInTime = new TimeSpan(14, 0, 0),
                            CheckOutTime = new TimeSpan(12, 0, 0)
                        },
                        new Hotel
                        {

                            Name = "Sharm Paradise Resort",
                            Description = "A 5-star resort with diving activities, private beach, and world-class restaurants.",
                            ImageUrel = "https://picsum.photos/seed/hotel4/600/400",
                            Address = "Naama Bay",
                            City = "Sharm El Sheikh",
                            Latitude = 27.9158m,
                            Longitude = 34.3299m,
                            StarRating = 5,
                            CheckInTime = new TimeSpan(15, 0, 0),
                            CheckOutTime = new TimeSpan(12, 0, 0)
                        },
                        new Hotel
                        {

                            Name = "Luxor Royal Inn",
                            Description = "Located near the ancient temples with river-side rooms and comfortable suites.",
                            ImageUrel = "https://picsum.photos/seed/hotel5/600/400",
                            Address = "Luxor Temple Street",
                            City = "Luxor",
                            Latitude = 25.6872m,
                            Longitude = 32.6396m,
                            StarRating = 4,
                            CheckInTime = new TimeSpan(13, 0, 0),
                            CheckOutTime = new TimeSpan(11, 0, 0)
                        });


                    await db.SaveChangesAsync();
                }
            }
            // Seed User
            private static async Task SeedUsers(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
            {
                // ADMIN USER

                if (await userManager.FindByEmailAsync("admin@system.com") == null)
                {
                    var admin = new ApplicationUser
                    {
                        UserName = "admin@system.com",
                        Email = "admin@system.com",
                        DisplayName = "System Admin",
                        UserType = "Admin",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(admin, "Admin@12345");
                    await userManager.AddToRoleAsync(admin, "ADMIN");
                }

                // HOTEL USER

                if (await userManager.FindByEmailAsync("hotel@test.com") == null)
                {
                    var hotelUser = new HotelUser
                    {
                        UserName = "hotel@test.com",
                        Email = "hotel@test.com",
                        DisplayName = "Hotel Manager 1",
                        UserType = "Hotel",
                        HotelId = 5,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(hotelUser, "Hotel@12345");
                    await userManager.AddToRoleAsync(hotelUser, "HOTEL");
                }

                // TOURIST USER

                if (await userManager.FindByEmailAsync("tourist@test.com") == null)
                {
                    var tourist = new TouristUser
                    {
                        UserName = "tourist@test.com",
                        Email = "tourist@test.com",
                        DisplayName = "Tourist User",
                        UserType = "Tourist",
                        IDNumber = "987654321",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(tourist, "Tourist@12345");
                    await userManager.AddToRoleAsync(tourist, "TOURIST");
                }
            }
        }
    }

