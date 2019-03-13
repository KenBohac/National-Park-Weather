using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {

    
        public string ParkCode { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public double Acreage { get; set; }

        public double Elevation { get; set; }

        public double MilesOfTrail { get; set; }

        public int NumberofCampsites { get; set; }

        public string Climate { get; set; }

        public int YearFounded { get; set; }

        public long AnnualVisitorCount { get; set; }

        public string Quote { get; set; }

        public string QuoteSource { get; set; }

        public string Description { get; set; }

        public decimal EntryFee { get; set; }

        public int NumberOfAnimalSpecies { get; set; }

        public List<Weather>  {get; set;} 


    }
}
