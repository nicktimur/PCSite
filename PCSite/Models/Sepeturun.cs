using System;
using System.Collections.Generic;

namespace PCSite.Models;

public partial class Sepeturun
{
    public int Id { get; set; }

    public int? SepetId { get; set; }

    public int? UrunId { get; set; }

    public int Miktar { get; set; } = 1;

    public decimal Fiyat { get; set; }

    public virtual Sepet? Sepet { get; set; }

    public virtual Urun? Urun { get; set; }
}
