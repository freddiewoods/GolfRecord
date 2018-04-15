using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Enums
    {
        public enum MatchType { Strokeplay = 1, Matchplay = 2, Stableford = 3 }
        public enum Gender { Male = 1, Female = 2, Other = 3 }
        public enum Facilities { ClubHouse = 1, ATM = 2, FreeWifi = 3, Restaurant = 4, ChangingRooms = 5, ProShop = 6, WeddingVenue = 7, ConferenceRoom = 8, Hotel = 9 }
        public enum Title { Player = 1, ClubManager = 2, SystemManager = 3, UnregisteredGolfer = 4 }
        public enum InviteType { MatchInvite = 1, FriendInvite = 2, GroupInvite = 3, RequestToJoin = 4 }   
    }
}
