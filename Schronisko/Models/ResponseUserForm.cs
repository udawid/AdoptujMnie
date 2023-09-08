﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class ResponseUserForm
    {
        [Key]
        [Display(Name = "Identyfikator wypełnienia ankiety: ")]
        public int ResponseUserFormID { get; set; }


        //kopia pól z UserForm, ponieważ UserForm może być edytowany

        [Display(Name = "Identyfikator ankiety: ")]
        public int UserFormID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ankiety: ")]
        [Display(Name = "Nazwa ankiety: ")]
        [MaxLength(50, ErrorMessage = "Nazwa ankiety nie może być dłuższe niż 25 znaków.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł ankiety: ")]
        [Display(Name = "Tytuł ankiety: ")]
        [MaxLength(150, ErrorMessage = "Tytuł ankiety nie może być dłuższe niż 550 znaków.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Proszę podać opis ankiety: ")]
        [Display(Name = "Opis ankiety: ")]
        [MaxLength(550, ErrorMessage = "Opis ankiety nie może być dłuższe niż 550 znaków.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Proszę podać typ ankiety: ")]
        [Display(Name = "Typ ankiety: ")]
        [DefaultValue(1)]
        public int UserFormTypeID { get; set; }
        //[ForeignKey("UserFormTypeID")]
        //public virtual UserFormType? FormType { get; set; }

        //END - kopia pól z UserForm, ponieważ UserForm może być edytowany



        [Display(Name = "Ankieta wypełniona przez:")]
        public string? Id { get; set; }
        //Id użytkownika wypełniającego ankietę
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime AddedDate { get; set; }


        //lista pytań w ankiecie
        public virtual List<ResponseUserFormQuestion>? ResponseQuestions { get; set; }
    }


}
