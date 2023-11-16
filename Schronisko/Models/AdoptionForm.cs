using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class AdoptionForm
    {
        [Key]
        public int FormId { get; set; }
        public string? UserName { get; set; }
        public string? AnimalName { get; set; }
        public int AnimalId { get; set; } // Przykładowe pole związane z wyborem konkretnego zwierzęcia
        public string? Answer1 { get; set; }

        public string? CurrentUserName { get; set; }
        
        [Display(Name = "Punkty za odpowiedzi")]
        public int Points { get; set; }

    }
}
