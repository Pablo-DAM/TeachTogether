using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class LoginData
    {     
    public int id { get; set; }
        public Token token { get; set; }
    }
    public class Token
    {
        public string token { get; set; }
        public string tokenType { get; set; }
    }
}

