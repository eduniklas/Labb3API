using AutoMapper;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace InterestWeb.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexPerson()
        {
            List<Person> list = new();
            var response = await _personService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Person>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateInterest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterest(PersonCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _personService.CreateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexPerson));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInterest(int interestid)
        {
            var response = await _personService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                Person model = JsonConvert.DeserializeObject<Person>(Convert.ToString(response.Result));
                return View(_mapper.Map<PersonUpdateDto>(model));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInterest(PersonUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _personService.UpdateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexPerson));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteInterest(int interestid)
        {
            var response = await _personService.GetAsync<ApiResponse>(interestid);
            if (response != null && response.IsSuccess)
            {
                Person model = JsonConvert.DeserializeObject<Person>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInterest(Person model)
        {
            if (ModelState.IsValid)
            {
                var response = await _personService.DeleteAsync<ApiResponse>(model.PersonId);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexPerson));
                }
            }
            return View();
        }
    }
}
