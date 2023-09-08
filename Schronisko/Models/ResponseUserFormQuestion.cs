using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class ResponseUserFormQuestion
    {
        [Key]
        [Display(Name = "Identyfikator odpowiedzi na pytanie: ")]
        public int ResponseUserFormQuestionID { get; set; }

        public int ResponseUserFormID { get; set; }
        [ForeignKey("ResponseUserFormID")]
        public virtual ResponseUserForm? ResponseForm { get; set; }

        //kopia pól z UserFormQuestion, ponieważ UserFormQuestion może być edytowany

        [Display(Name = "Identyfikator pytania: ")]
        public int UserFormQuestionID { get; set; }

        ////Ankieta, do której zostanie przypisane pytanie
        //[Required(ErrorMessage = "Proszę podać ID ankiety: ")]
        //[Display(Name = "Ankieta: ")]
        //public int UserFormID { get; set; }
        //[ForeignKey("UserFormID")]
        //public virtual UserForm? Form { get; set; }

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
        //[ForeignKey("UserFormQuestionTypeID")]
        //public virtual UserFormQuestionType? QuestionType { get; set; }

        //END - kopia pól z UserFormQuestion, ponieważ UserFormQuestion może być edytowany


        //[Display(Name = "Ankieta wypełniona przez:")]
        //public string? Id { get; set; }
        ////Id użytkownika wypełniającego ankietę
        //[ForeignKey("Id")]
        //public virtual AppUser? User { get; set; }

        //[Display(Name = "Data dodania:")]
        //[DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        //public System.DateTime AddedDate { get; set; }


        //lista odpowiedzi
        public virtual List<ResponseUserFormQuestionOption>? ResponseOptions { get; set; }
    }



}
