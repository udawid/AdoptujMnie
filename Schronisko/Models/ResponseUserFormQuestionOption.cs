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

        [Display(Name = "Identyfikator opcji: ")]
        public int UserFormQuestionOptionID { get; set; }

        //ustawione na true jeśli użytkownik zaznaczył daną odpowiedź na ankiecie
        public bool Checked { get; set; }
    }

}
