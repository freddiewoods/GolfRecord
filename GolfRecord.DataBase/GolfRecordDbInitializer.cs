using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfRecord.Model;
using System;
using static System.Net.Mime.MediaTypeNames;
using static GolfRecord.Model.Enums;

namespace GolfRecord.DataBase
{
    public class GolfRecordDbInitializer : DropCreateDatabaseAlways<GolfRecordDbContext>
    {

        public DateTime date1 = new DateTime(2017, 05, 11);
        private GolfRecordDbContext Context;
        protected override void Seed(GolfRecordDbContext context)
        {
            this.Context = context;

            #region Courses
            var ro = AddNewCourse("Royal Oak", "Scotland", "http://www.golfroyaloak.com", "Royal Oak Golf Club is a beautiful, and challenging 9 Hole Golf Course with a great location, (10 minutes from the downtown core, 15 minutes from Swartz Bay Ferry Terminal).", "540 Marsett Place, Victoria B.C. V8Z-5M1", 32, 2000, " 250 658 - 1433");
            var pb = AddNewCourse("Pebble Beach", "Croatia", "https://www.pebblebeach.com/golf/", "The sport of golf is at its worldwide best at Pebble Beach Resorts. Whether you want to play the most exciting closing hole in golf, finally master the toughest hole on the PGA TOUR or simply anticipate walking in the footsteps of golf’s greatest names, we invite you to become a part of the incomparable experience that is Pebble Beach.", "1700 17 - Mile Drive, PebbleBeach, CA 93953", 72, 6828, "(800) 877‑0597");
            var ss = AddNewCourse("Stowe Golf Club", "England", "https://www.stowe.co.uk/house/venue-hire/golf-club", "Stowe has a 9-hole course situated in the historic setting of Lancelot ‘Capability’ Brown’s landscaped garden. The Club has an extensive range of social gatherings and competitions to get involved in.", "Stowe House Preservation Trust, Stowe, Buckingham, MK18 5EH", 66, 4500, "01280 818282");
            var st = AddNewCourse("Silverstone Golf Club", "England", " http://www.silverstonegolfclub.co.uk/", "Set on the Buckinghamshire/Northamptonshire border and surrounded by forest this beautiful 18 hole parkland course was designed by David Snell and offers the golfers a great challenge", "Silverstone Road, Stowe, Buckingham MK18 5LH", 72, 6600, "01280-850005");
            context.SaveChanges();
            AddNewHole(pb, 1, 3, 400, 2);
            AddNewHole(pb, 2, 4, 600, 3);
            AddNewHole(pb, 3, 3, 420, 4);
            AddNewHole(pb, 4, 3, 450, 6);
            AddNewHole(pb, 5, 4, 620, 9);
            AddNewHole(pb, 6, 3, 410, 11);
            AddNewHole(pb, 7, 3, 350, 1);
            AddNewHole(pb, 8, 3, 450, 5);
            AddNewHole(pb, 9, 4, 550, 7);
            AddNewHole(pb, 10, 4, 600, 15);
            AddNewHole(pb, 11, 4, 700, 18);
            AddNewHole(pb, 12, 3, 600, 17);
            AddNewHole(pb, 13, 4, 500, 8);
            AddNewHole(pb, 14, 3, 410, 10);
            AddNewHole(pb, 15, 4, 575, 12);
            AddNewHole(pb, 16, 3, 550, 13);
            AddNewHole(pb, 17, 4, 600, 14);
            AddNewHole(pb, 18, 3, 525, 16);
            Context.SaveChanges();

            AddNewHole(ro, 1, 3, 400, 1);
            AddNewHole(ro, 2, 3, 420, 2);
            AddNewHole(ro, 3, 4, 525, 6);
            AddNewHole(ro, 4, 3, 410, 4);
            AddNewHole(ro, 5, 4, 530, 7);
            AddNewHole(ro, 6, 5, 650, 9);
            AddNewHole(ro, 7, 3, 410, 3);
            AddNewHole(ro, 8, 3, 430, 5);
            AddNewHole(ro, 9, 4, 500, 8);
            Context.SaveChanges();

            AddNewHole2(ss, 1, "Home Park", 122, 108, 3, 13, 122, 3, 15);
            AddNewHole2(ss, 2, "Chatham", 281, 254, 4, 9, 268, 4, 9);
            AddNewHole2(ss, 3, "Copper Beech", 296, 285, 4, 11, 296, 4, 11);
            AddNewHole2(ss, 4, "Rotunda", 409, 329, 4, 1, 409, 4, 1);
            AddNewHole2(ss, 5, "Hog Pond", 186, 170, 3, 5, 186, 3, 5);
            AddNewHole2(ss, 6, "Doric", 277, 277, 4, 17, 277, 4, 13);
            AddNewHole2(ss, 7, "Old Acacia", 327, 317, 4, 7, 281, 4, 7);
            AddNewHole2(ss, 8, "Lakeside", 302, 302, 4, 7, 281, 4, 7);
            AddNewHole2(ss, 9, "Caroline", 112, 112, 3, 15, 112, 3, 17);
            AddNewHole2(ss, 10, "Home Park", 122, 108, 3, 14, 122, 3, 16);
            AddNewHole2(ss, 11, "Chatham", 281, 254, 4, 10, 268, 4, 10);
            AddNewHole2(ss, 12, "Copper Beech", 296, 285, 4, 12, 296, 4, 12);
            AddNewHole2(ss, 13, "Rotunda", 409, 393, 4, 2, 409, 4, 2);
            AddNewHole2(ss, 14, "Hog Pond", 186, 170, 3, 6, 186, 3, 6);
            AddNewHole2(ss, 15, "Doric", 242, 221, 4, 18, 242, 4, 14);
            AddNewHole2(ss, 16, "Old Acacia", 312, 312, 4, 4, 312, 4, 4);
            AddNewHole2(ss, 17, "Lakeside", 282, 274, 4, 8, 274, 4, 8);
            AddNewHole2(ss, 18, "Caroline", 112, 112, 3, 16, 112, 3, 18);
            Context.SaveChanges();
            AddNewHole2(st, 1, "Jim's Folly", 506, 494, 5, 12, 458, 5, 6);
            AddNewHole2(st, 2, "Pentimore", 412, 403, 4, 4, 378, 4, 10);
            AddNewHole2(st, 3, "Deb's Mere", 135, 131, 3, 18, 116, 3, 18);
            AddNewHole2(st, 4, "Father's Barn", 401, 397, 4, 2, 322, 4, 2);
            AddNewHole2(st, 5, "Swallowtail", 279, 274, 4, 16, 247, 4, 12);
            AddNewHole2(st, 6, "The Break", 206, 191, 3, 10, 173, 3, 14);
            AddNewHole2(st, 7, "MiddleMead", 530, 514, 5, 8, 497, 5, 4);
            AddNewHole2(st, 8, " Pheasant's Walk", 157, 153, 3, 14, 153, 3, 16);
            AddNewHole2(st, 9, " The Halfway", 425, 409, 4, 6, 301, 4, 8);
            AddNewHole2(st, 10, "The Borehole", 400, 384, 4, 11, 305, 4, 17);
            AddNewHole2(st, 11, "Red Ditches", 388, 382, 4, 7, 336, 4, 7);
            AddNewHole2(st, 12, "Holly Hill", 507, 498, 5, 13, 406, 5, 13);
            AddNewHole2(st, 13, "Nite Mere", 410, 400, 4, 3, 369, 4, 3);
            AddNewHole2(st, 14, "Amen Corner", 401, 391, 4, 1, 385, 4, 1);
            AddNewHole2(st, 15, "Earlswood", 368, 363, 4, 15, 354, 4, 11);
            AddNewHole2(st, 16, "Christie's Creek", 149, 145, 3, 17, 135, 3, 15);
            AddNewHole2(st, 17, "Buttockspire", 390, 384, 4, 9, 365, 4, 5);
            AddNewHole2(st, 18, "Wet Leys", 583, 563, 5, 5, 406, 5, 9);
            context.SaveChanges();
#endregion

            #region MatchCreators
            var CM = AddNewClubManager("Philip Leny", 0, "07123 7392833", Gender.Male, pb, "fwoodscomp@gmail.com");
            var TH = AddNewClubManager("Tiger Hancox", 13, "56473 829106", Gender.Male,ro, "few@more.com");
            var DS = AddNewClubManager("Dandy Smith", 3, "01238 942343", Gender.Female,st);
            var NS = AddNewClubManager("Nathan Swanson", 12, "01296 749916", Gender.Male,ss);
            var JH = AddNewGolfer2("Jimmy Hart", 10, "01234 123414", Gender.Male);
            var TL = AddNewGolfer2("Theresa Lolly", 22, "05324 234519", Gender.Female);
            var OW = AddNewGolfer2("Obi Wan", 10, "12345 098765", Gender.Male);
            var AE = AddNewGolfer2("Albert Einstein", 0, "57324 321414", Gender.Male);
            var MC = AddNewGolfer2("Marie Curie", 15, "01234 132443", Gender.Female);
            var JB = AddNewGolfer2("Jim Breithaupt", 0, "01942 872356", Gender.Male);
            context.SaveChanges();
            #endregion


            #region Matches
            var s1 = AddNewMatch("Stowe boys Strokeplay Match", date1, 1,TH);
            Context.SaveChanges();
            s1.Golfers.Add(TH);
            var p2 = AddNewGolfer(s1, "Rory Gabriel", 14, "01296 234324", Gender.Male);
            AddNewGolfer(s1, "Rookie Player", 12, "07810 675443", Gender.Male);
            AddNewGolfer(s1, "Adam Chair", 13, "01234 753234", Gender.Male);
            context.SaveChanges();

            var s2 = AddNewMatch("Stowe girls stroke play match", date1, 2, DS);
            Context.SaveChanges();
            s2.Golfers.Add(DS);
            AddNewGolfer(s2, "Rafa Lauren", 16, "19876 543210", Gender.Female);
            AddNewGolfer(s2, "Roger Perry", 16, "10202 304050", Gender.Female);
            AddNewGolfer(s2, "Andy Hacket", 8, "01020 030405", Gender.Female);
            Context.SaveChanges();

            var s3 = AddNewMatch("Stowe Mixed Stroked play Match", date1, 3,NS);
            context.SaveChanges();
            s3.Golfers.Add(NS);
            AddNewGolfer(s3, "Rafferty Reeves", 8, "01289 743123", Gender.Male);
            AddNewGolfer(s3, "Bethany philip", 12, "01233 123414", Gender.Female);
            AddNewGolfer(s3, "Rachel wright", 3, "01234 321413", Gender.Female);
            Context.SaveChanges();


            var s4 = AddNewMatch("Stowe Boys MatchPlay Team", date1, 2,JH, MatchType.Matchplay);
            context.SaveChanges();
            s4.Golfers.Add(JH);
            AddNewGolfer(s4, "Andrew Tait", 2, "01234 3214312", Gender.Male);
            Context.SaveChanges();

            var s5 = AddNewMatch("Stowe girls MatchPlay Team", date1, 4,TL, MatchType.Matchplay);
            Context.SaveChanges();
            s5.Golfers.Add(TL);
            AddNewGolfer(s5, "Mary Jane", 5, "01324 590123", Gender.Female);
            Context.SaveChanges();

            var s6 = AddNewMatch("Stowe Mixed MatchPlay Team", date1, 3,OW, MatchType.Matchplay);
            Context.SaveChanges();
            s6.Golfers.Add(OW);
            AddNewGolfer(s6, "Mace Windu", 5, "98754 123415", Gender.Female);
            Context.SaveChanges();

            var s7 = AddNewMatch("Stowe Mens Stableford Team", date1, 2,AE, MatchType.Stableford);
            context.SaveChanges();
            s7.Golfers.Add(AE);
            AddNewGolfer(s7, "Max Born", 2, "12345 123456", Gender.Male);
            AddNewGolfer(s7, "Isaac Newton", 5, "56392 123441", Gender.Male);
            AddNewGolfer(s7, "Nikola Tesla", 7, "09832 111111", Gender.Male);
            Context.SaveChanges();

            var s8 = AddNewMatch("Stowe Womens Stableford Team", date1, 1,MC, MatchType.Stableford);
            context.SaveChanges();
            s8.Golfers.Add(MC);
            AddNewGolfer(s8, "Rosamund Flip", 18, "01135 353426", Gender.Female);
            AddNewGolfer(s8, "Genie Booch", 4, "01823 988132", Gender.Female);
            context.SaveChanges();

            var s9 = AddNewMatch("Stowe Mixed Stableford Team", date1, 4,JB, MatchType.Stableford);
            context.SaveChanges();
            s9.Golfers.Add(JB);
            AddNewGolfer(s9, "Saul Muliplem", 5, "01492 845483", Gender.Male);
            AddNewGolfer(s9, "Mary Teapot", 9, "01832 144324", Gender.Female);
            AddNewGolfer(s9, "Linda Green", 14, "01234 123441", Gender.Female);
            Context.SaveChanges();


            var s11 = AddNewMatch("Strokeplay match with scores except last", date1, 1, CM, MatchType.Strokeplay);
            context.SaveChanges();
            s11.Golfers.Add(CM);
            AddNewGolfer(s11, "Noah Castillo", 6, "01728 123412", Gender.Male);
            AddNewGolfer(s11, "Cody Turner", 6, "01383 132414", Gender.Male);
            AddNewGolfer(s11, "Aidan Hopkins", 5, "01256 122122", Gender.Male);


            AddScoreStrokePlay(s11, ro.Holes.ElementAt(0), 3, 4, 3, 4);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(1), 3, 4, 4, 4);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(2), 4, 3, 3, 4);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(3), 3, 5, 3, 3);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(4), 3, 4, 5, 3);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(5), 4, 5, 6, 5);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(6), 5, 4, 4, 4);
            AddScoreStrokePlay(s11, ro.Holes.ElementAt(7), 3, 4, 5, 4);

            // AddScoreStrokePlay(s2, 

            var MP = AddNewGolfer2("Peter Miller", 1, "08188 464638", Gender.Male, "wooodssy@gmail.com");
            context.SaveChanges();

            AddFriend(CM, MP);
            AddFriend(MP, CM);
            context.SaveChanges();
            var TSP = AddNewMatch("Test Strokeplay Match", date1, 1,MP, MatchType.Strokeplay);
            context.SaveChanges();
            TSP.Golfers.Add(MP);
            TSP.Golfers.Add(CM);
            TSP.Golfers.Add(TH);
            TSP.Golfers.Add(p2);

            var TMP = AddNewMatch("Test Matchplay Match", date1, 2,CM, MatchType.Matchplay);
            context.SaveChanges();
            TMP.Golfers.Add(MP);
            TSP.Golfers.Add(CM);
            Context.SaveChanges();

            var TSF = AddNewMatch("Test Stableford Match", date1, 1,MP, MatchType.Stableford);
            context.SaveChanges();
            TSF.Golfers.Add(MP);
            TSF.Golfers.Add(CM);
            TSF.Golfers.Add(TH);
            TSF.Golfers.Add(p2);
            Context.SaveChanges();
            #endregion

            #region Facilities
            AddNewFacility(Facilities.ATM);
            AddNewFacility(Facilities.ChangingRooms);
            AddNewFacility(Facilities.ClubHouse);
            AddNewFacility(Facilities.ConferenceRoom);
            AddNewFacility(Facilities.FreeWifi);
            AddNewFacility(Facilities.Hotel);
            AddNewFacility(Facilities.ProShop);
            AddNewFacility(Facilities.Restaurant);
            AddNewFacility(Facilities.WeddingVenue);
            Context.SaveChanges();
#endregion



            EditCourse(pb, CM);
            EditCourse(ro, TH);
            EditCourse(st, DS);
            EditCourse(ss, NS);
            Context.SaveChanges();

           #region Groups
            var group1 = AddNewGroup("Philip's Group", CM);
            Context.SaveChanges();
            group1.Members.Add(CM);
            group1.Members.Add(MP);
            group1.Members.Add(JB);
            group1.Members.Add(MC);
            group1.Members.Add(AE);
            Context.SaveChanges();
            MP.PrivateAccount = true;
            Context.SaveChanges();
            #endregion

            var Me = AddNewGolfer2("John Smith", 10, "07910715641", Gender.Male, "fwoodscomp3@gmail.com");
            Context.SaveChanges();

            AddFriend(Me, CM);
            AddFriend(CM, Me);
            var group2 = AddNewGroup("John's Group", Me);
            Context.SaveChanges();
            group2.Members.Add(Me);
            group2.Members.Add(CM);
            context.SaveChanges();

            var MainMatch = AddNewMatch("1 on 1 with Philip", date1, ro.Id, Me, MatchType.Matchplay);
            MainMatch.Golfers.Add(Me);
            MainMatch.Golfers.Add(CM);
            context.SaveChanges();

            var MainMatch2 = AddNewMatch("Strokeplay", date1, pb.Id, Me, MatchType.Strokeplay);
            MainMatch2.Golfers.Add(Me);
            MainMatch2.Golfers.Add(CM);
            MainMatch2.Golfers.Add(AE);
            MainMatch2.Golfers.Add(JB);
            context.SaveChanges();

            var MainMatch3 = AddNewMatch("Stableford", date1, pb.Id, Me, MatchType.Stableford);
            MainMatch3.Golfers.Add(Me);
            MainMatch3.Golfers.Add(MC);
            MainMatch3.Golfers.Add(MP);
            MainMatch3.Golfers.Add(CM);
            context.SaveChanges();


        }
        private Player AddNewGolfer(Match m, string name, int handi, string mobile, Gender gender,  Title title = Title.Player)
        {
            var g = new Player() { FullName = name, Handicap = handi, Mobile = mobile, Gender = gender, Position = title };
            Context.Golfers.Add(g);
            Context.SaveChanges();
            m.Golfers.Add(g);
            return (g);
        }
        private Player AddNewGolfer2(string name, int handi, string mobile, Gender gender, string username = "",  Title title = Title.Player)
        {
            var g2 = new Player() { FullName = name, Handicap = handi, Mobile = mobile, Gender = gender, Username = username, Position = title };
            Context.Golfers.Add(g2);
            Context.SaveChanges();
            return (g2);
        }
        private Match AddNewMatch(string name, DateTime date, int courseID, Golfer MatchCreator, MatchType matchType = MatchType.Strokeplay)
        {// work for each match type
            Match m = null;
            switch (matchType)
            {
                case MatchType.Strokeplay:
                    m = new Strokeplay() { MatchName = name, DateOfMatch = date, CourseID = courseID, MatchType = matchType, MatchCreator = MatchCreator };
                    break;
                case MatchType.Matchplay:
                    m = new Matchplay() { MatchName = name, DateOfMatch = date, CourseID = courseID, MatchType = matchType, MatchCreator = MatchCreator };
                    break;
                case MatchType.Stableford:
                    m = new Stableford() { MatchName = name, DateOfMatch = date, CourseID = courseID, MatchType = matchType, MatchCreator = MatchCreator };
                    break;
                default:
                    break;
            }
            Context.Matches.Add(m);
            Context.SaveChanges();
            return (m);
        }

        private StrokeplayScores AddScoreStrokePlay(Match Match, Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var s = new StrokeplayScores { Hole = hole, GolferARawScore = ScoreA, GolferBRawScore = ScoreB, GolferCRawScore = ScoreC, GolferDRawScore = ScoreD };
            Context.StrokeplayScores.Add(s);
            Context.SaveChanges();
            Match.HoleScores.Add(s);
            return (s);
        }
        private Course AddNewCourse(string CourseName, string Location, string WebsiteLink, string ShortParagraph, string address, int par, int yardage, string Phone)
        {
            var c = new Course() { CourseName = CourseName, Location = Location, WebsiteLink = WebsiteLink, CourseDescription = ShortParagraph, Address = address, Par = par, Yardage = yardage, PhoneNumber = Phone };
            Context.Courses.Add(c);
            return (c);
        }
        private Hole AddNewHole(Course c, int HoleNumeber, int par, int distance, int strokeindex)
        {
            var h = new Hole() { HoleNumber = HoleNumeber, Par = par, WhiteYards = distance, StrokeIndex = strokeindex };
            Context.Holes.Add(h);
            Context.SaveChanges();
            c.Holes.Add(h);
            return (h);
        }
        private Hole AddNewHole2(Course c, int HoleNumeber, string name, int whiteyards, int yellowyards, int par, int strokeindex, int ladiesredyards, int redpar, int redstrokeindex)
        {
            var h = new Hole() { HoleNumber = HoleNumeber, Name = name, WhiteYards = whiteyards, YellowYards = yellowyards, Par = par, StrokeIndex = strokeindex, LadiesRedYards = ladiesredyards, RedPar = redpar, RedStrokeIndex = redstrokeindex };
            Context.Holes.Add(h);
            Context.SaveChanges();
            c.Holes.Add(h);
            return (h);
        }
        private ClubManager AddNewClubManager(string name, int handi, string mobile, Gender gender, Course course, string username = "", bool withinmatch = true, Title title = Title.ClubManager)
        {
            var g3 = new ClubManager() { FullName = name, Handicap = handi, Mobile = mobile, Gender = gender, course = course, Username = username, Position = title };
            Context.Golfers.Add(g3);
            Context.SaveChanges();
            return (g3);
        }
        private void AddFriend(Golfer golfer1, Golfer golfer2)
        {
            golfer1.Friends.Add(golfer2);
            Context.SaveChanges();
        }
        private Course EditCourse(Course course, Golfer golfer)
        {
            var c = course;
            c.ClubManager = golfer;
            Context.SaveChanges();
            return c;
        }

        private Facility AddNewFacility(Facilities Facility)
        {
            var F = new Facility() { facility = Facility, Name = Facility.ToString() };
            Context.Facilities.Add(F);
            Context.SaveChanges();
            return F;
        }
        private Group AddNewGroup(string GroupName, Golfer golfer)
        {
            var g = new Group() { Name = GroupName, GroupOwner = golfer };
            Context.Groups.Add(g);
            Context.SaveChanges();
            return g;
        }
    }
}
