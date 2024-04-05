namespace TileCostCalculator;

class Program
{
    const int HOURLY_RATE = 86;
    const int HOURLY_AREA = 2;
    const int NUMBER_OF_DECIMALS = 2;
    static readonly string[] SHAPE_LIST = ["Rectangular", "Round"];

    static double GetPositiveDouble(string question)
    {
        double value = 0;
        Console.Write(question);
        while (!Double.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Please enter a positive number");
        }

        return value;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello and Welcome to our Tile Cost Calculator\n");

        double flooringUnitCost = 0;
        flooringUnitCost = GetPositiveDouble("What is the cost of 1 square meter of flooring ? ");


        int indexOfSelectedShape = -1;
        do
        {
            Console.WriteLine($"\nWhat is the shape of you room ?");
            for (int i = 0; i < SHAPE_LIST.Length; i++)
            {
                Console.WriteLine($"Enter {i+1} for {SHAPE_LIST[i]}");
            }
            Int32.TryParse(Console.ReadLine(),out indexOfSelectedShape);
        } while (indexOfSelectedShape<=0 || indexOfSelectedShape>SHAPE_LIST.Length);
        
        double[] dimensions = new double[2];
        double area = 0.0;

        switch (indexOfSelectedShape)
        {
            case 1: 
                dimensions[0] = GetPositiveDouble("\nWhat is the length of the room in meters ? ");
                dimensions[1] = GetPositiveDouble("\nWhat is the width of the room in meters ? ");
                area = dimensions[0] * dimensions[1];
                break;
            
            case 2:
                dimensions[0] = GetPositiveDouble("\nWhat is the radius of the room in meters ? ");
                area = dimensions[0] * dimensions[0] * Math.PI;
                break;
        }

        double workedHours = 0.0;
        double flooringCost = 0;
        double laborCost = 0;
        workedHours = Math.Ceiling(area / HOURLY_AREA);

        laborCost = Math.Round(workedHours * HOURLY_RATE, NUMBER_OF_DECIMALS);
        flooringCost = Math.Round(area * flooringUnitCost, NUMBER_OF_DECIMALS);


        Console.WriteLine($"\nThe cost of the flooring is {flooringCost}€");
        Console.WriteLine($"The cost of the workmanship is {laborCost}€");
        Console.WriteLine($"\nThe total cost is {laborCost + flooringCost}€");
    }
}