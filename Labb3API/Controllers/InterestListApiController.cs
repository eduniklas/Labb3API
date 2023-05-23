using APILabb.Models.DTO;
using APILabb.Models;
using APILabb.Repository.Irepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APILabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestListApiController : Controller
    {
        private readonly IInterestListRepository _InterestListDb;
        private readonly IRepository<Interest> _InterestDb;
        private readonly IMapper _mapper;
        protected ApiResponse _apiresponse;
        public InterestListApiController(IInterestListRepository interestListDb, IMapper mapper)
        {
            _InterestListDb = interestListDb;
            _mapper = mapper;
            this._apiresponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetInterestList()
        {
            try
            {
                IEnumerable<InterestList> interestList = await _InterestListDb.GetAllAsync();
                _apiresponse.Result = _mapper.Map<List<InterestListDto>>(interestList);
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

        [HttpGet("{id:int}", Name = "GetInterestList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetInterestList(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var interest = await _InterestListDb.GetAsync(i => i.InterestListId == id);
                if (interest == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }
                _apiresponse.Result = _mapper.Map<InterestListDto>(interest);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateInterestList([FromBody] InterestListCreateDto createDto)
        {
            try
            {
                if (await _InterestListDb.GetAsync(i => i.PageUrl.ToLower() == createDto.PageUrl.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom error", "This interest url already exist");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                InterestList interest = _mapper.Map<InterestList>(createDto);
                await _InterestListDb.CreateAsync(interest);
                _apiresponse.Result = _mapper.Map<InterestListDto>(interest);
                _apiresponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetInterestList", new { id = interest.InterestListId }, _apiresponse);

            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess = false;
                _apiresponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiresponse;
        }

        [HttpDelete("{id:int}", Name = "DeleteInterestList")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeleteInterestList(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var interest = await _InterestListDb.GetAsync(i => i.InterestListId == id);
                if (interest == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }

                await _InterestListDb.RemoveAsync(interest);
                _apiresponse.StatusCode = HttpStatusCode.NoContent;
                _apiresponse.IsSuccess = true;
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

        [HttpPut("{id:int}", Name = "UpdateInterestList")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateInterestList(int id, [FromBody] InterestListCreateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.InterestListId)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                InterestList model = _mapper.Map<InterestList>(updateDto);

                await _InterestListDb.UpdateAsync(model);
                _apiresponse.StatusCode = HttpStatusCode.NoContent;
                _apiresponse.IsSuccess = true;
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
