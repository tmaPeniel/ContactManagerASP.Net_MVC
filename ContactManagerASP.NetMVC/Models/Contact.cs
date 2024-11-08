using System.ComponentModel.DataAnnotations;

namespace ContactManagerASP.NetMVC.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "L'adresse e-mail n'est pas valide.")]  //Permet de verifier la struture "username@domaine.com"
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Le numéro de téléphone doit comporter 10 chiffres.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Le numéro de téléphone doit être exactement de 10 chiffres.")]
        public string Numero { get; set; }
    }
}
