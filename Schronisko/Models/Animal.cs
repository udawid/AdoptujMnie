﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class Animal
    {
        [Key]
        [Display(Name = "Identyfikator zwierzęcia: ")]
        public int AnimalID { get; set; }

        [Required(ErrorMessage = "Proszę podać imię zwierzęcia: ")]
        [Display(Name = "Imie zwierzęcia: ")]
        [MaxLength(25, ErrorMessage = "Imie zwierzęcia nie może być dłuższe niż 25 znaków.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Proszę podać opis zwierzęcia: ")]
        [Display(Name = "Opis zwierzęcia: ")]
        [MaxLength(550, ErrorMessage = "Opis zwierzęcia nie może być dłuższe niż 550 znaków.")]
        public string? Description { get; set; }

        //[Required(ErrorMessage = "Proszę podać gatunek zwierzęcia: ")]
        //[Display(Name = "Gatunek zwierzęcia: ")]
        //public string? Type { get; set; }
        [Required(ErrorMessage = "Proszę podać gatunek zwierzęcia: ")]
        [Display(Name = "Gatunek zwierzęcia: ")]
        [DefaultValue(1)]
        public int AnimalTypeID { get; set; }
        // Komentowany news
        [ForeignKey("AnimalTypeID")]
        public virtual AnimalType? AnimalType { get; set; }

        [Required]
        [Display(Name = "Status zwierzęcia:  ")]
        public string? Status { get; set; }

        [Required]
        [Display(Name = "Czy dostępne? ")]
        [DefaultValue(true)]
        public bool Dostepnosc { get; set; }

/*        [Display(Name = "Opiekun:")]
        public string? Id { get; set; }*/

        //Pracownik opiekun zwierzęcia
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        [Display(Name = "Zdjęcie zwierzęcia:")]
        [MaxLength(128)]
        [FileExtensions(Extensions = ". jpg,. png,. gif", ErrorMessage = "Niepoprawne rozszerzenie pliku.")]
        public string? Photo { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime AddedDate { get; set; }


        //lista wszystkich komentarzy zwierzęcia
        public virtual List<Comment>? Comments { get; set; }
    }

    /* public enum TypeOfAnimal
     {
         inny = 3,
         kot = 2,
         pies = 1,
     }

     public enum AnimalStatus
     {
         adopcjaZakonczona = 6,
         adoptowanyOkresProbny = 5,
         wTrakcieAdopcji = 4,
         doAdopcji = 3,
         wTrakcieBadanIPrzygotowania = 2,
         oczekujeNaPrzyjecie = 1,
     }*/

    public class AnimalType
    {
        [Key]
        [Display(Name = "Identyfikator typu zwierzęcia: ")]
        public int AnimalTypeID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę typu zwierzęcia: ")]
        [Display(Name = "Nazwa typu zwierzęcia: ")]
        [MaxLength(20, ErrorMessage = "Nazwa typu zwierzęcia nie może być dłuższe niż 20 znaków.")]
        public string? Name { get; set; }

        //lista wszystkich zwierzat danego typu
        //public virtual List<Animal>? Animals { get; set; }
    }
}
