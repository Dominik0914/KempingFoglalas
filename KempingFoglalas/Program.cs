using KempingFoglalas;
List<Foglalas> jelenlegi = new List<Foglalas>();
foreach (var sor in File.ReadAllLines("kemping.txt").Skip(1))
{
    jelenlegi.Add(new Foglalas(sor));
}
Console.WriteLine("Adatok beolvasása a kemping.txt fájlból...");
Console.WriteLine("\nRögzített kempingfoglalások:");
foreach (var foglalas in jelenlegi)
{
    Console.WriteLine(foglalas);
}
Console.WriteLine("\nÖsszesített statisztika:");
int oss = jelenlegi.Sum(a => a.FizetendoOsszeg());
int ossvendeg = jelenlegi.Sum(a=>a.GyerekFo+a.FelnotFo);
double atlagest= jelenlegi.Average(a=>a.EjszakakSzama);
var legtobb = jelenlegi.MaxBy(a => a.FizetendoOsszeg());
Console.WriteLine($"Kemping teljes bevétele: {oss} Ft");
Console.WriteLine($"Összes vendég létszáma: {ossvendeg} fő");
Console.WriteLine($"Átlagos tartózkodási idő: {atlagest:F0} éjszaka");
Console.WriteLine($"Legtöbbet fizető vendég: {legtobb.VendegNev} ({legtobb.FizetendoOsszeg()} Ft)");
Console.WriteLine($"Gyerekes KOMFORT foglalások száma: {jelenlegi.Count(f => f.ParcellaTipus == "KOMFORT" && f.GyerekFo > 0)} db");
Console.WriteLine($"\nKedvezményre jogosult vendégek (legalább 5 éjszaka):");
foreach (var foglalas in jelenlegi.Where(f => f.EjszakakSzama >= 5))
{
    Console.WriteLine($"{foglalas.VendegNev} ({foglalas.EjszakakSzama} éjszaka)");
}