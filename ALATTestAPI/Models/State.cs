using System.Collections.Generic;

namespace ALATTestAPI.Models
{
    public class State
    {
        public int id { get; set; }
        public string statename { get; set; }
        public List<LGA> lGAs { get; set; }
    }
}
