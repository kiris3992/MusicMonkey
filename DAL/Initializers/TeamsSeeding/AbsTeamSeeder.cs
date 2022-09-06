using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public abstract class AbsTeamSeeder
    {
        public Genre blues = new Genre("Blues");
        public Genre chillstep = new Genre("Chillstep");
        public Genre classical = new Genre("Classical");
        public Genre country = new Genre("Country");
        public Genre dance = new Genre("Dance");
        public Genre disco = new Genre("Disco");
        public Genre electronic = new Genre("Electronic");
        public Genre folk = new Genre("Folk");
        public Genre hipHop = new Genre("Hip Hop");
        public Genre house = new Genre("House");
        public Genre instrumental = new Genre("Instrumental");
        public Genre jazz = new Genre("Jazz");
        public Genre kid = new Genre("Kid");
        public Genre latin = new Genre("Latin");
        public Genre metal = new Genre("Metal");
        public Genre opera = new Genre("Opera");
        public Genre pop = new Genre("Pop");
        public Genre progressive = new Genre("Progressive");
        public Genre punk = new Genre("Punk");
        public Genre rap = new Genre("Rap");
        public Genre reggae = new Genre("Reggae");
        public Genre rnb = new Genre("Rnb");
        public Genre rock = new Genre("Rock");
        public Genre soul = new Genre("Soul");
        public Genre techno = new Genre("Techno");
        public Genre traditional = new Genre("Traditional");
        public Genre trance = new Genre("Trance");
        public Genre trap = new Genre("Trap");
        public Genre hardRock = new Genre("Hard Rock");
        public Genre heavyMetal = new Genre("Heavy Metal");
        public Genre grunge = new Genre("Grunge");
    }
}
