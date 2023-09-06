using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace Schronisko.Models
{
    public class News
    {
        [Key]
        [Display(Name = "Identyfikator newsa: ")]
        public int NewsID { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł aktualności: ")]
        [Display(Name = "Tytuł aktualności: ")]
        [MaxLength(25, ErrorMessage = "Tytuł aktualności nie może być dłuższy niż 25 znaków.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Proszę podać treść aktualności: ")]
        [Display(Name = "Treść aktualności: ")]
        [MaxLength(550, ErrorMessage = "Treść aktualności nie może być dłuższa niż 550 znaków.")]
        public string? NewsText { get; set; }

        [Required(ErrorMessage = "Proszę podać status aktualności: ")]
        [Display(Name = "Status aktualności: ")]
        public string? Status { get; set; }

        [Display(Name = "Autor:")]
        public string? Id { get; set; }
        //Autor ogłoszenia
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Zdjęcie:")]
        [MaxLength(128)]
        [FileExtensions(Extensions = ". jpg,. png,. gif", ErrorMessage = "Niepoprawne rozszerzenie pliku.")]
        public string? Photo { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public System.DateTime AddedDate { get; set; }


        //lista wszystkich komentarzy newsa
        public virtual List<Comment>? Comments { get; set; }
    }

/*    public enum NewsStatus
    {
        archiwalne = 3, //news w tym statusie nie jest już wyświetlany gościom strony i jest widoczny tylko na liście dla administratorów
        widoczne = 2, //news wyświelany gościom strony
        robocze = 1, //news w trakcie przygotowania, nie jest jeszcze wyświelany
    }*/
}
