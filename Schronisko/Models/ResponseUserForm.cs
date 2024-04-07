using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class ResponseUserForm
    {
        [Key]
        [Display(Name = "Identyfikator wypełnienia ankiety: ")]
        public int ResponseUserFormID { get; set; }

        [Display(Name = "Identyfikator ankiety: ")]
        public int UserFormID { get; set; }

        [Display(Name = "Punkty:")]
        public int Points { get; set; }
        public int TotalPoints { get; set; }


        [Display(Name = "Ankieta wypełniona przez:")]
        public string? Id { get; set; }
        //Id użytkownika wypełniającego ankietę
        [Display(Name = "Użytkownik:")]
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Data dodania:")]
        public System.DateTime AddedDate { get; set; }


        //lista pytań w ankiecie
        public virtual List<ResponseUserFormQuestion>? ResponseQuestions { get; set; }
    }


}
