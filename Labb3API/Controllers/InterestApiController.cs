using APILabb.Data;
using APILabb.Models;
using APILabb.Models.DTO;
using APILabb.Repository.Irepository;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APILabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestApiController : Controller
    {
        private readonly IRepository<Interest> _InterestDb;
        private readonly IMapper _mapper;
        protected ApiResponse _apiresponse;
        public InterestApiController(IRepository<Interest> interestDb, IMapper mapper)
        {
            _InterestDb = interestDb;
            _mapper = mapper;
            this._apiresponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetInterest()
        {
            try
            {
                IEnumerable<Interest> interestList = await _InterestDb.GetAllAsync();
                _apiresponse.Result = _mapper.Map<List<InterestDto>>(interestList);
                _apiresponse.StatusCode=HttpStatusCode.OK;
                return Ok(_apiresponse);
            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess=false;
                _apiresponse.ErrorMessages 
                    = new List<string>() { ex.ToString()};
            }
            return _apiresponse;
        }

        [HttpGet("{id:int}", Name = "GetInterest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetInterest(int id)
        {
            try
            {
                if (id==0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var interest = await _InterestDb.GetAsync(i => i.InterestId == id);
                if (interest == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }
                _apiresponse.Result = _mapper.Map<InterestDto>(interest);
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
        public async Task<ActionResult<ApiResponse>> CreateInterest([FromBody] InterestCreateDto createDto)
        {
            try
            {
                if (await _InterestDb.GetAsync(i=>i.Name.ToLower() == createDto.Name.ToLower())!=null)
                {
                    ModelState.AddModelError("Custom error", "This interest already exist");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                Interest interest = _mapper.Map<Interest>(createDto);
                await _InterestDb.CreateAsync(interest);
                _apiresponse.Result = _mapper.Map<InterestDto>(interest);
                _apiresponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetInterest", new {id=interest.InterestId}, _apiresponse);

            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess = false;
                _apiresponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiresponse;
        }

        [HttpDelete("{id:int}", Name = "DeleteInterest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeleteInterest(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var interest = await _InterestDb.GetAsync(i => i.InterestId == id);
                if (interest == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }

                await _InterestDb.RemoveAsync(interest);
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

        [HttpPut("{id:int}", Name = "UpdateInterest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateInterest(int id, [FromBody] InterestUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.InterestId)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                Interest model = _mapper.Map<Interest>(updateDto);

                await _InterestDb.UpdateAsync(model);
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
        [HttpPatch("{id:int}", Name = "UpdatePartialInterest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialInterest(int id, JsonPatchDocument<InterestUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_apiresponse);
            }

            var interest = await _InterestDb.GetAsync(i => i.InterestId == id, tracked:false);
            Interest model = _mapper.Map<Interest>(patchDto);

            await _InterestDb.UpdateAsync(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
