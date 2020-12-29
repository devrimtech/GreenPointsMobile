using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GreenPointsMobile.Testing
{
    public class Secrets
    {
        private const string _apikey = "Your_FIREBASE_API_KEY";

        public string APIKEY
        {
            get { return _apikey;  }
        }
    }
}
