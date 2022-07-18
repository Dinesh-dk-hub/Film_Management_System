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
                        Console.WriteLine("Thank You");

                        break;
                    

                }
            } while (choice != 3);

            Console.ReadKey();
        
            static void AdminFeatures()
            {
                int nm = 0;
                Console.WriteLine("1.Movie");
                Console.WriteLine("2.Actor");
                Console.WriteLine("3.Language");
              
                Console.WriteLine("4.Category");
                Console.WriteLine("5.View Film Summary");


                nm = int.Parse(Console.ReadLine());

                if (nm == 1)
                {
                    int h = 0;
                    Console.WriteLine("1.Add a Movie");
                    Console.WriteLine("2.Modify a Movie");
                    Console.WriteLine("3.Remove a Movie");
                    h = int.Parse(Console.ReadLine());
                    if (h == 1)
                    {
                        AddMovie();
                        AdminFeatures();
                    }
                    else if (h == 2)
                    {
                        ModifyMovie();
                        AdminFeatures();
                    }
                    else if (h == 3)
                    {
                        RemoveFilm();
                        AdminFeatures();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice Entered");
                        AdminFeatures();
                    }


                }
                else if (nm == 2)
                {

                    int h = 0;
                    Console.WriteLine("1.Add a Actor");
                    Console.WriteLine("2.Modify a Actor");
                    Console.WriteLine("3.Remove a Actor");
                    h = int.Parse(Console.ReadLine());
                    if (h == 1)
                    {
                        AddActor();
                        AdminFeatures();
                    }
                    else if (h == 2)
                    {
                        ModifyActor();
                        AdminFeatures();
                    }
                    else if (h == 3)
                    {
                        RemoveActor();
                        AdminFeatures();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice Entered");
                        AdminFeatures();
                    }
                }
                else if (nm == 3)
                {

                    int h = 0;
                    Console.WriteLine("1.Add a Language");
                    Console.WriteLine("2.Modify a Language");
                    Console.WriteLine("3.Remove a Language");
                    h = int.Parse(Console.ReadLine());
                    if (h == 1)
                    {
                        GetAllLanguages();
                        AddLanguage();
                        AdminFeatures();
                    }
                    else if (h == 2)
                    {
                        ModifyLanguage();
                        AdminFeatures();
                    }
                    else if (h == 3)
                    {
                        RemoveLanguage();
                        AdminFeatures();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice Entered");
                        AdminFeatures();
                    }
                }
                else if (nm == 4)
                {

                    int h = 0;
                    Console.WriteLine("1.Add a Category");
                    Console.WriteLine("2.Modify a Category");
                    Console.WriteLine("3.Remove a Category");
                    h = int.Parse(Console.ReadLine());
                    if (h == 1)
                    {
                        AddCategory();
                        AdminFeatures();
                    }
                    else if (h == 2)
                    {
                        RemoveCategory();
                        AdminFeatures();
                    }
                    else if (h == 3)
                    {
                        RemoveCategory();
                        AdminFeatures();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice Entered");
                        AdminFeatures();
                    }
                }

                else if (nm == 5)
                {
                    GetAllMovies();
                    AdminFeatures();

                }
                else
                {
                    Console.WriteLine("Incorrect Choice Entered!");
                    AdminFeatures();
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
                    CustomerFeatures();
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
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                foreach (var s in m)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

            }
            static void GetFilmByName()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                Console.WriteLine("Enter the movie name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByTitle(h);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                if(m!=null)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", m.Title, m.ReleaseYear, m.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

            }
            static void GetFilmByCategory()
            {
                CategoryDataAccessLayer k = new CategoryDataAccessLayer();
                Console.WriteLine("Enter the Category name");
                string h = Console.ReadLine();
                var m = k.GetFilmByCategory(h);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                foreach (var s in m)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

            }
            static void GetFilmByLanguage()
            {
                LanguageBusinessLayer k = new LanguageBusinessLayer();
                Console.WriteLine("Enter the Language Name");
                string h = Console.ReadLine();
                var m = k.GetFilmByLanguage(h);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                foreach (var s in m)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            }
           static void GetFilmByRating()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                Console.WriteLine("Enter the Rating");
                int h = Convert.ToInt32(Console.ReadLine());
                List<Film> m = k.GetFilmByRating(h);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                foreach (var s in m)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            }
            static void GetAllMovies()
            {
                FilmBusinessLayer k = new FilmBusinessLayer();
                List<Film> lstFilms = k.GetAllDetails();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("-----------------------------------");
                foreach (var s in lstFilms)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));



                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

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
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", "Title", "Release_Year", "Rating"));
                Console.WriteLine("------------------------------");
                foreach (var s in m)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,9}|", s.Title, s.ReleaseYear, s.Rating));

                }
                Console.WriteLine("-------------------------------");
                Console.WriteLine();

                
            }
            static void AddMovie()
            {
                FilmBusinessLayer dl = new FilmBusinessLayer();
                Film fil = new Film();
                fil.Description = Utility.GetValidRawInput("the Description/Category").Trim();
                fil.Title = Utility.GetValidRawInput("the Title");
                fil.ReleaseYear = Utility.GetValidRawInput("the Release Year").Trim();
                GetAllLanguages();
                fil.LanguageId = Utility.GetValidIntInput(" the LanguageID");
                
                fil.OriginalLanguageId = Utility.GetValidIntInput("the Original_LanguageID");
                
                fil.RentalDuration = Utility.GetValidRawInput("the RentalDuration");
                
          
            
                fil.Length = Utility.GetValidIntInput("the Length");
                
                fil.ReplacementCost = Utility.GetValidIntInput("the Replacement Cost");
             
                fil.Rating = Utility.GetValidIntInput("the Rating");
                fil.SpecialFeatures = Utility.GetValidRawInput("the Special Features");
                GetAllActors();
                fil.ActorId = Utility.GetValidIntInput("the ActorID");
                GetAllCategory();
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
            static void AddActor()
            {
                ActorBusinessLayer dl = new ActorBusinessLayer();
                Actor a = new Actor();
                GetAllActors();
                a.ActorId = Utility.GetValidIntInput("the ActorID");
                a.FirstName = Utility.GetValidRawInput("the FirstName");
                a.LastName = Utility.GetValidRawInput("the LastName");

                bool h = dl.NewActor(a);
                if (h)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void ModifyActor()
            {
                Actor a = new Actor();
                ActorBusinessLayer al = new ActorBusinessLayer();
                GetAllActors();
                a.ActorId = Utility.GetValidIntInput("the ActorID");
                a.FirstName = Utility.GetValidRawInput("the First Name");
                a.LastName= Utility.GetValidRawInput("the Last Name");
                bool g = al.ModifyActor(a);
                if (g)
                {

                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void RemoveActor()
            {
                Actor a = new Actor();
               
                ActorBusinessLayer k = new ActorBusinessLayer();
                GetAllActors();
                int ActorId = Utility.GetValidIntInput("the Actor ID to be deleted");
                bool f = k.RemoveActor(ActorId);
                if (f)
                {
                    Console.WriteLine("Success");

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void AddLanguage()
            {
                LanguageBusinessLayer dl = new LanguageBusinessLayer();
                Language a = new Language();
                GetAllLanguages();
                a.Name = Utility.GetValidRawInput("the Language");
               

                bool h = dl.NewLanguage(a);
                if (h)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void ModifyLanguage()
            {
                Language a = new Language();
                LanguageBusinessLayer al = new LanguageBusinessLayer();
                GetAllLanguages();
                a.Name= Utility.GetValidRawInput("the Name");

                bool g = al.ModifyLanguage(a);
                if (g)
                {

                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void RemoveLanguage()
            {
                Language a = new Language();
                LanguageBusinessLayer k = new LanguageBusinessLayer();
                GetAllLanguages();
                a.LanguageId= Utility.GetValidIntInput("the Language_Id to be deleted");
                bool f = k.RemoveLanguage(a);
                if (f)
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
                GetAllMovies();
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
                GetAllMovies();
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
            
            static void GetAllLanguages()
            {

                List<Language> lstLangs = new List<Language>();
                LanguageBusinessLayer lab = new LanguageBusinessLayer();
                lstLangs = lab.GetAllLanguages();
                Console.WriteLine(String.Format("|{0,5}|{1,9}|", "Language_id", "L_Name"));
                Console.WriteLine("-----------------------");
                foreach (var s in lstLangs)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,9}|", s.LanguageId, s.Name));

                }
                Console.WriteLine("-----------------------");
            }
            static void GetAllActors()
            {

                List<Actor> lstActors = new List<Actor>();
                ActorBusinessLayer lab = new ActorBusinessLayer();
                lstActors = lab.GetAllActors();
                Console.WriteLine(String.Format("|{0,5}|{1,9}|{2,9}|", "Actor_id", "First_Name", "Last_Name"));
                Console.WriteLine("---------------------------");
                foreach (var s in lstActors)
                {

                    Console.WriteLine(String.Format("|{0,11}|{1,9}|{2,9}|", s.ActorId, s.FirstName, s.LastName));


                    
                }
                Console.WriteLine("----------------------------");
            }
            static void GetAllCategory()
            {
                List<Category> lstCategory = new List<Category>();
                CategoryBusinessLayer cbl = new CategoryBusinessLayer();
                lstCategory = cbl.GetAllCategory();



                Console.WriteLine(String.Format("|{0,5}|{1,9}|", "Category_id", "C_Name"));
                Console.WriteLine("-----------------------");
                foreach (var s in lstCategory)
                {
                  
                   Console.WriteLine( String.Format("|{0,11}|{1,9}|", s.CategoryId, s.Name));
                  
                }
                Console.WriteLine("-----------------------");
            }
            static void AddCategory()
            {
                CategoryBusinessLayer dl = new CategoryBusinessLayer();
                Category a = new Category();
                GetAllCategory();
                a.Name = Utility.GetValidRawInput("the Category");


                bool h = dl.NewCategory(a);
                if (h)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void ModifyCategory()
            {
                Category a = new Category();
                CategoryBusinessLayer al = new CategoryBusinessLayer();
                GetAllCategory();
                a.Name = Utility.GetValidRawInput("the Name");

                bool g = al.ModifyCategory(a);
                if (g)
                {

                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            static void RemoveCategory()
            {
                Category a = new Category();
                CategoryBusinessLayer k = new CategoryBusinessLayer();
                GetAllCategory();
                a.CategoryId = Utility.GetValidIntInput("the Category_Id to be deleted");
                bool f = k.RemoveCategory(a);
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

