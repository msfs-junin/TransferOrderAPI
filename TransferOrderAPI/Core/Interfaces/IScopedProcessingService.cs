﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken, dynamic quotes);
    }
}
