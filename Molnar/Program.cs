using Molnar;

class Program
{
    static void Main(string[] args)
    {
        var matrix = GetParams();
        matrix.DrawMatrix();
    }

    static Matrix GetParams()
    {
        bool result = false;

        int widht = 0;
        int height = 0;
        int rotation = 0;
        string[] values = new string[100];
        
        do
        {
            try
            {
                Console.WriteLine("please provide matrix dimenion, format: W H");
                var dimensionValueIn = Console.ReadLine();
                var dim = GetMatrixDimensions(dimensionValueIn!);
                widht = dim.Item1;
                height = dim.Item2;


                Console.WriteLine("please provide rotation count");
                var rotationValueIn = Console.ReadLine();
                rotation = GetRotationValue(rotationValueIn!);

                Console.WriteLine("please provide matrix values");
                var vals = GetMatrixValues(dim.Item2);
                values = vals;

                result = true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"invalid param {e.Message}");
            }
        } while (!result);

        return new Matrix(widht, height, rotation, values);
    }

    static Tuple<int, int> GetMatrixDimensions(string values)
    {
        var parsedValues = values.Split(' ');

        if (parsedValues.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(values));
        }

        bool widthResult = int.TryParse(parsedValues[0], out int mWidth);

        bool heightResult = int.TryParse(parsedValues[1], out int mHeight);

        if ((widthResult && heightResult) &&
            (0 < mWidth && mWidth <= 100) &&
            (0 < mHeight && mHeight <= 100)
            )
        {
            var dimensions = new Tuple<int, int>(mWidth, mHeight);
            return dimensions;
        }

        throw new ArgumentOutOfRangeException(nameof(values));
    }

    static int GetRotationValue(string rotation)
    {
        if (int.TryParse(rotation, out int rCount))
        {
            return rCount;
        }

        throw new ArgumentOutOfRangeException(nameof(rotation));
    }

    static string[] GetMatrixValues(int height)
    {
        string[] array = new string[height];
        int counter = 0;

        do
        {
            array[counter] = Console.ReadLine()!;
            counter++;
        } while (counter < height);

        return array;
    }
}
