namespace TileCostCalculator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello and Welcome to our Tile Cost Calculator\n");
        
        Console.Write("What is the length of the room in meters ? ");
        double length = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("What is the width of the room in meters ? ");
        double width = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("What is the cost of 1 square meter of flooring ? ");
        double unitCost = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine($"\nThe total cost of the flooring is {length*width*unitCost}€");
        
    }
}