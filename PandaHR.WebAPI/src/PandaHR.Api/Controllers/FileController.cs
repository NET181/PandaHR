using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using PandaHR.Api.Utilities;
using PandaHR.Api.Mapper;
using PandaHR.Api.DAL.MongoDB;
using PandaHR.Api.Common.Contracts;
using Microsoft.AspNetCore.Hosting;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IFileService _fileService;
        private IWebHostEnvironment _appEnvironment;

        public FileController(IWebHostEnvironment appEnvironment, IMapper mapper, IFileService fileService)
        {
            _mapper = mapper;
            _fileService = fileService;
            _appEnvironment = appEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile uploadedFile)
        { 
            if (uploadedFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await uploadedFile.CopyToAsync(memoryStream);

                    await _fileService.StoreFile(Guid.NewGuid(), memoryStream, uploadedFile.FileName); 
                }
                //string path = "/Files/" + uploadedFile.FileName;

                //using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                //{
                //    await uploadedFile.CopyToAsync(fileStream);

                //    await _fileService.StoreFile(Guid.NewGuid(), fileStream, uploadedFile.FileName);

                //}  
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _fileService.GetFileAsBytes(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _fileService.GetFiles(null);
            return Ok(result);
        }
    }
}