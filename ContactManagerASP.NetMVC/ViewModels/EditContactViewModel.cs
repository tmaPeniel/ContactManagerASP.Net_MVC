using System.ComponentModel.DataAnnotations;

namespace ContactManagerASP.NetMVC.ViewModels
{
    public class EditContactViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "L'adresse e-mail n'est pas valide.")]  
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Le numéro de téléphone doit comporter 10 chiffres.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Le numéro de téléphone doit être exactement de 10 chiffres.")]
        public string Numero { get; set; }

    }
}
