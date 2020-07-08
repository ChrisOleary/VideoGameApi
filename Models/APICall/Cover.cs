﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingApi.Models.APICall
{
    public class Cover
    {
        public int id { get; set; }
        public bool alpha_channel { get; set; }
        public bool animated { get; set; }
        public int game { get; set; }
        public int height { get; set; }
        public string image_id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public string checksum { get; set; }
        public string imgPrefix { get; set; } = ".jpg";
    }
}
