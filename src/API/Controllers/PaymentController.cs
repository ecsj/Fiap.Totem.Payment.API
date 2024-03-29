using Application.Interfaces;
using Application.UseCases;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("Request")]
    public async Task<IActionResult> Request([FromBody] PaymentRequest request)
    {
        var result = await _paymentService.RequestPayment(request);

        return Ok(result);
    }

    [HttpPost("Webhook")]
    public IActionResult Webhook([FromBody] PaymentWebook request)
    {
        var result = _paymentService.ProcessPayment(request);

        if (result) return Ok();
        
        return BadRequest();
    }

    [HttpGet("{id:Guid}")]
    public IActionResult ReceivePaymentStatus(Guid id)
    {
        var result = _paymentService.GetPayment(id);

        return Ok(result);
    }
}