using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class PlayerMessage :Message
    {

        public virtual Golfer Reciever { get; set; }

        public PlayerMessage RespondToMessage()
        {
            PlayerMessage m = Container.NewTransientInstance<PlayerMessage>();
            m.Reciever = Sender;
            m.Sender = Reciever;
            m.SendersName = Reciever.FullName;
            m.Content = ("Please press edit to enter your response.");
            Container.Persist(ref m);
            m.Reciever.Messages.Add(this);
            return m;
        }
    }
}
