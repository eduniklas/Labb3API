using APILabb.Models.DTO;
using APILabb.Models;
using APILabb.Repository.Irepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APILabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApiController : Controller
    {
        private readonly IPersonRepository _Db;
        private readonly IMapper _mapper;
        protected ApiResponse _apiresponse;
        public PersonApiController(IPersonRepository Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
            this._apiresponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetPerson()
        {
            try
            {
                IEnumerable<Person> personList = await _Db.GetAllAsync();
                _apiresponse.Result = _mapper.Map<List<PersonDto>>(personList);
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

        [HttpGet("{id:int}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetPerson(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var person = await _Db.GetAsync(i => i.PersonId == id);
                if (person == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }
                _apiresponse.Result = _mapper.Map<PersonDto>(person);
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
        public async Task<ActionResult<ApiResponse>> CreatePerson([FromBody] PersonCreateDto createDto)
        {
            try
            {
                if (await _Db.GetAsync(p => p.PhoneNumber == createDto.PhoneNumber) != null)
                {
                    ModelState.AddModelError("Custom error", "This phonenumber already exist");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                Person person = _mapper.Map<Person>(createDto);
                await _Db.CreateAsync(person);
                _apiresponse.Result = _mapper.Map<PersonDto>(person);
                _apiresponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPerson", new { id = person.PersonId}, _apiresponse);

            }
            catch (Exception ex)
            {
                _apiresponse.IsSuccess = false;
                _apiresponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiresponse;
        }

        [HttpDelete("{id:int}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeletePerson(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                var person = await _Db.GetAsync(p => p.PersonId == id);
                if (person == null)
                {
                    _apiresponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiresponse);
                }

                await _Db.RemoveAsync(person);
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

        [HttpPut("{id:int}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdatePerson(int id, [FromBody] PersonUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.PersonId)
                {
                    _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiresponse);
                }
                Person model = _mapper.Map<Person>(updateDto);

                await _Db.UpdateAsync(model);
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
