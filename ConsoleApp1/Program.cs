using System;
class mettl
{

    // Main Method
    public static void Main(String[] args)
    {

        int input1 = 5;
        int[] input2 = { 1, 2, 3, 5, 4 };
        //int[] input2 = { 1, 2, 3, 6, 5 };
        //int[] input2 = { 5, 4, 1, 2, 3 };
        
        Sequence sequence = new Sequence();
        Console.WriteLine("Output : " + sequence.ValidateSequence(input1, input2).ToString());


    }
}