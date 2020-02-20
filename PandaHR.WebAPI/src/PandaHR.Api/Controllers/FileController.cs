using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.MongoDB;
using PandaHR.Api.DAL.MongoDB.Entities;
using PandaHR.Api.Extensions;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                byte[] content = await uploadedFile.GetBytes();

                NoSQLFile p = new NoSQLFile();
                p.Content = new byte[content.Length];
                content.CopyTo(p.Content, 0);
                
                p.Name = uploadedFile.FileName;
                p.BaseEntityGuid = Guid.NewGuid();
                await _fileService.Create(p);

                return Ok(p.Id);
            }

            return BadRequest("File was not transferred!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var file = await _fileService.GetFile(id);

            return File(file.Content, "application/octet-stream", file.Name);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _fileService.GetFiles(null);
            return Ok(result);
        }
    }
}