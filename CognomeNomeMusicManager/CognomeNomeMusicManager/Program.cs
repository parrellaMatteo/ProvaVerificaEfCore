// See https://aka.ms/new-console-template for more information
using CognomeNomeMusicManager.Data;
using CognomeNomeMusicManager.Model;
using Microsoft.EntityFrameworkCore;

using var db = new MusicContext();
// PopulateDb(db);
Q1(db);
Q2(db);
Q3(db);
Q4(db);
Q5(db);
static void PopulateDb(MusicContext db)

{

        List<Etichetta> etichette =
        [
            new (){Id=1, Nome="Universal Music", SedeLegale="Milano"},
            new (){Id=2, Nome="Sony Music", SedeLegale="Roma"},
            new (){Id=3, Nome="Warner Music", SedeLegale="Milano"},
        ];
        etichette.ForEach(e =>db.Add(e));
        db.SaveChanges();

        List<Cantante> cantanti =
        [
            new (){Id = 1, NomeArte="The Rocker", NomeReale="Mario Rossi", EtichettaId=1},
            new (){Id = 2, NomeArte="Melody", NomeReale="Anna Verdi", EtichettaId=1},
            new (){Id = 3, NomeArte="Trap King", NomeReale="Luca Bianchi", EtichettaId=2},
            new (){Id = 4, NomeArte="Jazz Master", NomeReale="Paolo Neri", EtichettaId=2},
            new (){Id = 5, NomeArte="Pop Queen", NomeReale="Giulia Gialli", EtichettaId=3},
            new (){Id = 6, NomeArte="Indie Boy", NomeReale="Marco Blu", EtichettaId=3}
        ];
        cantanti.ForEach(e =>db.Add(e));
        db.SaveChanges();


        List<Festival> festival =
        [
            new (){Id=1, Nome="Sanremo Giovani", DataInizio=DateTime.Today},
            new (){Id=2, Nome="Festivalbar", DataInizio=DateTime.Today.AddDays(-30)}
        ];
        festival.ForEach(e =>db.Add(e));
        db.SaveChanges();

        List<Esibizione> esibizioni =
        [
            // Festival 1 (Sanremo)
            new (){CantanteId = 1, FestivalId = 1, VotiGiuria= 85, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 1, VotiGiuria = 92, OrdineUscita = 2},
            new (){CantanteId = 3, FestivalId = 1, VotiGiuria = 70, OrdineUscita = 3},
            new (){CantanteId = 4, FestivalId = 1, VotiGiuria = 60, OrdineUscita = 4},
            new (){CantanteId = 5, FestivalId = 1, VotiGiuria = 95, OrdineUscita = 5}, 
            new (){CantanteId = 6, FestivalId = 1, VotiGiuria = 50, OrdineUscita = 6},

            // Festival 2 (Festivalbar)
            new (){CantanteId = 4, FestivalId = 2, VotiGiuria = 88, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 2, VotiGiuria = 90, OrdineUscita = 2},
            new (){CantanteId = 1, FestivalId = 2, VotiGiuria = 75, OrdineUscita = 3},
            new (){CantanteId = 5, FestivalId = 2, VotiGiuria = 80, OrdineUscita = 4},
            new (){CantanteId = 6, FestivalId = 2, VotiGiuria = 65, OrdineUscita = 5},
            new (){CantanteId = 3, FestivalId = 2, VotiGiuria = 55, OrdineUscita = 6},
        ];
        esibizioni.ForEach(e =>db.Add(e));
        db.SaveChanges();
        List<Strumento> strumentoi =
        [
            new(){Id=1, Nome="Chitarra"},
            new(){Id=2, Nome="Pianoforte"},

        ];
        strumentoi.ForEach(e =>db.Add(e));
        db.SaveChanges();
        List<Abilità> abilitàs =
        [
            new(){StrumentoId = 1 , CantanteId = 2, Livello = 5},
            new(){StrumentoId = 2 , CantanteId = 1, Livello = 2},
        ];
        abilitàs.ForEach(e =>db.Add(e));
        db.SaveChanges();
}       

// Q1: Creare un metodo che riceve in input un punteggio minimo (es. 80) e stampa l'elenco delle Esibizioni di successo. 
// Per ogni esibizione stampare: Nome d'Arte del cantante, Nome del Festival e Voti ottenuti, filtrando solo chi ha superato la soglia inserita.
static void Q1(MusicContext db)
{
    db.Esibizione.Where(e => e.VotiGiuria >= 80 )
    .Include(e => e.Cantante)
    .ThenInclude(e => e.Festivals)
    .Select(e => new{e.VotiGiuria,e.Cantante.NomeArte,e.Festival.Nome})
    .ToList()
    .ForEach(e => Console.WriteLine($"Voto : {e.VotiGiuria} , Cantante : {e.NomeArte} , Festival : {e.Nome}"));
}
// Q2: Creare un metodo che riceve in input il nome di un'Etichetta e stampa l'elenco dei Festival in cui ha partecipato almeno un cantante di 
//quell'etichetta (evitare duplicati nei nomi dei festival).
static void Q2(MusicContext db)
{
    db.Esibizione.Where(e => e.Cantante.Etichetta.Nome == "Universal Music")
    .Include(e => e.Festival)
    .Select(e => new{e.Festival.Nome })
    .Distinct()
    .ToList()
    .ForEach(e => Console.WriteLine($"- {e.Nome} "));
}
//Q3: Trovare e stampare i nomi dei cantanti (e il relativo Festival) che hanno avuto l'onere di aprire il festival (ovvero quelli con OrdineUscita uguale a 1).
static void Q3(MusicContext db)
{
    db.Esibizione.Where(e => e.OrdineUscita == 1)
    .Include(e => e.Cantante)
    .ThenInclude(e => e.Festivals)
    .Select(e => new{e.OrdineUscita , e.Cantante.NomeArte, e.Festival.Nome})
    .ToList()
    .ForEach((e) => Console.WriteLine($"uscita : {e.OrdineUscita} cantante : {e.NomeArte} Festival : {e.Nome}"));
}
//Q4  Stampare la classifica dei cantanti basata sulla media voti. Per ogni cantante mostrare il Nome d'Arte e
// la media aritmetica dei voti presi in tutte le sue esibizioni, ordinando dal più bravo (media più alta) al meno bravo.
static void Q4(MusicContext db)
{
    var classifica = db.Esibizione
    .GroupBy(e => e.Cantante.NomeArte)
    .Select(g => new {
        NomeArte = g.Key,
        MediaVoti = g.Average(x => x.VotiGiuria)
    })
    .OrderByDescending(c => c.MediaVoti)
    .ToList();

    classifica.ForEach(c =>
        Console.WriteLine($"{c.NomeArte} - Media voti: {c.MediaVoti}")
    );

}
// Q5: Per ogni Festival presente nel database, stampare il nome del Festival e il punteggio più alto (Record) registrato in quel festival
static void Q5(MusicContext db)
{
    var records = db.Festival
        .Select(f => new {
            Festival = f.Nome,
            Record = f.Esibizioni.Max(e => e.VotiGiuria)
        })
        .ToList();

    records.ForEach(r =>
        Console.WriteLine($"{r.Festival} - Record voti: {r.Record}")
    );
}
