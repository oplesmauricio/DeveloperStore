﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface IEventLogger
    {
        void Log(string eventType);
    }
}
