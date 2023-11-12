using System.ComponentModel.DataAnnotations;

namespace SupermarketWeb.Models
{
    public class User
    {
        public int Id { get; set; }//Sera llave primaria
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
