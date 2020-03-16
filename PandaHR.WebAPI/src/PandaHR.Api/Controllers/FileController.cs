using System;
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
            return await CreateFile(uploadedFile);
        }

        [HttpPost("Flow/{flowId}")]
        public async Task<IActionResult> Upload(Guid flowId, IFormFile uploadedFile)
        {
            return await CreateFile(uploadedFile, flowId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var file = await _fileService.GetFile(id);

            return File(file.Content, "application/octet-stream", file.Name);
        }

        [HttpGet("Flow/{flowId}")]
        public async Task<IActionResult> GetFlowFiles(Guid baseEntiryGuid)
        {
            var result = await _fileService.GetFiles(baseEntiryGuid);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _fileService.IsDocumentExist(id))
            {
                await _fileService.Remove(id);
                return Ok();
            }

            return NotFound();
        }

        private async Task<IActionResult> CreateFile(IFormFile uploadedFile, Guid? flowId = null)
        {
            Guid _flowId = flowId == null ? new Guid() : (Guid)flowId;
            if (uploadedFile != null)
            {
                byte[] content = await uploadedFile.GetBytes();

                NoSQLFile p = new NoSQLFile();
                p.Content = new byte[content.Length];
                content.CopyTo(p.Content, 0);

                p.Name = uploadedFile.FileName;
                p.BaseEntityGuid = _flowId;
                await _fileService.Create(p);

                return Ok(p.Id);
            }

            return BadRequest("File was not transferred!");
        }
    }
}