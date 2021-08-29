using System;
using System.IO;
using System.Drawing;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using NFT.Storage.Client;
using NFT.Storage.Model;
using ScalableNFTApi.Request;
using Modern.NFT.Generator;
using Microsoft.Extensions.Configuration;

namespace ScalableNFTApi.Service
{
    public interface IModernArtService
    {
        Task<List<UploadResponse>> Generate(ModernArtRequest modernArtRequest);
    }

    public class ModernArtService : BaseService, IModernArtService
    {
        private readonly string exePath;
        private readonly IConfiguration configuration;
        private readonly string NFTStorageApiKey;

        public ModernArtService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.NFTStorageApiKey = configuration.GetValue<string>("NFTStorageApiKey");
            exePath = Path.GetDirectoryName(
             Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Generate the modern art work based on the ModernArtRequest
        /// </summary>
        /// <param name="modernArtRequest"></param>
        /// <returns>Collection of UploadResponse</returns>
        public async Task<List<UploadResponse>> Generate(ModernArtRequest modernArtRequest)
        {
            List<UploadResponse> uploadResponses = new List<UploadResponse>(); 
            string uniqueId = Guid.NewGuid().ToString();
            string uniqueModernArtPath = $"{exePath}\\ModernArt\\{uniqueId}";

            IModernArtGenerator modernArtGenerator = new ModernArtGenerator(500, 500);
            modernArtGenerator.Generate(uniqueId,
                modernArtRequest.Count,
                modernArtRequest.GeometricStyle, 
                modernArtRequest.ImageFilter,
                withGlass: modernArtRequest.WithGlass,
                withMustashe: modernArtRequest.WithMustashe,
                withMask: modernArtRequest.WithMask,
                withSmoke: modernArtRequest.WithSmoke,
                withHat: modernArtRequest.WithHat);

            if (Directory.Exists(uniqueModernArtPath))
            {
                var modernArtCollection = Directory.GetFiles(uniqueModernArtPath);
                
                foreach(var file in modernArtCollection)
                {
                    Image image = Image.FromFile(file);

                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("Authorization",
                        $"Bearer {NFTStorageApiKey}");

                    NFTStorageClient storageApi = new NFTStorageClient(httpClient);

                    UploadResponse imageUploadResponse =
                        await storageApi.StoreAsync(ToStream(image));

                    uploadResponses.Add(imageUploadResponse);
                }
            }

            return uploadResponses;
        }
    }
}
