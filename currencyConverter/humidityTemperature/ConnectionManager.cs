using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter.Local
{
    public class ConnectionManager
    {
        public string path { get; set; }
         
        private static LiteDatabase db;

        public ConnectionManager(string nameDB) {
            this.path = nameDB;
            db = new LiteDatabase(this.path);
        }

        public LiteDatabase GetDatabase() => db ;

    }
}
