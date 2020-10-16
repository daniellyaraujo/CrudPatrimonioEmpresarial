using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudPatrimonioEmpresarial.Models.Marca
{
    [Table(nameof(Marca))]
    public class Marca
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome da marca é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Key]
        [Column("Id")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O id da marca é obrigatório", AllowEmptyStrings = false)]
        public int MarcaId { get; set; }
    }
}