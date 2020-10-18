using Cryptocoin.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Threading.Tasks;

namespace Cryptocoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferReceivedController : ControllerBase
    {
        const string key = "E546C8DF278CD5931069B522E695D4F2";

        [HttpGet("QrCodeReceived/{qrCode}")]
        public async Task<ActionResult<TransferSentViewModel>> QrCodeReceived(string qrCode)
        {

            string data = CryptHelper.Rijndael.Decrypt(qrCode, key);

            TransferSentViewModel model = JsonConvert.DeserializeObject<TransferSentViewModel>(data);
            return await Task.Run(() => { return Ok(model); });
        }
        [HttpGet("ValidTransferQrCode/{qrCode}")]
        public async Task<ActionResult<TransferSentViewModel>> ValidTransferQrCode(string qrCode)
        {
            string data = CryptHelper.Rijndael.Decrypt(qrCode, key);
            return await Task.Run(() => { return Ok(); });
        }
    }
}
