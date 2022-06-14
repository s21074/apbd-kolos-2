using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Nickname { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }

    }
}
