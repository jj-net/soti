using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Sequence
{
    
    public int ValidateSequence(int input1,  int[] input2)
    {
        int preValue;
        int curValue;
        Direction direction = Direction.None;
        int Result = -1;
        List<int> Segment = new List<int>();
        List<Partition> partition = new List<Partition>();

        if (input1 < 2)
        {
            return Result;
        }

        //Segmentation of sequence
        preValue = input2[0];
        for (int i = 1; i < input2.Length; i++)
        {
            curValue = input2[i];
            if (i == 1) Segment.Add(preValue);

            //Determine direction
            if (direction == Direction.None)
            {
                if ((preValue + 1) == curValue)
                {
                    direction = Direction.Forward;
                }
                else if ((preValue - 1) == curValue)
                {
                    direction = Direction.Backward;
                }
                else
                {
                    direction = Direction.None;
                }
            }

            if (direction == Direction.Forward)
            {
                if ((preValue + 1) == curValue)
                {
                    Segment.Add(curValue);
                }
                else
                {
                    Partition p = new Partition();
                    p.Elements = Segment.ToArray();
                    p.index = partition.Count();
                    partition.Add(p);
                    direction = Direction.None;
                    Segment.Clear();
                    Segment.Add(curValue);
                }
            }

            if (direction == Direction.Backward)
            {
                if ((preValue - 1) == curValue)
                {
                    Segment.Add(curValue);
                }
                else
                {
                    Partition p = new Partition();
                    p.Elements = Segment.ToArray();
                    p.index = partition.Count();
                    partition.Add(p);
                    direction = Direction.None;
                    Segment.Clear();
                    Segment.Add(curValue);
                }
            }

            if ((i + 1) == input2.Count())
            {
                if (direction == Direction.Forward)
                {
                    if ((preValue + 1) == curValue)
                    {
                        Partition p = new Partition();
                        p.Elements = Segment.ToArray();
                        p.index = partition.Count();
                        partition.Add(p);
                        Segment.Clear();
                    }
                }

                if (direction == Direction.Backward)
                {
                    if ((preValue - 1) == curValue)
                    {
                        Partition p = new Partition();
                        p.Elements = Segment.ToArray();
                        p.index = partition.Count();
                        partition.Add(p);
                        Segment.Clear();
                    }
                }
            }
            preValue = curValue;
        }

        //Sort the elements to one direction
        foreach (var p in partition)
        {
            if (p.Elements[0] > p.Elements[p.Elements.Count() - 1])
            {
                partition[p.index].Elements = p.Elements.Reverse().ToArray();
            }
        }

        //Sort the array acenting based on first element
        partition = partition.OrderBy(x => x.Elements[0]).ToList();

        //Determine the first element of the sequence
        int MinValue = partition[0].Elements[0];
        int MinElement = 0;
        int Counter = 0;
        int FirstElement;
        
        foreach (var p in partition)
        {
            FirstElement = p.Elements[0];
            if (FirstElement < MinValue)
            {
                MinValue = FirstElement;
                MinElement = Counter;
            }
            Counter++;
        }

        //Find the possibility of concatenation
        List<Partition> partitionAnswer = new List<Partition>();
        int LastValueOfFirstElement = partition[MinElement].Elements[partition[MinElement].Elements.Length - 1];
        int EndingValue;
        bool ByPassFirst = true;
        partitionAnswer.Add(partition[MinElement]);

        foreach (var p in partition)
        {
            if (ByPassFirst)
            {
                ByPassFirst = false;

            }
            else
            {
                FirstElement = p.Elements[0];
                EndingValue = partitionAnswer[partitionAnswer.Count() - 1].Elements[partitionAnswer[partitionAnswer.Count() - 1].Elements.Length - 1];

                if ((EndingValue + 1) == FirstElement)
                {
                    partitionAnswer.Add(p);
                    Result = 0;
                }
                else
                {
                    Result = -1;
                }
            }
            
        }

        //Finding the smallest element
        int SmallestElementCount;
        if (Result == 0)
        {
            SmallestElementCount = partition[0].Elements.Count();
            foreach (var p in partition)
            {
                if (p.Elements.Count() < SmallestElementCount)
                {
                    SmallestElementCount = p.Elements.Count();
                }
            }
            Result = SmallestElementCount;
        }

        //Returning the result
        return Result;

    }


}
