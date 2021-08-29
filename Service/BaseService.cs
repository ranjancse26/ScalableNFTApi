using System.Drawing;
using System.IO;

namespace ScalableNFTApi.Service
{
    public class BaseService
    {
        protected static Stream ToStream(Image imageInput)
        {
            var memoryStream = new MemoryStream();
            imageInput.Save(memoryStream, imageInput.RawFormat);
            memoryStream.Position = 0;
            return memoryStream;
        }

        protected static Stream ToStream(string fileName)
        {
            var memoryStream = new MemoryStream(
                System.IO.File.ReadAllBytes(fileName))
            {
                Position = 0
            };
            return memoryStream;
        }
    }
}
