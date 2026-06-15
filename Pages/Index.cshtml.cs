using BuildingPricingToolWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildingPricingToolWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Width { get; set; }

        [BindProperty]
        public double Length { get; set; }

        [BindProperty]
        public double WallHeight { get; set; }

        [BindProperty]
        public double RoofPitch { get; set; }

        [BindProperty]
        public int DoorCount { get; set; }

        [BindProperty]
        public int WindowCount { get; set; }

        public Estimate? EstimateResult { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Building building = new Building(Width, Length, WallHeight, RoofPitch);

            double floorArea = building.CalculateFloorArea();
            double wallArea = building.CalculateWallArea();
            double roofArea = building.CalculateRoofArea();

            double materialCost = floorArea * 8.50;
            double laborCost = floorArea * 4.25;
            double totalCost = materialCost + laborCost;

            EstimateResult = new Estimate
            {
                FloorArea = floorArea,
                WallArea = wallArea,
                RoofArea = roofArea,
                MaterialCost = materialCost,
                LaborCost = laborCost,
                TotalCost = totalCost
            };

            string filePath = "/Users/samuel/BuildingPricingTool/fusion_building_data.csv";

            string csvData = $"{Width},{Length},{WallHeight},{RoofPitch},{DoorCount},{WindowCount}";

            System.IO.File.WriteAllText(filePath, csvData);
        }
    }
}