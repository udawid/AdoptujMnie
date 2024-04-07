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

        [Display(Name = "Identyfikator pytania: ")]
        public int UserFormQuestionID { get; set; }


        //lista odpowiedzi
        public virtual List<ResponseUserFormQuestionOption>? ResponseOptions { get; set; }
    }



}
