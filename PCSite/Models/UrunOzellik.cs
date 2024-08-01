using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCSite.Models;

public partial class UrunOzellik
{
    public int Id { get; set; } 

    public int UrunId { get; set; } 

    public int OzellikId { get; set; } 

    [Required]
    [StringLength(255)]
    public string Deger { get; set; } 

    public Urun Urun { get; set; }

    public Ozellik Ozellik { get; set; }
}
