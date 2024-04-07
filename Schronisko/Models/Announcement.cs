using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Schronisko.Models
{
    public class Announcement
    {
        [Key]
        [Display(Name = "Identyfikator ogłoszenia: ")]
        public int AnnouncementID { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł ogłoszenia: ")]
        [Display(Name = "Tytuł ogłoszenia: ")]
        [MaxLength(25, ErrorMessage = "Tytuł ogłoszenia nie może być dłuższy niż 25 znaków.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Proszę podać treść: ")]
        [Display(Name = "Treść ogłoszenia: ")]
        [MaxLength(550, ErrorMessage = "Treść ogłoszenia nie może być dłuższa niż 550 znaków.")]
        public string? AnnouncementText { get; set; }

        [Required(ErrorMessage = "Proszę podać status ogłoszenia: ")]
        [Display(Name = "Status ogłoszenia: ")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Proszę podać typ ogłoszenia: ")]
        [Display(Name = "Typ ogłoszenia: ")]
        public string? Type { get; set; }

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


        //lista wszystkich komentarzy ogłoszenia
        public virtual List<Comment>? Comments { get; set; }
    }
}
