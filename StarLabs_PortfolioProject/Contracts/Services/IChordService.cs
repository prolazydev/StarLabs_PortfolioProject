using StarLabs_PortfolioProject.Areas.Admin.ViewModels;
using StarLabs_PortfolioProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarLabs_PortfolioProject.Contracts.Services
{
    public interface IChordService
    {
        Task<List<Chord>> GetAll();

        Task<Chord> Get(int id);

        Task<Chord> Update(ChordViewModel chord);

        Task<Chord> Create(ChordViewModel chord);

        Task<bool> Delete(int id);
    }
}
