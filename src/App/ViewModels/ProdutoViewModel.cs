using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Http;

namespace App.ViewModels
{
    public class ProdutoViewModel
    {

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        //public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        /* Entity Framework Relation */
        [NotMapped]
        public FornecedorViewModel Fornecedor { get; set; }
    


    }
}
