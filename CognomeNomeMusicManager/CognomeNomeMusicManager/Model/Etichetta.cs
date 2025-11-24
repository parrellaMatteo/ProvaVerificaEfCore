using System;
using System.ComponentModel.DataAnnotations;

namespace CognomeNomeMusicManager.Model;

public class Etichetta
{
    [Key]
    public int Id { get; set;}
    public string Nome { get; set;}=null!;
    public string SedeLegale { get; set; }=null!;
    public List<Cantante> Cantanti { get; set; }=null!;
}
