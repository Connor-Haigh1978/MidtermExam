using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    public class TVShow
    {
        public int ID { get; set; }   
        public string Actors { get; set; }
           public string Awards     {get; set;}
           public string Country    {get; set;}
           public string Director   {get; set;} 
           public string Genre      {get; set;}
           public string Language   {get; set;} 
           public string Plot       {get; set;}
           public string Poster     {get; set;}
           public string Rated      {get; set;}
           public string Released   {get; set;}
           public string Runtime    {get; set;}
           public string minutes    {get; set;}
           public string Title      {get; set;}
           public string Type       {get; set;}
           public string Writer     {get; set;}
           public string Year       {get; set;}
           public string imdbID     {get; set;}
           public string imdbRating {get; set;}
           public string imdbVotes  {get; set;}

        public TVShow()
        {
            ID = 0;
            Actors = string.Empty;
            Awards     = string.Empty;
            Country    = string.Empty;
            Director   = string.Empty;
            Genre      = string.Empty;
            Language   = string.Empty;
            Plot       = string.Empty;
            Poster     = string.Empty;
            Rated      = string.Empty;
            Released   = string.Empty;
            Runtime = string.Empty;
            minutes = string.Empty;
            Title      = string.Empty;
            Type       = string.Empty;
            Writer     = string.Empty;
            Year       = string.Empty;
            imdbID = string.Empty;
            imdbRating = string.Empty;
            imdbVotes  = string.Empty;

        }

        public TVShow(string line)
        {
            var pieces = line.Split('\t');


            Actors = pieces[1];
            Awards = pieces[2];
            Country = pieces[3];
            Director = pieces[4];
            Genre = pieces[5];
            Language = pieces[6];
            Plot = pieces[7];
            Poster = pieces[8];
            Rated = pieces[9];
            Released = pieces[10];
            Runtime = pieces[11];
            Title = pieces[12];
            Type = pieces[13];
            Writer = pieces[14];
            Year = pieces[15];
            imdbID = pieces[16];
            imdbRating = pieces[17];
            imdbVotes = pieces[18];
        }
        public override string ToString()
        {
            return $"{Title} ({Rated}), in country {Country} in languages {Language}"; 
        }


    }
}
