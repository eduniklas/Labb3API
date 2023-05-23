using AutoMapper;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace InterestWeb.Controllers
{
    public class InterestController : Controller
    {
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;
        public InterestController(IInterestService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexInterest()
        {
            List<InterestDto> list = new();
            var response = await _interestService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<InterestDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateInterest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterest(InterestCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.CreateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterest));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInterest(int interestid)
        {
            var response = await _interestService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                InterestDto model = JsonConvert.DeserializeObject<InterestDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<InterestUpdateDto>(model));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInterest(InterestUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.UpdateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterest));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteInterest(int interestid)
        {
            var response = await _interestService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                InterestDto model = JsonConvert.DeserializeObject<InterestDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInterest(InterestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _interestService.DeleteAsync<ApiResponse>(model.InterestId);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInterest));
                }
            }
            return View();
        }
    }
}
