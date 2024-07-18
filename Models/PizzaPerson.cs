﻿
namespace PizzaParty.Models
{
    public class PizzaPerson

    {
        public int CustomerID { get; set; }
        public string Name  { get; set; }
        public string Address { get; set; }
        public int Age {  get; set; }
        public char Gender { get; set; }
        public int EventSize { get; set; }
        public IEnumerable<PizzaPerson> Categories { get; internal set; }
    }




}
