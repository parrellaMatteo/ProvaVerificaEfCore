using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CognomeNomeMusicManager.Model;

public class Cantante
{
    [Key]
    public int Id { get; set; }
    public string NomeArte { get; set; } = null!;
    public string NomeReale { get; set; } = null!;
    public int EtichettaId { get; set; }
    public Etichetta Etichetta { get; set; }=null!;
    public List<Esibizione> Esibizioni { get; set; }= null!;
    public List<Festival> Festivals { get; set; } = null!;
    public Abilità Abilità { get; set; }=null!;

}
