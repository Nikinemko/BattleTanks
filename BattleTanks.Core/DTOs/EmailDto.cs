﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Core.DTOs
{
    public class EmailDto
    {
        public string RecepientEmail { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
    }
                        
}
