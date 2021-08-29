using Modern.NFT.Generator;

namespace ScalableNFTApi.Request
{
    public class ModernArtRequest
    {
        public int Count { get; set; }
        public GeometricStyle GeometricStyle { get; set; }
        public ImageFilter ImageFilter { get; set; }

        public bool WithHat { get; set; }
        public bool WithGlass { get; set; }
        public bool WithMustashe { get; set; }
        public bool WithMask { get; set; }
        public bool WithSmoke { get; set; }
    }
}
