using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Enums
    {
        public enum MatchType { StrokePlay = 1, MatchPlay = 2, StableFord = 3 }
        public enum Gender { Male = 1, Female = 2, Other = 3 }
        public enum Facilities { ClubHouse = 1, ATM = 2, FreeWifi = 3, Restuarnat = 4, ChangingRooms = 5, ProShop = 6, WeddingVenue = 7, ConferenceRoom = 8 }
        public enum Title { Player = 1, ClubManager = 2, SystemManager = 3 }
    
    }
}
