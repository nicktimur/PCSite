using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCSite.Models;

public partial class Ozellik
{
    public int Id { get; set; }

    [Required]
    public string OzellikAdi { get; set; }

    [Required]
    public string OzellikTuru { get; set; }

    public ICollection<UrunOzellik> UrunOzelliks { get; set; } = new List<UrunOzellik>();
}
