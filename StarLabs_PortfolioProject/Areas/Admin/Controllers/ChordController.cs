using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarLabs_PortfolioProject.Areas.Admin.ViewModels;
using StarLabs_PortfolioProject.Contracts.Services;
using System.Threading.Tasks;

namespace StarLabs_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChordController : Controller
    {
        private readonly IChordService _chordService;
        private readonly IMapper _mapper;

        public ChordController(IChordService chordService, IMapper mapper)
        {
            _chordService = chordService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var chordList = await _chordService.GetAll();
            return View(chordList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChordViewModel model)
        {
            var result = await _chordService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var chord = await _chordService.Get(id);
            if(chord is not null)
            {
                var mappedChord = _mapper.Map<ChordViewModel>(chord);
                return View(mappedChord);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ChordViewModel model)
        {
            var result = await _chordService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _chordService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

