﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Models
{
    public class EmailSetting
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
