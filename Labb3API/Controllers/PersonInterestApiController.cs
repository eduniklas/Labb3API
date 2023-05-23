using APILabb.Models;
using APILabb.Models.DTO;
using APILabb.Repository.Irepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APILabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInterestApiController : Controller
    {
        private readonly IPersonInterestRepository _Db;
        private readonly IMapper _mapper;
        protected ApiResponse _apiresponse;
        public PersonInterestApiController(IPersonInterestRepository Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
            this._apiresponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetPersonInterest(int id)
        {
            try
            {
                IEnumerable<InterestList> personInterest = await _Db.GetAllAsync(i => i.FK_PersonId == id);
                _apiresponse.Result = _mapper.Map<List<InterestListDto>>(personInterest);
                _apiresponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiresponse);
            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess = false;
                _apiresponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiresponse;
        }
        [HttpGet("{id:int}", Name="GetPersonInterestLink")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetLinkInterest(int id)
        {
            try
            {
                IEnumerable<InterestList> personInterest = await _Db.GetAllAsync(i => i.FK_InterestId == id);
                _apiresponse.Result = _mapper.Map<List<InterestListDto>>(personInterest);
                _apiresponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiresponse);
            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess = false;
                _apiresponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiresponse;
        }
    }
}
