using System.ComponentModel.DataAnnotations;

namespace ALATTestAPI.Models
{
    public class Customer

    {
        public int id { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid!!")]
        public string email { get; set; }
        public string phone { get; set; }
        public LGA lga { get; set; }
        public State state { get; set; }
    }
}
