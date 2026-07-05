using BuildingPricingToolWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BuildingPricingToolWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] 
        [Range(1, 500, ErrorMessage = "Width must be greater than 0.")]
        public double Width { get; set; }

        [BindProperty] 
        [Range(1, 1000, ErrorMessage = "Length must be greater than 0.")]
        public double Length { get; set; }

        [BindProperty] 
        [Range(1, 100, ErrorMessage = "Wall height must be greater than 0.")]
        public double WallHeight { get; set; }

        [BindProperty]
        [Range(0, 24, ErrorMessage = "Roof pitch cannot be negative.")] 
        public double RoofPitch { get; set; }

        [BindProperty]
        [Range(0, 100, ErrorMessage = "Door count cannot be negative.")] 
        public int DoorCount { get; set; }

        [BindProperty] 
        [Range(0, 500, ErrorMessage = "Window count cannot be negative.")]
        public int WindowCount { get; set; }

        [BindProperty]
        public MaterialType MaterialType { get; set; } = MaterialType.Wood;

        public Estimate? EstimateResult { get; set; }

        public void OnGet()
        {
        }

        private double GetMaterialCostPerSquareFoot(MaterialType materialType)
        {
            return materialType switch
            {
                MaterialType.Wood => 8.50,
                MaterialType.Steel => 12.75,
                MaterialType.Concrete => 10.25,
                _ => 8.50
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Building building = new Building(Width, Length, WallHeight, RoofPitch);

            double floorArea = building.CalculateFloorArea();
            double wallArea = building.CalculateWallArea();
            double roofArea = building.CalculateRoofArea();

            double totalSurfaceArea = floorArea + wallArea + roofArea;
            double materialRate = GetMaterialCostPerSquareFoot(MaterialType);
            double materialCost = totalSurfaceArea * materialRate;

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

            return Page();
        }
    }
}