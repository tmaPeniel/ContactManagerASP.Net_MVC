using System.ComponentModel.DataAnnotations;

namespace ContactManagerASP.NetMVC.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Format incorect. Veuillez ressaisir")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage ="Format incorrect. Veuillez réessayer")]
        [StringLength(10, ErrorMessage ="Veuillez saisir 10 chiffres")]
        public string Numero { get; set; }
    }
}
