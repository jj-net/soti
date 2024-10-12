using System;
class mettl
{
    public static void Main(String[] args)
    {
        int input1 = 5;
        int[] input2 = { 1, 2, 3, 5, 4 };

        Sequence sequence = new Sequence();
        Console.WriteLine("Output : " + sequence.ValidateSequence(input1, input2).ToString());

    }
}