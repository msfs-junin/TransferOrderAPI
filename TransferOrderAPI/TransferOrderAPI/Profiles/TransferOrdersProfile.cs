﻿using AutoMapper;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class TransferOrdersProfile: Profile
    {
        public TransferOrdersProfile()
        {
            CreateMap<TransferOrder, Models.NetTransferOrderDto>();
            CreateMap<Models.NetTransferOrderForCreationDto, TransferOrder>();
        }
    }
}
