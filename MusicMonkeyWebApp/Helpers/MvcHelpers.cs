﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMonkeyWebApp.Helpers
{
    public class HeaderViewModel
    {
        public string CurrentAction { get; set; }
        public List<HeaderLink> Links { get; set; }
    }
    public class HeaderLink
    {
        public string Action { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public List<HeaderLink> SubLinks { get; set; }
    }
}