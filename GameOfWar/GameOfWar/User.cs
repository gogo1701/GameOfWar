using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    public class User
    { 
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int winsGame { get; set; }
        public int losesGame { get; set;}
    }
}
