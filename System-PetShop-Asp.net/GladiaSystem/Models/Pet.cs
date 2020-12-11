using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class Pet
    {
        [Display(Name = "Pet")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo nome do pet é obrigatório")]
        [Display(Name = "Nome do pet")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo nome do dono é obrigatório")]
        [Display(Name = "Nome do dono")]
        public string Owner { get; set; }

        [Display(Name = "Celular (xx xxxx-xxxx)")]
        [Required(ErrorMessage = "O campo celular é obrigatório")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "O campo tamanho é obrigatório")]
        [Display(Name = "Tamanho do pet")]
        public string Size { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [Display(Name = "Descrição do pet")]
        public string Desc { get; set; }

    }
}