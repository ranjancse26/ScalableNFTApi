using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using NFT.Storage.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ScalableNFTApi.Request;
using ScalableNFTApi.Service;

namespace ScalableNFTApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ModernArtController : ControllerBase
    {
        private readonly IModernArtService modernArtService;
        private readonly ILogger<ModernArtController> _logger;

        public ModernArtController(ILogger<ModernArtController> logger,
            IModernArtService modernArtService)
        {
            _logger = logger;
            this.modernArtService = modernArtService;
        }

        [HttpPost]
        [Route("build")]
        public async Task<IActionResult> Generate(ModernArtRequest modernArtRequest)
        {
            var nftUploadResponse = new List<UploadResponse>();
            try
            {
                nftUploadResponse = await modernArtService.Generate(modernArtRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.StackTrace);
            }
            return Ok(nftUploadResponse);
        }
    }
}
