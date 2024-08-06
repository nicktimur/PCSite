using System;
using System.Collections.Generic;

namespace PCSite.Models;

public partial class KullaniciAddingModel
{
    public int Id { get; set; }

    public string Ad { get; set; }

    public string Soyad { get; set; }

    public string Email { get; set; }

    public string Sifre { get; set; }

    public string TelefonNumarasi { get; set; }

}
