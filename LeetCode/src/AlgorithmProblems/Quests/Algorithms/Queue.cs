using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class Queue
    {
        /// <summary>
        ///    Q1. Number of Students Unable to Eat Lunch 
        /// </summary>
        /// <see cref="https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/?envType=problem-list-v2&envId=dsa-sequence-valley-queue"/>
        /// <param name="students"></param>
        /// <param name="sandwiches"></param>
        /// <returns></returns>
        public int CountStudents(int[] students, int[] sandwiches)
        {
            var queue = new Queue<int>(students);
            var sandwichIndex = 0;
            var notEatCount = 0;
            while(sandwichIndex < sandwiches.Length && queue.Count != 0 && notEatCount < queue.Count)
            {
                var student = queue.Dequeue();
                if (student == sandwiches[sandwichIndex])
                {
                    sandwichIndex++;
                    notEatCount = 0;
                }
                else
                {
                    queue.Enqueue(student);
                    notEatCount++;
                }
            }
            return queue.Count;            
        }

        /// <summary>
        /// Q2. Time Needed to Buy Tickets
        /// </summary>
        /// <see cref="https://leetcode.com/problems/time-needed-to-buy-tickets/?envType=problem-list-v2&envId=dsa-sequence-valley-queue"/>
        /// <param name="tickets"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            var total = tickets[k];
            var required = tickets[k];
            for (var i = 0; i < k; ++i)
            {
                total += (tickets[i] >= required ? required : tickets[i]);
            }
            for (var i = k + 1; i < tickets.Length; ++i)
            {
                total += (tickets[i] >= required ? required - 1 : tickets[i]);
            }

            return total;
        }

        /// <summary>
        /// Q3. Implement Queue using Stacks
        /// <see cref="https://leetcode.com/problems/implement-queue-using-stacks/?envType=problem-list-v2&envId=dsa-sequence-valley-queue"/>
        /// </summary>
        public class MyQueue
        {
            private readonly Stack<int> inStack = new Stack<int>();
            private readonly Stack<int> outStack = new Stack<int>();
            public MyQueue()
            {

            }

            public void Push(int x)
            {
                inStack.Push(x);
            }

            public int Pop()
            {
                SyncStacks();
                return outStack.Pop();
            }

            public int Peek()
            {
                SyncStacks();
                return outStack.Peek();
            }

            private void SyncStacks()
            {
                if (outStack.Count != 0)
                    return;

                while (inStack.Count != 0)
                    outStack.Push(inStack.Pop());
            }

            public bool Empty()
            {
                return inStack.Count == 0 && outStack.Count == 0;
            }
        }
    }
}
