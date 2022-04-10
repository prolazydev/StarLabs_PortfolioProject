using StarLabs_PortfolioProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarLabs_PortfolioProject.Contracts.Repositories
{
    public interface IChordRepository
    {
        Task<List<Chord>> GetAll();

        Task<Chord> Get(int id);

        Task<Chord> Update(Chord chord);

        Task<Chord> Create(Chord chord);

        Task<bool> Delete(Chord chord);

        Task<bool> Save();
    }
}
