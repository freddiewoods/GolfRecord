﻿using System.Collections.Generic;
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
            var ro = AddNewCourse("Royal Oak", "Scotland", "http://www.golfroyaloak.com" , "Royal Oak Golf Club is a beautiful, and challenging 9 Hole Golf Course with a great location, (10 minutes from the downtown core, 15 minutes from Swartz Bay Ferry Terminal).", 79.4d, "540 Marsett Place, Victoria B.C. V8Z-5M1", 32, 2000);
            var pb = AddNewCourse("Pebble Beach", "Croatia", "https://www.pebblebeach.com/golf/", "The sport of golf is at its worldwide best at Pebble Beach Resorts. Whether you want to play the most exciting closing hole in golf, finally master the toughest hole on the PGA TOUR or simply anticipate walking in the footsteps of golf’s greatest names, we invite you to become a part of the incomparable experience that is Pebble Beach.", 74.7, "1700 17 - Mile Drive, PebbleBeach, CA 93953", 72, 6828);
            var ss = AddNewCourse("Stowe Golf Club", "England", "https://www.stowe.co.uk/house/venue-hire/golf-club", "Stowe has a 9-hole course situated in the historic setting of Lancelot ‘Capability’ Brown’s landscaped garden. The Club has an extensive range of social gatherings and competitions to get involved in.", 60.5d,"Stowe House Preservation Trust, Stowe, Buckingham, MK18 5EH", 66, 4500);
            var st = AddNewCourse("Silverstone Golf Club", "England", " http://www.silverstonegolfclub.co.uk/", "Set on the Buckinghamshire/Northamptonshire border and surrounded by forest this beautiful 18 hole parkland course was designed by David Snell and offers the golfers a great challenge", 55.6d, "Silverstone Road, Stowe, Buckingham MK18 5LH", 72, 6600);
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


            var s1 = AddNewMatch("Stowe 1st Team", date1, 2);
            Context.SaveChanges();
            AddNewGolfer(s1, "Tiger Hancox", 13, "56473 829106", "Tiger@Usa.com", FavouriteClub.Iron);
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
        private Course AddNewCourse(string CourseName, string Location, string WebsiteLink, string ShortParagraph, double rating, string address, int par, int yardage)
        {
            var c = new Course() { CourseName = CourseName, Location = Location, WebsiteLink = WebsiteLink, CourseDescription = ShortParagraph, Rating = rating, Address = address, Par = par, Yardage = yardage};
            Context.Courses.Add(c);
            return (c);
        }
        private Hole AddNewHole(Course c, int HoleNumeber, int par, int distance, int strokeindex)
        {
            var h = new Hole() { HoleNumber = HoleNumeber, Par = par, WhiteYards = distance, StrokeIndex = strokeindex};
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


    }
}
