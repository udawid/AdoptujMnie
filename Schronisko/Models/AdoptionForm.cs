using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class AdoptionForm
    {
        [Key]
        public int FormId { get; set; }
        public int AnimalId { get; set; } // Przykładowe pole związane z wyborem konkretnego zwierzęcia
        public string? CurrentUserName { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "1. Czy miałeś wcześniej zwierzęta domowe?")]
        public string? Answer1 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "2. Czy obecnie posiadasz inne zwierzęta w domu?")]
        public string? Answer2 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "3. Czy w domu są dzieci?")]
        public string? Answer3 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "4. Czy w domu ktoś ma alergię na zwierzęta?")]
        public bool? Answer4 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "5. Czy mieszkasz w domu czy mieszkaniu?")]
        public string? Answer5 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "6. Czy masz ogród? Jeśli tak, czy jest ogrodzony?")]
        public string? Answer6 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "7. Gdzie będzie trzymany zwierzak?")]
        public string? Answer7 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "8. Jak często planujesz wyprowadzać psa na spacer?")]
        public string? Answer8 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "9. Ile czasu będziesz mógł/mogła poświęcić zwierzakowi?")]
        public string? Answer9 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "10. Czy jesteś gotów zapewnić odpowiednią ilość aktywności fizycznej dla zwierzęcia?")]
        public string? Answer10 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "11. Czy jesteś gotów zapewnić regularną opiekę weterynaryjną dla adoptowanego zwierzęcia?")]
        public bool? Answer11 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "12. Jaki rodzaj zwierzęcia chciałbyś adoptować? (pies, kot, królik, inne)")]
        public string? Answer12 { get; set; }

        [Display(Name = "13. Czy masz preferencje co do wieku, wielkości, rasy itp.?")]
        public string? Answer13 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "14. Czy Twoje obecne zwierzęta są przyjazne wobec innych zwierząt?")]
        public bool? Answer14 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "15. Czy ktoś w Twoim domu cierpi na alergie zwierzęce?")]
        public bool? Answer15 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "16. Czy jesteś świadomy potencjalnych problemów zdrowotnych związanych z alergią?")]
        public bool? Answer16 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "17. Czy jesteś gotów zapewnić regularną opiekę weterynaryjną dla adoptowanego zwierzęcia?")]
        public bool? Answer17 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "18. Czy jesteś świadomy kosztów związanych z opieką nad zwierzęciem, takimi jak jedzenie, weterynarz, akcesoria?")]
        public bool? Answer18 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "19. Czy zgadzasz się na ewentualne wizyty kontrolne przed i po adopcji?")]
        public bool? Answer19 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "20. Czy jesteś świadomy ewentualnych problemów zdrowotnych, z którymi zwierzę mogłoby się zmagać?")]
        public bool? Answer20 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "21. Czy jesteś gotów zobowiązać się do opieki nad zwierzęciem przez całe jego życie?")]
        public bool? Answer21 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "22. Czy jesteś gotów uczestniczyć w szkoleniu dla adoptujących zwierzęta?")]
        public bool? Answer22 { get; set; }

        [Display(Name = "23. Jak zamierzasz radzić sobie w przypadku problemów behawioralnych lub zdrowotnych u adoptowanego zwierzęcia?")]
        public string? Answer23 { get; set; }

        [Required(ErrorMessage = "Musisz odpowiedzieć na to pytanie")]
        [Display(Name = "24. Czy jesteś gotów skonsultować się z ekspertem ds. behawioru zwierząt w razie potrzeby?")]
        public bool? Answer24 { get; set; }

    }
}
