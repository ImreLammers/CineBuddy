using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models.Types;

namespace CinéBuddy.Models
{
    public class Film
    {
        public enum Soort
        {
            twee = 1,
            drie = 2,
            beiden = 3
        }

        public enum Genre
        {
            Actie = 1,
            Avontuur = 2,
            Drama = 3,
            Fantasy = 4,
            Horror = 5,
            Komedie = 6,
            Misdaad = 7,
            Musical = 8,
            Romantiek = 9,
            Sciencefiction = 10,
            Thriller = 11,
            Western = 12
        }

        public IList<DateTime> startTijden = new List<DateTime>();
        
        public int ID { get; set; }
        public string titel { get; set; }
        public string poster { get; set; }
        public string omschrijving { get; set; }
        public Genre genre { get; set; }
        public Soort filmsoort { get; set; }
        public DateTime openingsDatum { get; set; }
        public int kijkwijzer { get; set; }
        public int lengte { get; set; }
        public string trailerLink { get; set; }

        public Film()
        {

        }

        public Film(int ID, string titel, string poster, string omschrijving, int genre, int filmsoort, DateTime openingsdatum, int kijkwijzer, int lengte, string trailerLink)
        {
            this.ID = ID;
            this.titel = titel;
            this.poster = poster;
            this.omschrijving = omschrijving;
            this.genre = (Genre)genre;
            this.filmsoort = (Soort)filmsoort;
            this.openingsDatum = openingsdatum;
            this.kijkwijzer = kijkwijzer;
            this.lengte = lengte;
            this.trailerLink = trailerLink;
        }
    }
}