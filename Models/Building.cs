namespace BuildingPricingToolWeb.Models
{
    public class Building
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double WallHeight { get; set; }
        public double RoofPitch { get; set; }

        public Building(double width, double length, double wallHeight, double roofPitch)
        {
            Width = width;
            Length = length;
            WallHeight = wallHeight;
            RoofPitch = roofPitch;
        }

        public double CalculateFloorArea()
        {
            return Width * Length;
        }

        public double CalculateWallArea()
        {
            double longWalls = 2 * (Length * WallHeight);
            double shortWalls = 2 * (Width * WallHeight);

            return longWalls + shortWalls;
        }

        public double CalculateRoofArea()
        {
            double halfWidth = Width / 2;
            double roofRise = halfWidth * (RoofPitch / 12);

            double roofSlopeLength = Math.Sqrt(
                Math.Pow(halfWidth, 2) + Math.Pow(roofRise, 2)
            );

            return roofSlopeLength * Length * 2;
        }
    }
}