using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Models
{
    public class BigAgenda
    {
        //[Required(ErrorMessage = "O campo nome do pet é obrigatório")]
        //public Pet Name { get; set; }

        //[Required(ErrorMessage = "O campo nome do dono é obrigatório")]
        //public Pet Owner { get; set; }

        //[Display(Name = "Celular (xx xxxx-xxxx)")]
        //[Required(ErrorMessage = "O campo celular é obrigatório")]
        //public Pet Tel { get; set; }

        //[Required(ErrorMessage = "O campo tamanho é obrigatório")]
        //public Pet Size { get; set; }

        //[Required(ErrorMessage = "O campo descrição é obrigatório")]
        //public Pet Desc { get; set; }

        //public int ID { get; set; }

        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "O campo nome do cliente é obrigatório")]
        public Agenda ClientName { get; set; }

        [Required(ErrorMessage = "O campo pet é obrigatório")]
        public Agenda Pet { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public Agenda DescAgenda { get; set; }

        [Display(Name = "Dia")]
        [Required(ErrorMessage = "O campo de Data é obrigatório")]
        [DataType(DataType.Date)]
        public Agenda Day { get; set; }

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "O campo hora é obrigatório")]
        [DataType(DataType.Time)]
        public Agenda Hour { get; set; }

        public BigAgenda()
        {
            ClientName = new Agenda();
            Pet = new Agenda();
            DescAgenda = new Agenda();
            Day = new Agenda();
            Hour = new Agenda();

            //Desc = new Pet();
            //Size = new Pet();
            //Tel = new Pet();
            //Owner = new Pet();
            //Name = new Pet();
        }

    }
}