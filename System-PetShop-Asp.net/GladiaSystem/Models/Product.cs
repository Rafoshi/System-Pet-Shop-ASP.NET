using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O campo nome do cliente é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Desc { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "O campo marca é obrigatório")]
        public string Brand { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo preço é obrigatório")]
        public int Price { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo quantidade é obrigatório")]
        public int Quant { get; set; }

        [Display(Name = "Quantidade minima")]
        [Required(ErrorMessage = "O campo quantidade minima é obrigatório")]
        public int QuantMin{ get; set; }

        [Display(Name = "Imagem")]
        public string img { get; set; }

        public string CategoryName { get; set; }

        [Display(Name = "Categoria")]
        public Category Category { get; set; }

        public Product()
        {
            Category = new Category();
        }
    }
}