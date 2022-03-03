using ALATTestAPI.Models;
using ALATTestAPI.Repository;
using ALATTestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALATTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ALATestController : ControllerBase
    {
        private readonly IbanksService _banksservice;
        private readonly IALATTestRepo _aLATTestRep;
        private readonly IOTPGenService _oTPGenService;
        public ALATestController(IbanksService banksService, IALATTestRepo aLATTestRepo,IOTPGenService oTPGenService)
        {
            _banksservice = banksService;
            _aLATTestRep = aLATTestRepo;
            _oTPGenService = oTPGenService;
        }

        // GET: api/<ALATestController>
        [HttpGet("GetBanks")]
        public async Task<ActionResult> GetBanks()
        {
            var res = await _banksservice.GetBanksAsync();
            return Ok(res);
        }
        
        [HttpGet("ShowOtp")]
        public async Task<ActionResult> ShowOtps()
        {
            var res = _aLATTestRep.GetOtps();
            return Ok(res);
        }
        [HttpPost("GetSingleOtp/{Phone}")]
          public async Task<ActionResult> GetSingleOtp(string Phone)
        {
            var res = _aLATTestRep.GetOtp(Phone);
            return Ok(res);
        }
        

        [HttpPost("AddCustomer")]
        public async Task<ActionResult> AddCustomer(Customer cust)
        {
            var lga = _aLATTestRep.GetLga(cust.lga.id);
            var state = _aLATTestRep.Getstate(lga.StateId);
            cust.state = state;
            _aLATTestRep.addcustomer(cust);
            var res= _oTPGenService.GenerateOTP(5);
            _aLATTestRep.addotp(new OTP
            {
                count = 0,
                otpvalue = res,
                phone = cust.phone,
                status = "used"
            });

            await _aLATTestRep.SaveChangesAsync();
            return Ok();
        }


        // GET api/<ALATestController>/5
    
    }
}
