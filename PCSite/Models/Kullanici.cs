using System;
using System.Collections.Generic;

namespace PCSite.Models;

public partial class Kullanici
{
    public int Id { get; set; }

    public string Ad { get; set; }

    public string Soyad { get; set; }

    public string Email { get; set; }

    public string Sifre { get; set; }

    public int KullaniciTipi { get; set; }

    public int Bakiye { get; set; } = 0;

    public DateTime? GuncellenmeTarihi { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public string? Adres { get; set; }

    public string TelefonNumarasi { get; set; }

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();
}
