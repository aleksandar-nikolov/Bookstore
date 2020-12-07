using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore_API.Contracts;
using BookStore_API.Data;
using BookStore_API.Mappings.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with Books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _env;

        public BooksController(
            IBookRepository bookRepository,
            ILoggerService logger,
            IWebHostEnvironment env,
            IMapper mapper)
            : base(logger, mapper)
        {
            _bookRepository = bookRepository;
            _env = env;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>A list of books</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookRepository.FindAll();
                var booksDto = Mapper.Map<IList<BookDTO>>(books);
                //TODO : foreach consttruct image
                return Ok(booksDto);
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Gets a Book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A book record</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            LogEndpointAttempt();
            if (id < 1)
            {
                Logger.LogWarn($"{GetActionInfo()} - wrong id {id}");
                return BadRequest();
            }

            try
            {
                var book = await _bookRepository.FindById(id);
                if (book == null)
                {
                    Logger.LogWarn($"{GetActionInfo()} - book with id {id} not found");
                    return NotFound();
                }

                var bookDto = Mapper.Map<BookDTO>(book);
                if (!string.IsNullOrWhiteSpace(bookDto.Image))
                {
                    var imgPath = GetImagePath(bookDto.Image);
                    if(System.IO.File.Exists(imgPath))
                    {
                        byte[] imgBytes = System.IO.File.ReadAllBytes(imgPath);
                        bookDto.File = Convert.ToBase64String(imgBytes);
                    }
                }
                return Ok(bookDto);
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        private string? GetImagePath(string bookDtoImage)
        {
            return $"{_env.ContentRootPath}\\uploads\\{bookDtoImage}";
        }

        /// <summary>
        /// Creates book
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns>Book object</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //TODO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO bookDto)
        {
            try
            {
                LogEndpointAttempt();

                if (bookDto == null)
                {
                    Logger.LogWarn($"{GetActionInfo()} - with empty DTO");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    Logger.LogWarn($"{GetActionInfo()} - with incomplete DTO");
                    return BadRequest(ModelState);
                }

                var book = Mapper.Map<Book>(bookDto);

                var isSuccess = await _bookRepository.Create(book);
                if (!isSuccess)
                {
                    return GetInternalError($"{GetActionInfo()}: creation failed");
                }

                await SaveFile(bookDto);
                Logger.LogInfo($"{GetActionInfo()}: creation was successful!");
                return Created("Create", new {book});
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        private async Task SaveFile(BookCreateDTO bookDto)
        {
            if (!string.IsNullOrWhiteSpace(bookDto.File))
            {
                var imgPath = GetImagePath(bookDto.Image);
                byte[] imageBytes = Convert.FromBase64String(bookDto.File);
                await System.IO.File.WriteAllBytesAsync(imgPath, imageBytes);
            }
        }

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        // TODO
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDTO bookDto)
        {
            LogEndpointAttempt();
            if (id < 1 || bookDto == null || bookDto.Id != id)
            {
                Logger.LogWarn($"{GetActionInfo()} - wrong data with id: {id}");
                return BadRequest();
            }

            try
            {
                var bookExists = await _bookRepository.DoesExist(id);
                if (!bookExists)
                {
                    Logger.LogWarn($"{GetActionInfo()} - book with id {id} not found");
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    //TODO : logger
                    return BadRequest(ModelState);
                }

                var oldImageFileName = await _bookRepository.GetImageFileName(id);
                var book = Mapper.Map<Book>(bookDto);
                var success = await _bookRepository.Update(book);

                if (!success)
                {
                    return GetInternalError($"could not update the book with id: {id}");
                }

                if (!bookDto.Image.Equals(oldImageFileName))
                {
                    if (System.IO.File.Exists(GetImagePath(oldImageFileName)))
                    {
                        try
                        {
                            System.IO.File.Delete(GetImagePath(oldImageFileName));
                        }
                        catch
                        {
                            //TODO Log
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(bookDto.File))
                {
                    byte[] imageAsBytes = Convert.FromBase64String(bookDto.File);
                    try
                    {
                        System.IO.File.WriteAllBytes(GetImagePath(bookDto.File), imageAsBytes);
                    }
                    catch
                    {
                        //TODO Log
                    }
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }

        /// <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //todo
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            LogEndpointAttempt();
            if (id < 1)
            {
                Logger.LogWarn($"{GetActionInfo()} called with invalid id: {id}");
                return BadRequest();
            }

            try
            {

                var bookToDelete = await _bookRepository.FindById(id);

                if (bookToDelete == null)
                {
                    Logger.LogWarn($"{GetActionInfo()} called with id: {id} that is not found");
                    return BadRequest();
                }

                var success = await _bookRepository.Delete(bookToDelete);

                if (!success)
                {
                    return GetInternalError($"{GetActionInfo()} - Could not delete book with id: {id}");
                }

                if (!string.IsNullOrWhiteSpace(bookToDelete.Image))
                {
                    try
                    {
                        System.IO.File.Delete(GetImagePath(bookToDelete.Image));
                    }
                    catch
                    {
                        //TODO Log
                    }
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return GetInternalError(e);
            }
        }
    }
}
