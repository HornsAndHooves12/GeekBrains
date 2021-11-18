using System.Text;

namespace TwoDimensialLib;

public class TwoDimensialArray
{
    private int[,] array;
    public TwoDimensialArray(int x, int y)
    {
        this.array = new int[x, y];
        var random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(100);
            }
        }
    }

    public int Sum()
    {
        var sum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
            }
        }
        return sum;
    }

    public int Sum(int from)
    {
        var sum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (from < array[i, j])
                {
                    sum += array[i, j];
                }
            }
        }
        return sum;
    }

    public void IndexOfMin(out int x, out int y)
    {
        var min = int.MaxValue;
        x = -1;
        y = -1;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (min > array[i, j])
                {
                    min = array[i, j];
                    x = i;
                    y = j;
                }
            }
        }
    }

    public int Min
    {
        get
        {
            var min = int.MaxValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (min > array[i, j])
                    {
                        min = array[i, j];
                    }
                }
            }
            return min;
        }
    }
    public int Max
    {
        get
        {
            var max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                    }
                }
            }
            return max;
        }
    }

    public void SaveToFile(string fileName)
    {

        using var stream = new StreamWriter(fileName);
        string line;
        stream.WriteLine(array.GetLength(0));
        stream.WriteLine(array.GetLength(1));
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                stream.WriteLine(array[i, j]);
            }
        }
   
    }

    public void FetchFromFile(string fileName)
    {
        using var stream = new StreamReader(fileName);
        string line;
        int x = int.Parse(stream.ReadLine());
        int y = int.Parse(stream.ReadLine());
        array = new int[x, y];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = int.Parse(stream.ReadLine());
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sb.Append(array[i, j]);
                sb.Append(", ");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }
}
