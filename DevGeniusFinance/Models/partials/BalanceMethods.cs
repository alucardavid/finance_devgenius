﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Models
{
    public partial class Balance
    {
        public override string ToString() => $"{Description} - {Value}";
        
    }
}