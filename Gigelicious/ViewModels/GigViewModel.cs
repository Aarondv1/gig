using Gigelicious.Models;
using System.Collections.Generic;

namespace Gigelicious.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> UpCominGigs { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Heading { get; set; }
    }
}