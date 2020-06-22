using System;
using System.Collections.Generic;
using System.Text;

namespace GreenPointsMobile.Models
{
    class Token
    {
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }

        public Token()
        {

        }
    }
}
