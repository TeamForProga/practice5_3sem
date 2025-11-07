using System.Text.RegularExpressions;

string[] Months = { "January", "February", "Marth", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

MonthsLenghtN(Months);
Console.WriteLine();

SummerAndWinterMonths(Months);
Console.WriteLine();

AlphaberMonths(Months);
Console.WriteLine();

UMonths(Months);
Console.WriteLine();

// 2 Часть
List<ArrayOfInts> arrayOfInts = [];
arrayOfInts.Add(new ArrayOfInts(new int[] { 1, 2, 3, 4, 5 }));        // Сумма: 15
arrayOfInts.Add(new ArrayOfInts(new int[] { 10, 20, 30 }));           // Сумма: 60
arrayOfInts.Add(new ArrayOfInts(new int[] { 5, 5, 5, 5 }));           // Сумма: 20
arrayOfInts.Add(new ArrayOfInts(new int[] { 100, 223, 1 }));              // Сумма: 300
arrayOfInts.Add(new ArrayOfInts([1, 1, 1, 1, 1, 1]));     // Сумма: 6

Console.WriteLine();
OnlyTwo(arrayOfInts);
Console.WriteLine();

Console.WriteLine();
MaxSum(arrayOfInts);
Console.WriteLine();

Console.WriteLine();
MinElements(arrayOfInts);
Console.WriteLine();

int n = 5;

CountArrayThatContainN(arrayOfInts, n);
Console.WriteLine();

var EqualCount = (from array in arrayOfInts group array by array.ElementsCount).Where(EqualCount => EqualCount.Count() > 1);
foreach (var m in EqualCount) Console.Write("{0} ", m.Count());
Console.WriteLine();

var mas = from array in arrayOfInts orderby array.Array.First() select array;
foreach (var m in mas)
{
    foreach (var i in m.Array)
        Console.Write($"{i} ");
    Console.WriteLine();
}


static void MonthsLenghtN(string[] Months)
{
    int n = 4;
    Console.WriteLine("Запрос, выбирающий последовательность  месяцев  с  длиной  строки  равной  n = {0}:",n);
    
    var MonthsLenghtN = from m in Months
                        where m.Length == n
                        select m;
    foreach (var m in MonthsLenghtN) Console.Write("{0} ", m);
    Console.WriteLine();
}

static void SummerAndWinterMonths(string[] Months)
{
    Console.WriteLine("Запрос,  возвращающий только летние и зимние месяцы:");
    string[] SummerMonths = { "June", "July", "August" };
    string[] WinterMonths = { "December", "January", "February" };

    var SummerAndWinterMonths = from m in Months
                                where SummerMonths.Concat(WinterMonths).Contains(m)
                                select m;
    foreach (var m in SummerAndWinterMonths) Console.Write("{0} ", m);
    Console.WriteLine();
}


static void AlphaberMonths(string[] Months)
{
    Console.WriteLine("Запрос вывода месяцев в алфавитном порядке:");
    var AlphabetMonths = from m in Months
                         orderby m
                         select m;

    foreach (var m in AlphabetMonths) Console.Write("{0} ", m);
    Console.WriteLine();
}

static void UMonths(string[] Months)
{
    Console.WriteLine("Запрос, подсчитывающий  месяцы, содержащие букву «u» и длиной имени не менее 4-х:");
    var UMonths = from m in Months
                  where (m.Contains('u') && m.Length >= 4)
                  select m;
    foreach (var m in UMonths) Console.Write("{0} ", m);
    Console.WriteLine();
    Console.WriteLine($"Всего: {UMonths.Count()}");
}


static void OnlyTwo(List<ArrayOfInts> arrayOfInts)
{
    var OnlyTwo = from array in arrayOfInts
                  where array.Array.All(i => i % 2 == 0)
                  select array;

    foreach (var m in OnlyTwo)
    {
        foreach (var i in m.Array)
            Console.Write($"{i} ");
        Console.WriteLine();
    }
}

static void MaxSum(List<ArrayOfInts> arrayOfInts)
{
    var ArraySum = from array in arrayOfInts
                   orderby array.Sum()
                   select array;
    var MaxSum = ArraySum.Last();
    foreach (var m in MaxSum.Array) Console.Write("{0} ", m);
    Console.WriteLine();
}

static void MinElements(List<ArrayOfInts> arrayOfInts)
{
    var s = from array in arrayOfInts
            orderby array.ElementsCount
            select array;
    var MinElements = s.First();
    foreach (var m in MinElements.Array) Console.Write("{0} ", m);
    Console.WriteLine();
}

static void CountArrayThatContainN(List<ArrayOfInts> arrayOfInts, int n)
{
    Console.Write("Количество массивов, содержащих заданное значение n = {0}: ", n);
    var CountArray = from i in arrayOfInts where i.Array.Contains(n) select i;
    Console.WriteLine(CountArray.Count());
    Console.WriteLine();
}

class ArrayOfInts : ISummable
{
    int _ElementsCount;
    int[]? _Array;

    public int ElementsCount
    {
        get => _ElementsCount;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Количество элементов массива не может быть меньше нуля");
            if (value != Array.Length) throw new ArgumentOutOfRangeException("Количество элеметнов не совпадает с длиной массива");
            _ElementsCount = value;
        }
    }
    public int[] Array
    {
        get => _Array;
        set
        {
            if (value == null || value.Length < 0) throw new ArgumentException("Массив не может быть пустым или меньше нуля");
            _Array = value;
        }
    }
    public ArrayOfInts(int elementsCount1, int[] array1)
    {

        Array = array1 ?? throw new ArgumentException("МАссив не может быть пустым");
        ElementsCount = elementsCount1;
    }

    public ArrayOfInts(int[] array)
    {
        Array = array;
        ElementsCount = array.Length;

    }

    public override string ToString()
    {
        return $"{from i in Array
                  where i != 0 && i != 1
                  select i.ToString()}";
    }

    public int Sum()
    {
        return Array.Sum();
    }
}

interface ISummable
{
    int Sum();
}

