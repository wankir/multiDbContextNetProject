using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Entity
{
    public class Transactions
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public decimal Amount { get; set; }
        public string Bank { get; set; }
        public DateTime Date { get; set; }
        public bool Flag { get; set; }

    }
}