using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore_API.Contracts;
using BookStore_API.Data;
using BookStore_API.Mappings.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with Authors
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //TODO:
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, ILoggerService logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns>List of Authors</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                _logger.LogInfo("Attempted Get All Authors");
                var authors = await _authorRepository.FindAll();
                var response = _mapper.Map<IList<AuthorDTO>>(authors);
                //_logger.LogInfo("Success Get All Authors");
                return Ok(response);
            }
            catch(Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns>List of Authors</returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                _logger.LogInfo($"Attempted Get An Author with id: {id}");
                var author = await _authorRepository.FindById(id);
                if (author == null)
                {
                    _logger.LogWarn($"Author with id {id} was not found");
                    return NotFound();
                }
                var response = _mapper.Map<AuthorDTO>(author);

                return Ok(response);
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //[Authorize(Roles = "Administrator, Customer")]
        public async Task<IActionResult> Create([FromBody] AuthorCreateDTO authorDTO)
        {
            if (authorDTO == null)
            {
                _logger.LogWarn("Empty Author Post Request submitted");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("Invalid Author Data Post Request submitted");
                return BadRequest(ModelState);
            }

            var author = _mapper.Map<Author>(authorDTO);
            try
            {
                var isSuccess = await _authorRepository.Create(author);
                if (!isSuccess)
                {
                    return GetInternalError("Cannot create author");
                }

                return Created("Create", new {author});
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Change existing Author
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<IActionResult> Update(int id, [FromBody] AuthorUpdateDTO authorDTO)
        {
            if (id < 1 || authorDTO == null)
            {
                _logger.LogWarn("Empty Author Put Request submitted");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("Invalid Author Data Put Request submitted");
                return BadRequest(ModelState);
            }

            if (id != authorDTO.Id)
            {
                _logger.LogWarn("Id mismatch Request submitted");
                return BadRequest(ModelState);
            }

            var author = _mapper.Map<Author>(authorDTO);
            try
            {
                var isSuccess = await _authorRepository.Update(author);
                if (!isSuccess)
                {
                    return GetInternalError("Cannot update author");
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Delete existing Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                _logger.LogWarn("Wrong Author id Delete Request submitted");
                return BadRequest(ModelState);
            }

            var author = await _authorRepository.FindById(id);
            if (author == null)
            {
                _logger.LogWarn("Wrong Author id Delete Request submitted");
                return NotFound();
            }
            try
            {
                var isSuccess = await _authorRepository.Delete(author);
                if (!isSuccess)
                {
                    return GetInternalError("Cannot delete author");
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        private IActionResult GetInternalError(Exception e)
        {
            return GetInternalError($"{e.Message} - {e.InnerException?.Message}");
        }

        private IActionResult GetInternalError(string message)
        {
            _logger.LogError($"{GetActionInfo()} - {message}");
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

        private string GetActionInfo()
        {
            return
                $"{ControllerContext.ActionDescriptor.ControllerName} - {ControllerContext.ActionDescriptor.ActionName}";
        }
    }
}
