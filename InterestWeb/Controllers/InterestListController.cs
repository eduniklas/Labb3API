using AutoMapper;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Newtonsoft.Json;

namespace InterestWeb.Controllers
{
    public class InterestListController : Controller
    {
        private readonly IInterestListService _interestService;
        private readonly IMapper _mapper;
        public InterestListController(IInterestListService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexInterestList()
        {
            List<InterestListDto> list = new();
            var response = await _interestService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<InterestListDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateInterestList()
        {
            //ViewBag["FK_PersonId"] = new SelectList(_interestService.GetAsync(Person, "PersonId", "FirstName"));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterestList(InterestListCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.CreateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterestList));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInterestList(int interestid)
        {
            
            var response = await _interestService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                InterestListDto model = JsonConvert.DeserializeObject<InterestListDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<InterestListUpdateDto>(model));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInterestList(InterestListUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.UpdateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterestList));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInterestList(int interestid)
        {
            var response = await _interestService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                InterestListDto model = JsonConvert.DeserializeObject<InterestListDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInterestList(InterestListDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.DeleteAsync<ApiResponse>(model.InterestListId);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterestList));
                }
            }
            return View();
        }
    }
}
