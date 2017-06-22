﻿using NakedObjects;

namespace GolfRecord.Model
{
    public class Golfer
    {
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [Optionally] //this property is not neccessary
        public virtual int Handicap { get; set; }

        public virtual int Wins { get; set; }
    }
}
