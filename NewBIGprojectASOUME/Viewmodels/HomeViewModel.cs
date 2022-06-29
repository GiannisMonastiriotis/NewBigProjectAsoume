using NewBIGprojectASOUME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Viewmodels
{
    public class HomeViewModel
    {
        public IEnumerable<Band> FeauturedBands { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Like> Likesz { get; set; }
        public ILookup<string, Liking> Likingsz { get; set; }
    }
}