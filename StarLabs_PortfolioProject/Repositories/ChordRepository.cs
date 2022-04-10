using Microsoft.EntityFrameworkCore;
using StarLabs_PortfolioProject.Contracts.Repositories;
using StarLabs_PortfolioProject.Data;
using StarLabs_PortfolioProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarLabs_PortfolioProject.Repositories
{
    public class ChordRepository : IChordRepository
    {
        private readonly ApplicationDbContext _context;

        public ChordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Chord> Create(Chord chord)
        {
            await _context.Chords.AddAsync(chord);
            await Save();
            return chord;
        }

        public async Task<bool> Delete(Chord chord)
        {
            _context.Chords.Remove(chord);
            return await Save();
        }

        public async Task<Chord> Get(int id)
        {
            return await _context.Chords.FindAsync(id);
        }

        public async Task<List<Chord>> GetAll()
        {
            return await _context.Chords.ToListAsync();
        }

        public async Task<bool> Save()
        {
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<Chord> Update(Chord chord)
        {
            _context.Entry(chord).State = EntityState.Modified;
            await Save();
            return chord;
        }
    }
}
