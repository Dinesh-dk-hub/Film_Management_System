using Data_Access_Layer;
using Entity_Layer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Film_Management_System
{
    class Program : BaseDAL
    {
        /*     private static IConfiguration _iconfiguration;

             static void GetAppSettingsFile()
             {
                 var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appSettings.json",
                         optional: false, reloadOnChange: true);
                 _iconfiguration = builder.Build();
             }
     */

        static void Main(string[] args)
        {
            GetMoviesByThreeMethod();


            void GetFilmByActor()
            {
                ActorDataAccessLayer k = new ActorDataAccessLayer();
                Console.WriteLine("Enter the actor name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByActor(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

                Console.Read();
            }
            void GetFilmByName()
            {
                FilmDataAccessLayer k = new FilmDataAccessLayer();
                Console.WriteLine("Enter the movie name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByTitle(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

                Console.Read();
            }
            void GetFilmByCategory()
            {
                CategoryDataAccessLayer k = new CategoryDataAccessLayer();
                Console.WriteLine("Enter the Category name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByCategory(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }
               
                Console.Read();
            }
            void GetFilmByLanguage()
            {
                LanguageDataAccessLayer k = new LanguageDataAccessLayer();
                Console.WriteLine("Enter the Language Name");
                string h = Console.ReadLine();
                Film m = k.GetFilmByLanguage(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

                Console.Read();
            }
            void GetFilmByRating()
            {
                FilmDataAccessLayer k = new FilmDataAccessLayer();
                Console.WriteLine("Enter the Rating");
                int h = Convert.ToInt32(Console.ReadLine());
                Film m = k.GetFilmByRating(h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

                Console.Read();
            }
            void GetAllMovies()
            {
                FilmDataAccessLayer k = new FilmDataAccessLayer();
                
                List<Film> lstFilms = k.GetAllDetails();
               foreach(var s in lstFilms)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", s.Title, s.ReleaseYear, s.Rating);
                }
                Console.Read();
            
            }
            void GetMoviesByThreeMethod()
            {
                FilmDataAccessLayer k = new FilmDataAccessLayer();
                Console.WriteLine("Enter the movie name");
                string j = Console.ReadLine();
                Console.WriteLine("Enter the year:");
                string num = Console.ReadLine();
                Console.WriteLine("Enter the Rating");
                int h = Convert.ToInt32(Console.ReadLine());
                Film m = k.GetFilmByMethods(j, num, h);
                if (m != null)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", m.Title, m.ReleaseYear, m.Rating);

                }

                Console.Read();
            }
        }
    }
    }

