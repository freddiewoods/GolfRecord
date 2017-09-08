using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Enums
    {
        public enum MatchType { StrokePlay = 1, MatchPlay = 2, Foursome = 3, StableFord = 4 }
        public enum FavouriteClub { Putter = 1, Sandwedge = 2, PitchingWedge = 3, Iron = 4, Wood = 5 }
        public enum Facilities { ClubHouse = 1, ATM = 2, FreeWifi = 3, Restuarnat = 4, ChangingRooms = 5, ProShop = 6, WeddingVenue = 7, ConferenceRoom = 8 }
    }
}
