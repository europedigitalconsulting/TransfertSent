using Cryptocoin.Server.Helpers;
using Cryptocoin.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using System.Threading.Tasks;

namespace Cryptocoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeGeneratorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<byte[]>> Generate(string link)
        {
            return await Task.Run(() =>
            {
                return File(GenerateQrCode(link), "image/png");
            });
        }
        [HttpGet("GenerateForTransfer/{link}")]
        public async Task<ActionResult<byte[]>> GenerateForTransfer(string link)
        {
            string url = "https://localhost:44354/receive/QrCodeReceived?Key=" + link;

            return await Task.Run(() =>
            {
                return File(GenerateQrCode(url), "image/png");
            });
        }
        private byte[] GenerateQrCode(string url)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);
            return qrCodeAsBitmapByteArr;
        }
    }
}
