﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAPI.Models
{
    [Table("Tbl_Plano")]
    public class Plano
    {
        [Column("Id")]
        public int PlanoId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        public ICollection<Animal> Animais { get; set; }
    }
}
