namespace MarsRover.Models
{
    public class Plateau
    {
        public int XLength { get; set; }
        public int YLength { get; set; }

        public Plateau(int xLength, int yLength)
        {
            XLength = xLength;
            YLength = yLength;
        }
    }
}
