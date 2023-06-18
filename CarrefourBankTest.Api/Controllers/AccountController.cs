using CarrefourBankTest.Application.DTOs;
using CarrefourBankTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net;
using System.Net.Mail;

namespace CarrefourBankTest.Api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost("create")]
        public IActionResult Create()
        {
            try
            {
                var result = _accountAppService.CreateAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPost("{accountId}/credit")]
        public IActionResult Credit(int accountId, [FromBody] decimal amount)
        {
            try
            {
                _accountAppService.CreditAsync(accountId, amount);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPost("{accountId}/debit")]
        public IActionResult Debit(int accountId, [FromBody] decimal amount)
        {
            try
            {
                _accountAppService.DebitAsync(accountId, amount);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpGet("{accountId}/balance")]
        public IActionResult GetBalance(int accountId)
        {
            try
            {
                decimal balance = _accountAppService.GetBalanceAsync(accountId).Result;
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

    }
}
