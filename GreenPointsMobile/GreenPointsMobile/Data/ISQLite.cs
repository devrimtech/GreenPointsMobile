using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenPointsMobile.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
