namespace BuildingPricingToolWeb.Models
{
    public class Estimate
    {
        public MaterialType SelectedMaterial { get; set; }
        public double MaterialRate { get; set; }

        public double FloorArea { get; set; }
        public double WallArea { get; set; }
        public double RoofArea { get; set; }
        public double TotalSurfaceArea { get; set; }

        public double MaterialCost { get; set; }
        public double LaborCost { get; set; }

        public double DoorCost { get; set; }
        public double WindowCost { get; set; }
        public double FeatureCost { get; set; }

        public double TotalCost { get; set; }
    }
}