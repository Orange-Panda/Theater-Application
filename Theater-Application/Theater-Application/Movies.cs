using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Movie_Theater
{
    /// <summary>
    /// Contains a collection of the movies and functions to access them.
    /// </summary>
    public static class Movies
    {
        public static Movie SelectedMovie { get; private set; }
        private static Dictionary<string, Movie> movies = new Dictionary<string, Movie>();
        private static bool initialized;

        public static Movie GetMovie(string key)
        {
            if (!initialized) Initialize();

            if (movies.ContainsKey(key)) return movies[key];
            else throw new NullReferenceException();
        }

        /// <summary>
        /// Loads all the movies from the movies folder.
        /// </summary>
        public static void Initialize()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] resources = assembly.GetManifestResourceNames();

            foreach (string resource in resources)
            {
                if (resource.StartsWith("Theater-Application.Movies."))
                {
                    Stream stream = assembly.GetManifestResourceStream(resource);
                    StreamReader reader = new StreamReader(stream);
                    string json = reader.ReadToEnd();
                    string name = resource.Remove(0, "Theater-Application.Movies.".Length);
                    movies.Add(name, JsonConvert.DeserializeObject<Movie>(json));
                }
            }

            initialized = true;
        }

        public static void SetMovie(Movie movie)
        {
            SelectedMovie = movie;
        }

        public static void SetMovie(string key)
        {
            SelectedMovie = GetMovie(key);
        }

        public static List<Movie> GetMovieList()
        {
            if (!initialized) Initialize();
            return movies.Values.ToList();
        }
    }

    /// <summary>
    /// Datatype that contains details about a movie.
    /// </summary>
    [Serializable]
    public struct Movie
    {
        public string videoUrl;
        public string imageName;
        public string backgroundName;
        public string title;
        public string description;
        public string directors;
        public string writers;
        public string cast;
        public string genre;
        public double rating;
        public double movieLength;
        public ContentRating contentRating;
    }

    /// <summary>
    /// United States movie content rating. (G, PG, PG-13, R, NC-17)
    /// </summary>
    public enum ContentRating
    {
        G, PG, PG13, R, NC17, NotRated
    }
}
