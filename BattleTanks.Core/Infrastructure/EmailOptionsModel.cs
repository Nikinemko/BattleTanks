﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Core.Infrastructure
{
    public class EmailOptionsModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public bool UseDefaultCredentials { get; set; }
        public bool EnableSsl { get; set; }

    }
}
