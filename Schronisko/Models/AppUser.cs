using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Imię użytkownika:")]
        [MaxLength(20)]
        public string? FirstName { get; set; }

        [Display(Name = "Nazwisko użytkownika:")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        #region dodatkowe pole nieodwzorowywane w bazie
        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion

        [Display(Name = "Informacja o użytkowniku:")]
        [MaxLength(255, ErrorMessage = "Zbyt długi opis - skróć do 255 znaków")]
        public string? Information { get; set; }

        //Lista zwierząt którymi się opiekuje
        public virtual List<Animal>? Animals { get; set; }
        //Lista komenatrzy danego użytkownika
        public virtual List<Comment>? Comments { get; set; }
    }
}
