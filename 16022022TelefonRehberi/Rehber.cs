using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16022022TelefonRehberi
{
    class Rehber
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string email { get; set; }
        public string webadres { get; set; }
        public string adres { get; set; }
        public string aciklama { get; set; }

        public override string ToString()
        {
            return isim + " " + soyisim;
        }

    }
}
