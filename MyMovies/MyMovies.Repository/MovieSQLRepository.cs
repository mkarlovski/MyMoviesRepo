using MyMovies.Data;
//using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repository
{
   public class MovieSQLRepository : IMovieRepository
    {
        public void Add(Movies1 movie)
        {
            using(var cnn= new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))
            {
                cnn.Open();
                var query = @"insert into Movies1(Title, ImageURL,Description,Cast)   
                    values(@Title,@ImageURL,@Description,@Cast)";  //so prvoto @ mu davame moznost da se pisuva vo povekje redovi
                var cmd = new SqlCommand(query,cnn);
                //SQL injection protection
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ImageURL", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Cast", movie.Cast);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Movies1> GetAll()
        {
            var result = new List<Movies1>();

            using (var cnn= new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))   // konekcija so lokalna baza i windows auth ;so using se otvora nova kolekcija i koga ke zavrsi odma ja zatvara i nemora cnn.Close()
            {
                cnn.Open();  //so ova pravime konekcija do bazata
                /* cnn.Close();*/ //na kraj mora da ja zatvorime konekcijata  dokolku ne koristime using()

                var cmd = new SqlCommand("select * from Movies1", cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movies1();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.ImageUrl = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Cast = reader.GetString(4);

                    result.Add(movie);
                }
                return result;
            }
        }

        public static List<Movies1> GetByTitle(string title)
        {
            var result = new List<Movies1>();

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))   // konekcija so lokalna baza i windows auth ;so using se otvora nova kolekcija i koga ke zavrsi odma ja zatvara i nemora cnn.Close()
            {
                cnn.Open();  //so ova pravime konekcija do bazata
                /* cnn.Close();*/ //na kraj mora da ja zatvorime konekcijata  dokolku ne koristime using()
                var query = "select * from Movies1";
                if (!String.IsNullOrEmpty(title))
                {
                    query = $"{query} where title like @title";
                }
                
                var cmd = new SqlCommand(query, cnn);
                if (!String.IsNullOrEmpty(title))
                {
                    cmd.Parameters.AddWithValue("@title", $"%{title}%");
                }
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movies1();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.ImageUrl = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Cast = reader.GetString(4);

                    result.Add(movie);
                }
                return result;
            }

        }

        public Movies1 GetById(int id)
        {
            Movies1 result = null;

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))   // konekcija so lokalna baza i windows auth ;so using se otvora nova kolekcija i koga ke zavrsi odma ja zatvara i nemora cnn.Close()
            {
                cnn.Open();  //so ova pravime konekcija do bazata
                /* cnn.Close();*/ //na kraj mora da ja zatvorime konekcijata  dokolku ne koristime using()

                var cmd = new SqlCommand($"select * from Movies1 where id={id}", cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movies1();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageUrl = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Cast = reader.GetString(4);
                
                }
                return result;
            }
        }
    }
}
