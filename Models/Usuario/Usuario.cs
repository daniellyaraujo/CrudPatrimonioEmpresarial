using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudPatrimonioEmpresarial.Models.Usuario
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Key]
        [Column("Email")]
        [Display(Name = "Email Usuario")]
        [Required(ErrorMessage = "O Email é obrigatório.")]
        public string Email { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha Usuario")]
        [Required(ErrorMessage = "A Senha é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}