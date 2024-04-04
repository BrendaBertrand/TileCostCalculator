namespace TileCostCalculator;

class Program
{
    static double getPositiveDouble(string question)
    {
        bool inputTypeisCorrect = false;
        double value = 0;
        Console.Write(question);
        do
        {
            try
            {
                value = Convert.ToDouble(Console.ReadLine());
                if (value <= 0)
                {
                    Console.WriteLine("Please enter a positive number");
                }
                else
                {
                    inputTypeisCorrect = true;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter a number");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong : {e.Message}");
                Console.WriteLine("Please enter your number again");
            }
        } while (!inputTypeisCorrect);

        return value;
    }

    static void Main(string[] args)
    {
        double[] dimensions = new double[2];
        double flooringUnitCost = 0;
        string shape = "";
        double area = 0.0;
        const int hourlyRate = 86;
        const int hourlyArea = 2;
        double workedHours = 0.0;
        double laborCost = 0;
        double flooringCost = 0;


        Console.WriteLine("Hello and Welcome to our Tile Cost Calculator\n");

        flooringUnitCost = getPositiveDouble("What is the cost of 1 square meter of flooring ? ");


        Console.WriteLine("What is the shape of you room ? \n1 - Rectangular\n2 - Round");

        do
        {
            shape = Console.ReadLine();
            if (shape != "1" && shape != "2")
            {
                Console.WriteLine("Please enter 1 or 2");
                shape = "";
            }
        } while (shape != "1" && shape != "2");


        if (shape == "1")
        {
            dimensions[0] = getPositiveDouble("What is the length of the room in meters ? ");
            dimensions[1] = getPositiveDouble("What is the width of the room in meters ? ");

            area = dimensions[0] * dimensions[1];
        }

        if (shape == "2")
        {
            dimensions[0] = getPositiveDouble("What is the radius of the room in meters ? ");

            area = dimensions[0] * dimensions[0] * Math.PI;
        }

        workedHours = Math.Ceiling(area / hourlyArea);

        laborCost = Math.Round(workedHours * hourlyRate, 2);
        flooringCost = Math.Round(area * flooringUnitCost, 2);


        Console.WriteLine($"\nThe cost of the flooring is {flooringCost}€");
        Console.WriteLine($"\nThe cost of the workmanship is {laborCost}€");
        Console.WriteLine($"\nThe total cost is {laborCost + flooringCost}€");
    }
}