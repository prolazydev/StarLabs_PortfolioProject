using System.ComponentModel.DataAnnotations;

namespace StarLabs_PortfolioProject.Models
{
    public class Chord
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        // Need to add Photo
        public bool isItLearned { get; set; }
        // Difficulty to 
    }
}
