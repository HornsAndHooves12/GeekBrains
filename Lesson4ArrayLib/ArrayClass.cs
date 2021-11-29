namespace Lesson4ArrayLib;

public class ArrayClass
{

    private int[] array;

    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public int Sum
    {
        get
        {
            var sum = 0;
            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }

    public int MaxCount
    {
        get
        {
            var count = 0;
            var max = int.MinValue;
            for (var i = 0; i < array.Length; i++)
            {
                if (max == array[i])
                {
                    count++;
                }
                if (max < array[i])
                {
                    max = array[i];
                    count = 1;
                }

            }
            return count;
        }
    }

    public ArrayClass(int size, int start, int step)
    {
        array = new int[size];
        for (var i = 0; i < size; i++)
        {
            array[i] = start;
            start += step;
        }
    }

    public int[] Inverse()
    {
        var newArray = new int[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            newArray[i] = -array[i];
        }
        return newArray;
    }

    public void Multi(int multiplier)
    {
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = array[i] * multiplier;
        }
    }

    public override string ToString()
    {
        return string.Join(",", array);
    }

    public Dictionary<int, int> CountFrequency()
    {
        var frequenc = new Dictionary<int, int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (!frequenc.ContainsKey(array[i]))
            {
                frequenc[array[i]] = 1;
            }
            else
            {

                frequenc[array[i]]++;
            }

        }

        return frequenc;
    }

}
