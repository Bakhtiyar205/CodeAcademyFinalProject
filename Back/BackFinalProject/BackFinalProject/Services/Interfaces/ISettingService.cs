﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ISettingService
    {
        Dictionary<string, string> GetSetting();
    }
}
