using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            var wp = new WebClient();
            var sites = new string[] {
                "http://www.repubblica.it/",
                "http://www.di.unipi.it",
                "http://www.unipi.it"
            };

            var tb = new System.Text.StringBuilder();

            foreach(var s in sites) {
                   // Console.WriteLine(wp.DownloadString(s));
                tb.Append(wp.DownloadString(s));

              
            }

            //var w = tb.ToString().Split(' ');
            var Words= Regex.Split(tb.ToString(), @"\W+ ");

            //var occ= Words.Count(f => f == "/");

            //var q = from w in Words orderby w.Length ascending select new { Word= w, Len = w.Length};

            //var q = from w in Words group w by w.Count() into word  select new { Word = w, Len = w.Length, word };
            //var q = from w in Words group w by occ into count select count;

            var q = from w in Words
                    group w by w into g
                    orderby g.Count() ascending
                     select new { Word = g.Key, Count = g.Count() };

            //lambda expression
            //Words.GroupBy(s => new { Key = s })
            //    .OrderBy(g => g.Key)
            //    .Select(g => new { Word = g.Key, Count = g.Count() });

            var l = "";
            while ((l = Console.ReadLine()) != string.Empty)
            {
                foreach (var e in q.Where(el => el.Word == l))
                {
                    Console.WriteLine("{0}\t{1}", e.Word, e.Count);
                }
            }

            //foreach (var e in q)
            //{
            //    Console.WriteLine("{0}\t{1}", e.Word, e.Count);
            //}
        }
    }
}
