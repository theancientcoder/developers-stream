﻿using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace application.Commands
{
    public class RegisterNewStreamer : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }

        public class Platform
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}