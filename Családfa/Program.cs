using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Családfa
{
    class Program
    {
        static Random r = new Random();

        #region Beolvasáshoz használt függvények
        public static void Beolvasás(Kalap<string> kalap, string mit)
        {
            StreamReader r = new StreamReader(mit);
            while (!r.EndOfStream) { kalap.Push(r.ReadLine());}
        }
        #endregion

        public static void Párcsinálás(Infok alany, Kalap<string> V, Kalap<string> F, Kalap<string> L,Kalap<Infok> O)
        {
            Infok tars = new Infok(V.Pop(), alany.Fe ? L.Pop() : F.Pop(), !alany.Fe);
            
            for (int i = 0; i < r.Next(6); i++)
            {
                if (alany.Fe)
                {
                    int nem = r.Next(2);
                    Infok gyerek = new Infok(alany.V, nem == 0 ? F.Pop() : L.Pop(), nem == 0);
                    Console.WriteLine($"\"{alany.V} {alany.N}\" -> \"{gyerek.V} {gyerek.N}\"");
                    Console.WriteLine($"\"{tars.V} {tars.N}\" -> \"{gyerek.V} {gyerek.N}\"");
                    O.Push(gyerek);
                }
                else
                {
                    int nem = r.Next(2);
                    Infok gyerek = new Infok(V.Pop(), nem == 0 ? F.Pop() : L.Pop(), nem == 0 );
                    Console.WriteLine($"\"{tars.V} {tars.N}\" -> \"{gyerek.V} {gyerek.N}\"");
                    Console.WriteLine($"\"{alany.V} {alany.N}\" -> \"{gyerek.V} {gyerek.N}\"");
                    O.Push(gyerek);
                }
            }
        }
        static void Main(string[] args)
        {
            #region Beolvasás
            Kalap<string> F = new Kalap<string>();
            Beolvasás(F, "sokfiunev.txt");
            Kalap<string> L = new Kalap<string>();
            Beolvasás(L, "soklanynev.txt");
            Kalap<string> V = new Kalap<string>();
            Beolvasás(V, "veznev.txt");
            Console.WriteLine($"{F.Count} {L.Count} {V.Count}");
            #endregion

            Kalap<Infok> lehet = new Kalap<Infok>();
            int er = r.Next(2);
            string en = er == 0 ? F.Pop() : L.Pop();
            Infok elso = new Infok(V.Pop(), en,er==0?true:false);
            lehet.Push(elso);
            Párcsinálás(elso, V, F, L, lehet);
            while (V.Count>0)
            {
                Párcsinálás(lehet.Pop(), V, F, L, lehet);
            }

        }
    }
}
