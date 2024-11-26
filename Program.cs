using Varos;
using System.Text;

List<Varosok> varosoks = new List<Varosok>();

using (StreamReader sr = new StreamReader(@"..\..\..\src\varosok.csv", Encoding.UTF8))
{
    while (!sr.EndOfStream)
    {
        varosoks.Add(new Varosok(sr.ReadLine()));
    }
}

Console.WriteLine($"A kollekció hossza {varosoks.Count}");

//1.
Console.WriteLine($"{varosoks.Where(c => c.OrszagNeve == "Kína").Sum(c => c.NepessegM):.00} millió fő él a Kínai nagyvárosokban");

//2.
Console.WriteLine($"Az indiai nagyvárosok átlagos lélekszáma: {varosoks.Where(c => c.OrszagNeve == "India").Average(c => c.NepessegM):.00}");

//3.
Console.WriteLine($"A legnépesebb város: {varosoks.OrderByDescending(c => c.NepessegM).First().VarosNeve}");

//4. 
Console.WriteLine("20 millió fölötti városok csökkenő sorrendben");

foreach (Varosok item in varosoks.Where(c => c.NepessegM > 2000000).OrderByDescending(c => c.NepessegM))
{
    Console.WriteLine($"{item.OrszagNeve}, {item.VarosNeve}, {item.NepessegM:F0}");
}

//5.
Console.WriteLine($"{varosoks.GroupBy(c => c.OrszagNeve).Where(c => c.Count() > 1).Count()} olyan ország van ami több várossal is szerepel a listában");

//6.
var ize = varosoks.GroupBy(c => c.VarosNeve[0]).OrderByDescending(c => c.Count()).First();
Console.WriteLine($"A legtöbb kezdőbetű:{ize.Key} ");