using System.ComponentModel.DataAnnotations;

namespace MyOwnWebApplication.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public float clientDebt { get; set; }
        [Required]
        public DateTime paymentDay { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }

    }
}

