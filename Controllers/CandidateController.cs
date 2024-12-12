using AutoMapper;
using Backend.Core.Context;
using Backend.Core.Dtos.Candidate;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }
        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        //CRUD
        //CREATE 
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile )

        {
            //first = save pdf to server 
            //then = save the url into our entity
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";
            if(pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents" , "pdfs",resumeUrl);
             using( var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeUrl = resumeUrl;
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate saved successfully");
        }

        //Read
        //Read(Get job by id)
        //Update
        //Delete

    }
}
