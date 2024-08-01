using System;
using System.Collections.Generic;

namespace PCSite.Models;

public partial class Sepet
{
    public int Id { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<Sepeturun> Sepeturuns { get; set; } = new List<Sepeturun>();
}
