using Microsoft.AspNetCore.Http;

namespace StarLabs_PortfolioProject.Areas.Admin.ViewModels
{
    public class ChordViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile Photo { get; set; }
    }
}
