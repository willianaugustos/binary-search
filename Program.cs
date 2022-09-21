

int[] array = {2, 4, 6, 10, 17, 21, 55, 100, 101, 113, 230};

ShowArray(array);

Console.WriteLine("Enter a number:");
var input = Convert.ToInt32(Console.ReadLine());
var (exists, hops) = Search.BinarySearch(input, array);

if (exists) 
{
    Console.WriteLine($"The number {input} found in the array. Found with {hops} hop{(hops==1?"":"s")}.");
}
else
{
    Console.WriteLine($"The number {input} was not found in the array");
}

static void ShowArray(int[] array)
{
   foreach (var item in array)
   {
    Console.Write(item.ToString()+ ", ");
   }
}

public static class Search
{
    public static (bool, int) BinarySearch(int number, int[] array)
    {
        int hops=0;
        bool found=false;
        int start = 0;
        int end = array.Length-1;
        while (end >= start && !found)
        {
           hops++;
           var pos = (end - start) / 2 + start;
           Console.WriteLine($"Pos={pos} Number at pos={array[pos]} start={start} end={end}");
           if (array[pos] == number)
              found=true;
           else
           {
              if (number > array[pos])
              {
                start = pos+1;
                Console.WriteLine("->");
              }
              else
              {
                end = pos-1;
                Console.WriteLine("<-");
              }
           }
        }
        return (found, hops);
    }

    public static (bool, int) Exaustive(int number, int[] array)
    {
        int hops=0;
        bool found = false;
        foreach (var n in array)
        {
            hops++;

            if (n == number)
            {
               found=true;
               break;
            }
        }
        return (found, hops);
    }
}