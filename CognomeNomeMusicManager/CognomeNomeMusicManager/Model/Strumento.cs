using System;
using System.ComponentModel.DataAnnotations;

namespace CognomeNomeMusicManager.Model;

public class Strumento
{
    [Key]
 public int Id { get; set; }
 public string Nome { get; set; } = null!;
public Abilità Abilità { get; set; }=null!;

}
