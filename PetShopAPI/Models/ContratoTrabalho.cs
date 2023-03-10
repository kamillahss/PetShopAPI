using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAPI.Models
{
    [Table("Tbl_Contrato_Trabalho")]
    public class ContratoTrabalho
    {
        [Column("Id")]
        public int ContratoTrabalhoId { get; set; }

        [Column("Dt_Contratacao", TypeName = "date")]
        public DateTime DataContratacao { get; set; }

        public decimal Valor { get; set; }

        public TipoContrato TipoContrato { get; set; }
    }

    public enum TipoContrato
    {
        Clt, Pj
    }
}
