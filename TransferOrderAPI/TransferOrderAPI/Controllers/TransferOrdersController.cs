using API.Models;
using AutoMapper;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferOrdersController : ControllerBase
    {
        private readonly ICurrencyQuotationService _currencyQuotationService;
        private readonly ITransferOrderRepository _transferOrderRepository;
        private readonly IMapper _mapper;

        public TransferOrdersController(ICurrencyQuotationService currencyQuotationService, 
           ITransferOrderRepository transferOrderRepository,
           IMapper mapper)
        {
            _currencyQuotationService = currencyQuotationService;
            _transferOrderRepository = transferOrderRepository ??
                throw new ArgumentNullException(nameof(transferOrderRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{transferOrderId}", Name = "GetTransferOrder")]
        public IActionResult GetTransferOrder(Guid transferOrderId)
        {
            var transferOrderFromRepo = _transferOrderRepository.GetTransferOrder(transferOrderId);

            if (transferOrderFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NetTransferOrderDto>(transferOrderFromRepo));
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<NetTransferOrderDto>> GetTransferOrders()
        {
            var transferOrdersFromRepo = _transferOrderRepository.GetTransferOrders();
            return Ok(_mapper.Map<IEnumerable<NetTransferOrderDto>>(transferOrdersFromRepo));
        }

        [HttpPost]
        public ActionResult<NetTransferOrderDto> CreateTransferOrder(NetTransferOrderForCreationDto transferOrder)
        {
            //TODO REFACTOR OJO NO VA EN CONTROLLER
            if (transferOrder.isNetTransferType)
            {
                transferOrder.grossAmmount = _currencyQuotationService.calcularCotizacionNeta(transferOrder.sourceCurrency, transferOrder.destinationCurrency, transferOrder.netAmmount);
            }
            else
            {
                transferOrder.netAmmount = _currencyQuotationService.calcularCotizacionBruta(transferOrder.sourceCurrency, transferOrder.destinationCurrency, transferOrder.grossAmmount);
            }
            var transferOrderEntity = _mapper.Map<Entities.TransferOrder>(transferOrder);
            _transferOrderRepository.AddTransferOrder(transferOrderEntity);
            _transferOrderRepository.Save();

            var transferOrderToReturn = _mapper.Map<NetTransferOrderDto>(transferOrderEntity);
            return CreatedAtRoute("GetTransferOrder",
                new { transferOrderId = transferOrderToReturn.Id },
                transferOrderToReturn);
        }

        [HttpOptions]
        public IActionResult GetTransferOrdersOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
