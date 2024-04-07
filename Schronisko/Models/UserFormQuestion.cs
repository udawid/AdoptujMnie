using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class UserFormQuestion
    {
        [Key]
        [Display(Name = "Identyfikator pytania: ")]
        public int UserFormQuestionID { get; set; }

        //Ankieta, do której zostanie przypisane pytanie
        [Required(ErrorMessage = "Proszę podać ID ankiety: ")]
        [Display(Name = "Ankieta: ")]
        public int UserFormID { get; set; }
        [ForeignKey("UserFormID")]
        public virtual UserForm? Form { get; set; }

        //[Required(ErrorMessage = "Proszę podać pozycję pytania na ankiecie: ")]
        [Display(Name = "Pozycja pytania: ")]
        public int? QuestionOrder { get; set; }

        [Required(ErrorMessage = "Proszę podać treść pytania: ")]
        [Display(Name = "Treść pytania: ")]
        [MaxLength(250, ErrorMessage = "Treść pytania nie może być dłuższe niż 250 znaków.")]
        public string? QuestionText { get; set; }

        //dodatkowy opis dostępny tylko dla administratora
        [Display(Name = "Dodatkowy opis pytania: ")]
        [MaxLength(550, ErrorMessage = "Opis pytania nie może być dłuższe niż 550 znaków.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Proszę podać typ pytania: ")]
        [Display(Name = "Typ pytania: ")]
        [DefaultValue(1)]
        public int UserFormQuestionTypeID { get; set; }
        [ForeignKey("UserFormQuestionTypeID")]
        public virtual UserFormQuestionType? QuestionType { get; set; }

        [Display(Name = "Autor pytania:")]
        public string? Id { get; set; }
        //Id użytkownika tworzącego ankietę
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime AddedDate { get; set; }


        //lista odpowiedzi
        public virtual List<UserFormQuestionOption>? Options { get; set; }
    }



    public class UserFormQuestionType
    {
        [Key]
        [Display(Name = "Identyfikator typu pytania: ")]
        public int UserFormQuestionTypeID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę typu pytania: ")]
        [Display(Name = "Nazwa typu pytania: ")]
        [MaxLength(25, ErrorMessage = "Nazwa typu pytania nie może być dłuższe niż 25 znaków.")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Czy aktywna? ")]
        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}
