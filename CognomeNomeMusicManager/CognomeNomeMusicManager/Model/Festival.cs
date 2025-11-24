using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CognomeNomeMusicManager.Model;

public class Festival
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }=null!;
    public DateTime DataInizio { get; set; }
    public List<Esibizione> Esibizioni { get; set; }=null!;
    public List<Cantante> Cantanti { get; set; } = null!;

}
