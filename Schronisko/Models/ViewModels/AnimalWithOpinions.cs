namespace Schronisko.Models.ViewModels
{
    public class AnimalWithOpinions
    {
        public Animal SelectedAnimal { get; set; }
        public int CommentsNumber { get; set; }
        public string Description { get; set; }
   
        public AnimalWithOpinions()
        {
            CommentsNumber = 0;
        }
    }
}
