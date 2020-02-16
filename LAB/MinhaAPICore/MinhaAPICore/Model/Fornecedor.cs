using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPICore.Model
{
    public class Fornecedor
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100,ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Documento { get; set; }

        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }

    }
}
