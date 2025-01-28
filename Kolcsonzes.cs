using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajakKenuWPF
{
    internal class Kolcsonzes
    {
        public string Nev { get; set; }
        public int Hajoid { get; set; }
        public string Hajotipus { get; set; }
        public int Szemelyekszama { get; set; }
        public int Elvitelora { get; set; }
        public int Elvitelperc { get; set; }
        public int Visszahozatalora { get; set; }
        public int Visszahozatalperc { get; set; }


        public bool VizenVan(string ido)
        {
            int ora = int.Parse(ido.Split(':')[0]);
            int perc = int.Parse(ido.Split(':')[1]);
            if (Elvitelora == ora && Elvitelperc < perc && (Visszahozatalora > ora || Visszahozatalora == ora && Visszahozatalperc >= perc)) return true;
            else return false;
        }

        public int KolcsonzesIdotartam()
        {
            return (((Visszahozatalora - Elvitelora) * 60) + (Visszahozatalperc - Elvitelperc));
        }

        public int MegkezdettFelOrak()
        {
            return ((KolcsonzesIdotartam() % 30 != 0) ? KolcsonzesIdotartam() / 30 + 1 : KolcsonzesIdotartam() / 30);
        }

        public override string ToString()
        {
            return $"{Hajoid} - {KolcsonzesIdotartam()} - {MegkezdettFelOrak()}";
        }

        public Kolcsonzes(string row)
        {
            string[] data = row.Split(';');
            Nev = data[0];
            Hajoid = int.Parse(data[1]);
            Hajotipus = data[2];
            Szemelyekszama = int.Parse(data[3]);
            Elvitelora = int.Parse(data[4]);
            Elvitelperc = int.Parse(data[5]);
            Visszahozatalora = int.Parse(data[6]);
            Visszahozatalperc = int.Parse(data[7]);
        }


    }
}
