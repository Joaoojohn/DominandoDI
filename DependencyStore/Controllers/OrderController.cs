using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services.Constracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyStore.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeesService _deliveryFeesService;
        private readonly IPromoCodeRepository _promoCodeRepository;

        public OrderController(ICustomerRepository customerRepository, IDeliveryFeesService deliveryFeesService, IPromoCodeRepository promoCodeRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeesService = deliveryFeesService;
            _promoCodeRepository = promoCodeRepository;
        }

        [Route("v1/Orders")]
        [HttpPost]
        public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer is null)
                return NotFound();

            var delivery = await _deliveryFeesService.GetDeliveryFeeAsync(zipCode);

            var cupon = await _promoCodeRepository.GetPromoCodeAsync(promoCode);
            var discount = cupon?.Value ?? 0M;

            var order = new Order(delivery, discount, new List<Product>());


            return Ok($"Pedido {order.Code} gerado com sucesso!");
        }
    }
}
