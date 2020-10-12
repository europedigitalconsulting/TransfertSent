using Cryptocoin.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Threading.Tasks;

namespace Cryptocoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferReceivedController : ControllerBase
    {
        public string key = "E546C8DF278CD5931069B522E695D4F2";

        [HttpGet("QrCodeReceived/{qrCode}")]
        public async Task<ActionResult<TransferSentViewModel>> QrCodeReceived(string qrCode)
        {

            string data = CryptHelper.Rijndael.Decrypt(qrCode, key);

            TransferSentViewModel model = JsonConvert.DeserializeObject<TransferSentViewModel>(data);
            return Ok(model);
        }
        [HttpGet("ValidTransfer/{qrCode}")]
        public async Task<ActionResult<TransferSentViewModel>> ValidTransfer(string qrCode)
        {
            string data = CryptHelper.Rijndael.Decrypt(qrCode, key);
            return Ok();
        }
    }
}
