﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitClientVS.Contracts.Models
{
    public class GitCredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Uri Host { get; set; }
        public bool IsEnterprise { get; set; }
    }
}
