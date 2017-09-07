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
            var ro = AddNewCourse("Royal Oak", "Scotland", "http://www.golfroyaloak.com" , "Royal Oak Golf Club is a beautiful, and challenging 9 Hole Golf Course with a great location, (10 minutes from the downtown core, 15 minutes from Swartz Bay Ferry Terminal).", "89%");
            var pb = AddNewCourse("Pebble Beach", "Croatia", "https://www.pebblebeach.com/golf/", "The sport of golf is at its worldwide best at Pebble Beach Resorts. Whether you want to play the most exciting closing hole in golf, finally master the toughest hole on the PGA TOUR or simply anticipate walking in the footsteps of golf’s greatest names, we invite you to become a part of the incomparable experience that is Pebble Beach.", "99%");
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

            var s1 = AddNewMatch("Stowe 1st Team", date1, 2);
            Context.SaveChanges();
            AddNewGolfer(s1, "Tiger Hancox", 13, "56473 829106", "Tiger@UsA.com", FavouriteClub.Iron);
            AddNewGolfer(s1, "Rory Gabriel", 14, "01296 234324", "Rory@Ireland.com" , FavouriteClub.Iron);
            AddNewGolfer(s1, "Rookie Player", 12, "07810 675443", "Rookie@England.com", FavouriteClub.PitchingWedge);
            AddNewGolfer(s1, "Adam Chair", 13, "01234 753234", "Chairs@NewZealand.com", FavouriteClub.Putter);
            context.SaveChanges();

            var s2 = AddNewMatch("Stowe Tour Team", date1, 1);
            Context.SaveChanges();
            AddNewGolfer(s2, "Novak Lacoste", 16, "01234 567891", "Novak.Locoste@goowiz.com", FavouriteClub.Wood);
            AddNewGolfer(s2, "Rafa Lauren", 16, "19876 543210", "Rafa@T.com", FavouriteClub.Putter);
            AddNewGolfer(s2, "Roger Perry", 16, "10202 304050", "Roger@T.com", FavouriteClub.Wood);
            AddNewGolfer(s2, "Andy Hacket", 16, "01020 030405", "Andy@Gmai.com", FavouriteClub.Sandwedge);
            Context.SaveChanges();

            var s3 = AddNewMatch("Stowe MatchPlay Team", date1, 2, MatchType.MatchPlay);
            Context.SaveChanges();
            AddNewGolfer(s3, "Obi Wan", 10,"12345 098765", "Obi@Tatoine.com", FavouriteClub.Putter);
            AddNewGolfer(s3, "Mace Windu", 5, "98754 123415", "Mace@jedi.com", FavouriteClub.Sandwedge);
            Context.SaveChanges();

            var s4 = AddNewMatch("Stowe StableFord Team", date1, 2, MatchType.StableFord);
            context.SaveChanges();
            AddNewGolfer(s4, "Albert Einstein", 0, "57324 321414", "Albert@Genius.com", FavouriteClub.Putter);
            AddNewGolfer(s4, "Max Born", 2, "12345 123456", "Max@Genie.com",FavouriteClub.Iron);
            AddNewGolfer(s4, "Isaac Newton", 5, "56392 123441", "Newton@Apple.com", FavouriteClub.Wood);
            AddNewGolfer(s4, "Nikola Tesla", 7, "09832 111111", "Tesla@Cars.com", FavouriteClub.PitchingWedge);
            Context.SaveChanges();




        }
        private Golfer AddNewGolfer(Match m, string name, int handi, string mobile, string mail, FavouriteClub favouriteclub)
        {
            var g = new Golfer() { FullName = name, Handicap = handi, Email = mail, Mobile = mobile, FavouriteClub = favouriteclub};
            Context.Golfers.Add(g);
            Context.SaveChanges();
            m.Golfers.Add(g);
            return (g);
        }
        private Match AddNewMatch(string name, DateTime date, int courseID, MatchType matchType = MatchType.StrokePlay)
        {
            var m = new Match() { MatchName = name, DateOfMatch = date, CourseID = courseID, MatchType = matchType };
            Context.Matches.Add(m);
            return (m);
        }
        private Course AddNewCourse(string CourseName, string Location, string WebsiteLink, string ShortParagraph, string rating)
        {
            var c = new Course() { CourseName = CourseName, Location = Location, WebsiteLink = WebsiteLink, CourseDescription = ShortParagraph, Rating = rating};
            Context.Courses.Add(c);
            return (c);
        }
        private Hole AddNewHole(Course c, int HoleNumeber, int Par, int Distance, int StrokeIndex)
        {
            var h = new Hole() { HoleNumber = HoleNumeber, Par = Par, Distance = Distance, Stroke = StrokeIndex };
            Context.Holes.Add(h);
            Context.SaveChanges();
            c.Holes.Add(h);
            return (h);
        }
       

    }
}
