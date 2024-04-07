using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class UserFormQuestionOption
    {
        [Key]
        [Display(Name = "Identyfikator opcji: ")]
        public int UserFormQuestionOptionID { get; set; }

        //Pytanie, do którego zostanie przypisane pytanie
        [Required(ErrorMessage = "Proszę podać ID pytania: ")]
        [Display(Name = "Pytanie: ")]
        public int UserFormQuestionID { get; set; }
        [ForeignKey("UserFormQuestionID")]
        public virtual UserFormQuestion? Question { get; set; }

        //[Required(ErrorMessage = "Proszę podać pozycję odpowiedzi na ankiecie: ")]
        [Display(Name = "Pozycja opcji: ")]
        public int? OptionOrder { get; set; }

        [Required(ErrorMessage = "Proszę podać treść opcji: ")]
        [Display(Name = "Treść opcji: ")]
        [MaxLength(250, ErrorMessage = "Treść opcji nie może być dłuższe niż 250 znaków.")]
        public string? OptionText { get; set; }

        [Display(Name = "Czy dyskwalifikująca? ")]
        [DefaultValue(false)]
        public bool Disqualifying { get; set; }

        [Display(Name = "Punkty: ")]
        //[DefaultValue(true)]
        public int? Points { get; set; }

        [Display(Name = "Autor opcji:")]
        public string? Id { get; set; }
        //Id użytkownika tworzącego opcję
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime AddedDate { get; set; }
    }

}
