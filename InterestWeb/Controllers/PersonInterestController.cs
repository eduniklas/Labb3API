using AutoMapper;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InterestWeb.Controllers
{
    public class PersonInterestController : Controller
    {
        private readonly IPersonInterestService _interestService;
        private readonly IMapper _mapper;
        public PersonInterestController(IPersonInterestService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }
        public async Task<IActionResult> DetailsInterestList(int id)
        {
            int a = 4;
            List<InterestListDto> list = new();
            var response = await _interestService.GetAllAsync<ApiResponse>(a);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<InterestListDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
