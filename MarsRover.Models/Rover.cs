namespace MarsRover.Models
{
    public class Rover
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Direction { get; set; }

        public Rover(int xPosition, int yPosition, string direction)
        {
            XPosition = xPosition; 
            YPosition = yPosition; 
            Direction = direction;
        }
    }
}
