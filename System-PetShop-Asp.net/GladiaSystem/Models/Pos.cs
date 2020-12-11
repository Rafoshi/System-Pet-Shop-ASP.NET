using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class Pos
    {
        public int ID { get; set; }

        public int Paid { get; set; }

        public int TotalValue { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Somente números positivos")]
        public int QuantOrder { get; set; }

        public int ProdID { get; set; }

        public int ProdPrice { get; set; }

        public string ProdName { get; set; }

        public Product Product { get; set; }

        public Pos()
        {
            Product = new Product();
        }
    }
}