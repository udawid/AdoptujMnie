using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schronisko.Models;


namespace Schronisko.Data
{
    public class SchroniskoSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (dbContext.Database.CanConnect())
                {
                    SeedRoles(dbContext);
                    SeedUsers(dbContext);
                    SeedAnimalTypes(dbContext);
                    SeedAnimals(dbContext);
                    SeedNewses(dbContext);
                    SeedAnnouncement(dbContext);
                    SeedUserFormTypes(dbContext);
                    SeedUserFormQuestionTypes(dbContext);
                }
            }
        }

        private static void SeedAnnouncement(ApplicationDbContext dbContext)
        {
            if (!dbContext.Announcements.Any())
            {
                var announcement = new List<Announcement>
                {
                    new Announcement
                    {
                        Title = "Zgubiono",
                        AnnouncementText ="25 stycznia uciekł mały czarny kotek w okolicach ulicy Warszawskiej w miejscowości Sanniki. Jego szczególnym znakiem jest biała plamka na czubku ogona. Prosimy o kontakt na telefon: 567 891 023",
                        Type = "Dodane: ",
                        Status = "Aktywne",
                        Photo = "kot.jpg",
                        AddedDate = DateTime.Now,
                    },
                    new Announcement
                    {
                        Title = "Zgubiono",
                        AnnouncementText = "Dzisiaj ok godziny 21, wystraszyła się huku i uciekła suczka adoptowana trzy dni temu. Nazywa się Perełka. Pobiegła prawdopodobnie wzdłuż Grochowskiej. Przy obroży ma charakterystyczną zawieszkę.",
                        Type = "Dodane: ",
                        Status = "Aktywne",
                        Photo = "pies.jpg",
                        AddedDate = DateTime.Now,
                    },
                    new Announcement
                    {
                        Title = "Znaleziono",
                        AnnouncementText = "Sunia widziana od kilku dni, zawekowała  się na opuszczonej działce. Obecnie przebywa pod opieką u pani, która ją zabezpieczyła. Wszelkie informację o kontakcie posiada administracja strony",
                        Type = "Dodane: ",
                        Status = "Aktywne",
                        Photo = "pies1.jpg",
                        AddedDate = DateTime.Now,
                    }
                };
                dbContext.AddRange(announcement);
                dbContext.SaveChanges();
            }
        }

        private static void SeedNewses(ApplicationDbContext dbContext)
        {
            if (!dbContext.Newses.Any())
            {
                var news = new List<News>
                {
                    new News
                    {
                        Title = "Kalendarz 2023",
                        NewsText = "Już dziś kup kalendarz z naszymi zwierzakami na rok 2023 i wesprzyj naszych pupili. Całość zysków ze sprzedaży kalendarzy zostanie przeznaczona na zakup karmy dla zwierząt i wyposażenie kojców...",
                        Status = "Aktywne",
                        Photo = "kalendarz.png",
                        AddedDate = DateTime.Now,
                    },
                    new News
                    {
                        Title = "Dzień Schroniska!",
                        NewsText = "Dzisiaj obchodzimy Światowy Dzień Schroniska. Z tej okazji chcieliśmy przypomnieć, że nadal w schroniskach przebywa za dużo zwierząt, czekających na adopcję. Już dziś wejdź na listę zwierząt w naszym schronisku...",
                        Status = "Aktywne",
                        Photo = "dzien.jpg",
                        AddedDate = DateTime.Now,
                    },
                    new News
                    {
                        Title = "Przekaż 1%",
                        NewsText = "Przekaż 1% podatku na WWF. Wystarczy wpisać numer KRS 0000 160 673 rozliczając się za pomocą e-pita czy składając papierową wersję deklaracji PIT do Urzędu Skarbowego...",
                        Status = "Aktywne",
                        Photo = "11.png",
                        AddedDate = DateTime.Now,
                    }
                };
                dbContext.AddRange(news);
                dbContext.SaveChanges();
            }
        }

        private static void SeedAnimals(ApplicationDbContext dbContext)
        {
            if (!dbContext.Animals.Any())
            {
                var animal = new List<Animal>
                {
                    new Animal
                    {
                        Name = "Burek",
                        Description = "Burek to śliczny, pięcioletni jamniczek, który trafił do nas po śmierci swojej Pani. Jest bardzo grzecznym pieskiem, kocha ludzi i umie chodzić na smyczy. Nauczony załatwiać swoje potrzeby tam gdzie powinien :)",
                        Status = "Szuka domu",
                        Dostepnosc = true,
                        AddedDate = DateTime.Now,
                        AnimalTypeID = 1,
                        Photo = "pies.jpg"
                    },
                    new Animal
                    {
                        Name = "Niunia",
                        Description = "Nieśmiała kotka, która unika kontaktu z nami. Początkowo większość czasu spędzała w kryjówce, obecnie lubi siedzieć lub leżeć w pobliżu innych mruczków z boksu i uważnie się nam przyglądać.",
                        Status = "Szuka domu",
                        Dostepnosc = true,
                        AddedDate = DateTime.Now,
                        AnimalTypeID = 2,
                        Photo = "kot.jpg"
                    },
                    new Animal
                    {
                        Name = "Monia",
                        Description = "Monia jest typem wycofanego królika. Na razie człowiek nie kojarzy jej się zbyt dobrze, ale pracujemy nad tym. Mimo wszystko mała przełamuje swoje lęki i zdarza się, że to ona pierwsza zaczepia człowieka.",
                        Status = "Szuka domu",
                        Dostepnosc = true,
                        AddedDate = DateTime.Now,
                        AnimalTypeID = 3,
                        Photo = "krolik.jpg"
                    }
                };
                dbContext.AddRange(animal);
                dbContext.SaveChanges();
            }
        }

        //zakładanie ról w apliakcji, o ile nie istnieją
        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var roleStore = new RoleStore<IdentityRole>(dbContext);

            if (!dbContext.Roles.Any(r => r.Name == "admin"))
            {
                roleStore.CreateAsync(new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                }).Wait();
            }

            if (!dbContext.Roles.Any(r => r.Name == "opiekun"))
            {
                roleStore.CreateAsync(new IdentityRole
                {
                    Name = "opiekun",
                    NormalizedName = "opiekun"
                }).Wait();
            }
        }  // koniec ról

        //zakładanie kont uzytkowników w apliakcji, o ile nie istnieją
        private static void SeedUsers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any(u => u.UserName == "Opiekun1@schronisko.pl"))
            {
                var user = new AppUser
                {
                    UserName = "Opiekun1@schronisko.pl",
                    NormalizedUserName = "Opiekun1@schronisko.pl",
                    Email = "opiekun1@schronisko.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Marcin",
                    LastName = "Kowalski",
                    Information = "Info"
                };
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Schronisko1!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "opiekun").Wait();

                dbContext.SaveChanges();
            }

            if (!dbContext.Users.Any(u => u.UserName == "admin@schronisko.pl"))
            {
                var user = new AppUser
                {
                    UserName = "admin@schronisko.pl",
                    NormalizedUserName = "admin@schronisko.pl",
                    Email = "admin@schronisko.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Admin",
                    LastName = "Admiński",
                    Information = "Info"
                };
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Schronisko1!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "admin").Wait();
                dbContext.SaveChanges();
            }
        } // koniec użytkowników


        //dodawanie danych typu zwierzęcia
        private static void SeedAnimalTypes(ApplicationDbContext dbContext)
        {
            if (!dbContext.AnimalTypes.Any())
            {
                var types = new List<AnimalType>
                {
                    //new AnimalType { AnimalTypeID = 1, Name = "Pies"},
                    //new AnimalType { AnimalTypeID = 2, Name = "Kot"},
                    //new AnimalType { AnimalTypeID = 3, Name = "Inne"},
                    new AnimalType { Name = "Pies"},
                    new AnimalType { Name = "Kot"},
                    new AnimalType { Name = "Inne"},
                };
                dbContext.AddRange(types);
                dbContext.SaveChanges();
            }
        } //koniec danych typu zwierzęcia


        //dodawanie danych typu ankiety
        private static void SeedUserFormTypes(ApplicationDbContext dbContext)
        {
            if (!dbContext.UserFormTypes.Any())
            {
                var types = new List<UserFormType>
                {
                    new UserFormType { Name = "Adopcja ogólny", Active = true}, //formularz adopcyjny ogólnodostępny/uniwersalny
                    new UserFormType { Name = "Adopcja wybrane zwierze", Active = true}, //formularz przypisany do wybranego zwierzęcia
                                                                                            //np. inne dla psów, a inne dla kotów,
                                                                                            //dla zwierząt ktore nie tolerują innych zwierząt, dzieci,
                                                                                            //czy wymagających specjalnej opieki
                    new UserFormType { Name = "Ankieta ogólnodostępna", Active = false}, //np. ankieta z opinią o działaniu schroniska
                };
                dbContext.AddRange(types);
                dbContext.SaveChanges();
            }
        } //koniec danych typu ankiety


        //dodawanie danych typu pytania
        private static void SeedUserFormQuestionTypes(ApplicationDbContext dbContext)
        {
            if (!dbContext.UserFormQuestionTypes.Any())
            {
                var types = new List<UserFormQuestionType>
                {  // planowane wartości: 'YesNo', 'YesNoOther', 'ChooseOne', 'ChooseMultiple', 'OpenQuestion'
                    new UserFormQuestionType { Name = "Tak/Nie", Active = true},
                    new UserFormQuestionType { Name = "Tak/Nie/Inne", Active = false}, //aktualnie nie wspierana, do zaimplementowanie przy rozbudowie formularza
                    new UserFormQuestionType { Name = "Wybierz jedną opcją", Active = true},
                    new UserFormQuestionType { Name = "Wybierz wiele opcji", Active = true},
                    new UserFormQuestionType { Name = "Pytanie otwarte", Active = false}, //aktualnie nie wspierana, do zaimplementowanie przy rozbudowie formularza
                    
                };
                dbContext.AddRange(types);
                dbContext.SaveChanges();
            }
        } //koniec danych typu pytania
    }
}
