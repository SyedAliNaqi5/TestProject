using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProject.Domain.Entities;
using TestProject.Domain.ViewModels;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepo<BasicInfo> _repo;
        private readonly IMapper _mapper;
        private readonly IPaginationRepo _paginationRepo;

        public InfoController(ILoggerManager logger, IRepo<BasicInfo> repo, IMapper mapper, IPaginationRepo paginationRepo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
            _paginationRepo = paginationRepo;
        }

        [HttpPost("Add")]
        public IActionResult AddInfo(BasicInfoViewModel model)
        {
            try
            {

                 _repo.Insert(_mapper.Map<BasicInfoViewModel, BasicInfo>(model));

                return Ok(new { StatusCode = 200 , message="Record added successfully"});
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetInfo()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }
        [HttpPut("Update")]
        public IActionResult Update(BasicInfoViewModel model)
        {
            try
            {
                 _repo.Update(_mapper.Map<BasicInfoViewModel, BasicInfo>(model));

                return Ok(new { StatusCode = 200, message = "Record updated successfully" });
            
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok(new { StatusCode = 200, message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }

        [HttpGet("GetByPage/{count}")]
        public IActionResult GetByPage(int count)
        {
            try
            {
                return Ok(_paginationRepo.GetRecords(count));
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, ex.Message);
                return Ok(new { StatusCode = 500, message = "Something went wrong" });

            }
        }
    }
}
