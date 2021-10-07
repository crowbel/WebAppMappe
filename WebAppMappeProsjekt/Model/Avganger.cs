using System;

namespace WebAppMappeProsjekt.Model
{
    public class Avganger
    {
        public int Id { get; set; }
        public DateTime AvgangTid { get; set; }
        public virtual Ruter RuteNr{ get; set; }
    }
}
