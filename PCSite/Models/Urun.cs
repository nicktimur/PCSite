using System;
using System.Collections.Generic;

namespace PCSite.Models;

public partial class Urun
{
    public int Id { get; set; }

    public string UrunAdi { get; set; }

    public string Marka { get; set; }

    public float Fiyat { get; set; } = 0;

    public int StokMiktari { get; set; } = 0;

    public string? Kategori { get; set; }

    public int SepetDurumu { get; set; } = 0;

    public DateTime? OlusturmaTarihi { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual ICollection<Sepeturun> Sepeturuns { get; set; } = new List<Sepeturun>();

    public ICollection<UrunOzellik> UrunOzelliks { get; set; } = new List<UrunOzellik>();
}
