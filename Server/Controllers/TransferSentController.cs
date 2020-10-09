using Cryptocoin.Shared;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Threading.Tasks;

namespace Cryptocoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferSentController : ControllerBase
    {
        [HttpGet("InviteUser/{email}")]
        public async Task<ActionResult> InviteUser(string email)
        {
            return await Task.Run(() =>
            {
                return Ok();
            });
        }
        [HttpPost("ValidTransferFriend")]
        public async Task<ActionResult<string>> ValidTransferFriend(TransferSentViewModel model)
        {
            await Task.Delay(1500);
            return Ok("Transfert réussi !");
        }
        [HttpPost("ValidTransferPhysical")]
        public async Task<ActionResult<string>> ValidTransferPhysical(TransferSentViewModel model)
        {
            await Task.Delay(1500);
            return Ok(Guid.NewGuid().ToString());
        }
    }
}
