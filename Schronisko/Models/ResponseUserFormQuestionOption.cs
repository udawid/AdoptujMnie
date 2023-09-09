using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class ResponseUserFormQuestionOption
    {
        [Key]
        [Display(Name = "Identyfikator wybranych opcji: ")]
        public int ResponseUserFormQuestionOptionID { get; set; }

        public int ResponseUserFormQuestionID { get; set; }
        [ForeignKey("ResponseUserFormQuestionID")]
        public virtual ResponseUserFormQuestion? ResponseQuestion { get; set; }


        //kopia pól z UserFormQuestionOption, ponieważ UserFormQuestionOption może być edytowany

        [Display(Name = "Identyfikator opcji: ")]
        public int UserFormQuestionOptionID { get; set; }

        ////Pytanie, do którego zostanie przypisane pytanie
        //[Required(ErrorMessage = "Proszę podać ID pytania: ")]
        //[Display(Name = "Pytanie: ")]
        //public int UserFormQuestionID { get; set; }
        //[ForeignKey("UserFormQuestionID")]
        //public virtual UserFormQuestion? Question { get; set; }

        //[Required(ErrorMessage = "Proszę podać pozycję odpowiedzi na ankiecie: ")]
        [Display(Name = "Pozycja opcji: ")]
        public int? OptionOrder { get; set; }

        [Required(ErrorMessage = "Proszę podać treść opcji: ")]
        [Display(Name = "Treść opcji: ")]
        [MaxLength(250, ErrorMessage = "Treść opcji nie może być dłuższe niż 250 znaków.")]
        public string? OptionText { get; set; }

        //END - kopia pól z UserFormQuestionOption, ponieważ UserFormQuestionOption może być edytowany

        //ustawione na true jeśli użytkownik zaznaczył daną odpowiedź na ankiecie
        public bool Checked { get; set; }

        //[Display(Name = "Ankieta wypełniona przez:")]
        //public string? Id { get; set; }
        ////Id użytkownika wypełniającego ankietę
        //[ForeignKey("Id")]
        //public virtual AppUser? User { get; set; }

        //[Display(Name = "Data dodania:")]
        //[DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        //public System.DateTime AddedDate { get; set; }
    }

}
