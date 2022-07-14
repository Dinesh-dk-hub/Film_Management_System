using Data_Access_Layer;
using Entity_Layer;
using Business_Layer;
using Microsoft.Extensions.Configuration;
using PanoramicData.ConsoleExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace Film_Management_System
{
    class Program : BaseDAL
    {

        static void Main(string[] args)
        {
            

            int choice = 0;
            Console.WriteLine("Film Management System");
            
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Welcome to Film Management System");

            
            do
            {
                
                Console.WriteLine("1.Admin");
                    Console.WriteLine("2.Customer");
                    Console.WriteLine("3.Exit");
                    Console.WriteLine("Hi, Enter your choice:");
                    choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:

                        VerifyAdmin();
                        
                        break;
                    case 2:


                        CustomerFeatures();
                            break;
                       
                    case 3:
                        break;
                    

                }
            } while (choice != 3);

            Console.ReadKey();
        
            static void AdminFeatures()
            {
                int nm = 0;
                Console.WriteLine("1.Add a Movie");
                Console.WriteLine("2.Modify a Movie");
                Console.WriteLine("3.Remove a Movie");
                Console.WriteLine("4.View Film Summary");


                nm = int.Parse(Console.ReadLine());

                if (nm == 1)
                {
                    AddMovie();
                    AdminFeatures();

                }
                else if (nm == 2)
                {
                    ModifyMovie();
                    AdminFeatures();


                }
                else if (nm == 3)
                {
                    RemoveFilm();
                    AdminFeatures();
                }
                else if (nm == 4)
                {
                    GetAllMovies();
                    AdminFeatures();

                }
                else
                {
                    Console.WriteLine("Incorrect Choice Entered!");
                }
            }
            static void CustomerFeatures()
            {
                int j = 0;
                Console.WriteLine("1.Search Film By Name");
                Console.WriteLine("2.Search Film By Actor");
                Console.WriteLine("3.Search Film By Category");
                Console.WriteLine("4.Search Film By Language");
                Console.WriteLine("5.Search Film By Rating");
                Console.WriteLine("6.Search Film By All Methods");
                Console.WriteLine("7.View Film Summary");

                j = int.Parse(Console.ReadLine());

                if (j == 1)
                {
                    GetFilmByName();
                    CustomerFeatures();

                }
                else if (j == 2)
                {
                    GetFilmByActor();
                    CustomerFeatures();
                }
                else if (j == 3)
                {
                    GetFilmByCategory();
                    CustomerFeatures();
                }
                else if (j == 4)
                {
                    GetFilmByLanguage();
                    CustomerFeatures();
                }
                else if (j == 5)
                {
                    GetFilmByRating();
                    CustomerFeatures();
                }
                else if (j == 6)
                {
                    GetMoviesByThreeMethod();
                    CustomerFeatures();
                }
                else if (j == 7)
                {
                    GetAllMovies();
                    CustomerFeatures();
                }
                else
                {
                    Console.WriteLine("Incorrect Choice Entered!");
                }
            }
            static void VerifyAdmin()
            {
                Film fil = new Film();
                Console.WriteLine("Enter your details to Login");
                Console.WriteLine("Enter your Username:");
                string Pname = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                


                var Password1= ConsolePlus.ReadPassword();
                Console.WriteLine();
                //bool status = bll.VerifyPatient(pat);
                if (Pname == "admin" && Password1 == "admin")
                {
                    Console.WriteLine("User Verification Successful!");
                    AdminFeatures();
                }
                else
                {
                    Console.WriteLine("User Verification Unsuccessful");
                }

            }
            static void GetFilmByActor()
            {
                ActorBusinessLayer k = new ActorBusinessLayer();
                Console.WriteLine("Enter the actor name");
                string h = Console.ReadLine();
                List<Film> m = k.GetFilmByRating(h);
                foreach (var s in m)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }

               
            }
            static void GetFilmByName()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                Console.WriteLine("Enter the movie name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByTitle(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

               
            }
            static void GetFilmByCategory()
            {
                CategoryDataAccessLayer k = new CategoryDataAccessLayer();
                Console.WriteLine("Enter the Category name");
                string h = Console.ReadLine();
                var m = k.GetFilmByCategory(h);
                foreach (var s in m)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }

                
            }
            static void GetFilmByLanguage()
            {
                LanguageBusinessLayer k = new LanguageBusinessLayer();
                Console.WriteLine("Enter the Language Name");
                string h = Console.ReadLine();
                var m = k.GetFilmByLanguage(h);
                foreach (var s in m)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }

                
            }
           static void GetFilmByRating()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                Console.WriteLine("Enter the Rating");
                int h = Convert.ToInt32(Console.ReadLine());
                List<Film> m = k.GetFilmByRating(h);
                foreach ( var s in m)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }

                Console.WriteLine();
            }
            static void GetAllMovies()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                List<Film> lstFilms = k.GetAllDetails();
                foreach (var s in lstFilms)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }
                

            }
            static void GetMoviesByThreeMethod()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                Console.WriteLine("Enter the movie name");
                string j = Console.ReadLine();
                Console.WriteLine("Enter the year:");
                string num = Console.ReadLine();
                Console.WriteLine("Enter the Rating");
                int h = Convert.ToInt32(Console.ReadLine());
                var m = k.GetFilmByMethods(j, num, h);

                    foreach (var s in m)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                    }

                Console.WriteLine();

                
            }
            static void AddMovie()
            {
                FilmBusinessLayer dl = new FilmBusinessLayer();
                Film fil = new Film();
                fil.Description = Utility.GetValidRawInput("the Description/Category").Trim();
                fil.Title = Utility.GetValidRawInput("the Title");
                fil.ReleaseYear = Utility.GetValidRawInput("the Release Year").Trim();
                fil.LanguageId = Utility.GetValidIntInput(" the LanguageID");
                
                fil.OriginalLanguageId = Utility.GetValidIntInput("the Original_LanguageID");
                
                fil.RentalDuration = Utility.GetValidRawInput("the RentalDuration");
                
          
            
                fil.Length = Utility.GetValidIntInput("the Length");
                
                fil.ReplacementCost = Utility.GetValidIntInput("the Replacement Cost");
             
                fil.Rating = Utility.GetValidIntInput("the Rating");
                fil.SpecialFeatures = Utility.GetValidRawInput("the Special Features");
             
                fil.ActorId = Utility.GetValidIntInput("the ActorID");
                
                fil.CategoryId = Utility.GetValidIntInput("the CategoryID");
                bool h = dl.NewMovie(fil);
                if (h)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
                
                
            }
            static void ModifyMovie()
            {
                Film fil = new Film();
                FilmBusinessLayer k = new FilmBusinessLayer();
                fil.FilmId = Utility.GetValidIntInput("the Movie ID");
                fil.Title = Utility.GetValidRawInput("the Title");
                fil.ReleaseYear = Utility.GetValidRawInput("the Release Year").Trim();
                fil.Rating = Utility.GetValidIntInput("the Rating");
                bool g = k.Modify(fil);
                if (g)
                {

                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void RemoveFilm()
            {
                Film fil = new Film();
                FilmBusinessLayer k = new FilmBusinessLayer();
                fil.FilmId = Utility.GetValidIntInput("the Movie ID to be deleted");
                bool f = k.RemoveMovie(fil);
                if (f)
                {
                    Console.WriteLine("Success");

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            Console.Read();
        }
    }
}

