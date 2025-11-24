using System;
using Microsoft.EntityFrameworkCore;

namespace CognomeNomeMusicManager.Model;
[PrimaryKey(nameof(StrumentoId), nameof(CantanteId))]
public class Abilità
{
    public int StrumentoId { get; set; }
    public int CantanteId { get; set; }
    public int Livello { get; set; }
    public Strumento Strumento { get; set; }=null!;
    public Cantante Cantante { get; set; }=null!;
}
