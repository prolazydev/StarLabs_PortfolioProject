using AutoMapper;
using StarLabs_PortfolioProject.Areas.Admin.ViewModels;
using StarLabs_PortfolioProject.Contracts.Repositories;
using StarLabs_PortfolioProject.Contracts.Services;
using StarLabs_PortfolioProject.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StarLabs_PortfolioProject.Services
{
    public class ChordService : IChordService
    {
        private readonly IChordRepository _chordRepository;
        private readonly IMapper _mapper;

        public ChordService(IChordRepository chordRepository, IMapper mapper)
        {
            _chordRepository = chordRepository;
            _mapper = mapper;
        }

        public async Task<Chord> Create(ChordViewModel chordViewModel)
        {
            byte[] pictureBytes = null;
            Chord chordModel = _mapper.Map<Chord>(chordViewModel);

            using (var stream = new MemoryStream())
            {
                await chordViewModel.Photo.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                chordModel.Photo = pictureBytes;
            }

            chordModel.isItLearned = false;

            return await _chordRepository.Create(chordModel);
        }

        public async Task<bool> Delete(int id)
        {
            var chord = await _chordRepository.Get(id);

            if(chord is not null)
                return await _chordRepository.Delete(chord);

            return false;
        }

        public async Task<Chord> Get(int id)
        {
            return await _chordRepository.Get(id);
        }

        public async Task<List<Chord>> GetAll()
        {
            return await _chordRepository.GetAll();
        }

        public async Task<Chord> Update(ChordViewModel chordViewModel)
        {
            byte[] pictureBytes = null;
            Chord chordModel = _mapper.Map<Chord>(chordViewModel);

            using (var stream = new MemoryStream())
            {
                await chordViewModel.Photo.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                chordModel.Photo = pictureBytes;
            }

            chordModel.isItLearned = false;

            return await _chordRepository.Update(chordModel);
        }
    }
}
