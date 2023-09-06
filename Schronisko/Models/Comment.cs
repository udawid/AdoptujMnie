using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Schronisko.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "Identyfikator komentarza: ")]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Proszę podać treść: ")]
        [Display(Name = "Treść komentarza: ")]
        [MaxLength(550, ErrorMessage = "Treść komentarza nie może być dłuższa niż 550 znaków.")]
        public string? CommentText { get; set; }

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


        //Komentarz może być przypisany do zwierzęcia, do ogłoszenia lub do newsa
        //Dlatego wymagane jest żeby jedno z poniższych pól było wypełnione
        [Display(Name = "Komentowane zwierzę:")]
        public int AnimalId { get; set; }
        // Komentowany tekst
        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }

        [Display(Name = "Komentowane ogłoszenie:")]
        public int AnnouncementId { get; set; }
        // Komentowany tekst
        [ForeignKey("AnnouncementId")]
        public virtual Announcement? Announcement { get; set; }

        [Display(Name = "Komentowany news:")]
        public int NewsId { get; set; }
        // Komentowany news
        [ForeignKey("NewsId")]
        public virtual News? News { get; set; }
    }
}
