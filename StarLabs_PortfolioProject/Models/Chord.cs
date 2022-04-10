using System.ComponentModel.DataAnnotations;

namespace StarLabs_PortfolioProject.Models
{
    public class Chord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
 
        public byte[] Photo { get; set; }
        
        public bool isItLearned { get; set; }
    }
}
