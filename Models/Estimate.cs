namespace BuildingPricingToolWeb.Models
{
    public class Estimate
    {
        public double FloorArea { get; set; }
        public double WallArea { get; set; }
        public double RoofArea { get; set; }

        public double MaterialCost { get; set; }
        public double LaborCost { get; set; }
        public double TotalCost { get; set; }
    }
}