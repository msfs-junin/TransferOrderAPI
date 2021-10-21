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
        private readonly ITransferOrderRepository _transferOrderRepository;
        private readonly IMapper _mapper;

        public TransferOrdersController(ITransferOrderRepository transferOrderRepository,
           IMapper mapper)
        {
            _transferOrderRepository = transferOrderRepository ??
                throw new ArgumentNullException(nameof(transferOrderRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public ActionResult<IEnumerable<TransferOrderDto>> GetTransferOrders()
        {
            var transferOrdersFromRepo = _transferOrderRepository.GetTransferOrders();
            return Ok(_mapper.Map<IEnumerable<TransferOrderDto>>(transferOrdersFromRepo));
        }

    }
}
