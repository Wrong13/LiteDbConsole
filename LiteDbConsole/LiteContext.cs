using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LiteDbConsole
{
    internal class LiteContext
    {
        private string PcName;
        private string Sid;
        LiteDatabase db;
        public LiteContext(string pcName, string sid)
        {
            PcName = pcName;
            Sid = sid;
            db = new LiteDatabase(@"sdfs.db");
        }
        
        public string GetConnectionString()
        {
            var SettingsCollection = db.GetCollection<Settingi>("settings");
            var settingi = SettingsCollection.Query().Where(x => x.Password == PcName + Sid).FirstOrDefault();
            if (settingi == null)
            {
                AddUsr();
            }
            return settingi.ConnectionString;
        }

        private void AddUsr()
        {
            var SettingsCollection = db.GetCollection<Settingi>("settings");
            var settingi = new Settingi { Password = PcName + Sid, ConnectionString = "Tessty" };
            SettingsCollection.Insert(settingi);
        }
    }
}
