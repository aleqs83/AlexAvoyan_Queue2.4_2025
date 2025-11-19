using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace AlexAvoyan_Queue2._4_2025
{
    internal class Program
    {
        static Queue<int> CreateQueue()//creating the queue
        {
            int num;
            Queue<int> q1 = new Queue<int>();
            Console.WriteLine("please enter a number and press -999 to stop");
            num = int.Parse(Console.ReadLine());
            while (num != -999)
            {
                q1.Insert(num);
                Console.WriteLine("please enter a number and press -999 to stop");
                num = int.Parse(Console.ReadLine());
            }
            return q1;
        }
        static int Size(Queue<int> q1)//cheacking the size of the queue
        {
            Queue<int> q2 = new Queue<int>();
            int counter = 0;
            while (!q1.IsEmpty())
            {
                q2.Insert(q1.Remove());
                counter++;
            }
            while (!q2.IsEmpty())
            {
                q1.Insert(q2.Remove());
            }
            return counter;
        }
        static bool IsIdentical(Queue<int> q1, Queue<int> q2)//cheacking if the two queues are of identical size 
        {
            if (Size(q1) != Size(q2))
            {
                return false;
            }
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            bool identical = true;
            while (!q1.IsEmpty())
            {
                int item1 = q1.Remove();
                int item2 = q2.Remove();
                if (item1 != item2)
                {
                    identical = false;
                }
                temp1.Insert(item1);
                temp2.Insert(item2);
            }
            while (!temp1.IsEmpty())
            {
                q1.Insert(temp1.Remove());
                q2.Insert(temp2.Remove());
            }
            return identical;
        }
        static bool IsSimiler(Queue<int> q1, Queue<int> q2)//cheacking if the items in the queue are similer  to eachother
        {
            if (Size(q1) != Size(q2))
            {
                return false;
            }
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            bool similer = true;
            while (!q1.IsEmpty())
            {
                int item1 = q1.Remove();
                int item2 = q2.Remove();
                if ((item1 % 2) != (item2 % 2))
                {
                    similer = false;
                }
                temp1.Insert(item1);
                temp2.Insert(item2);
            }
            while (!temp1.IsEmpty())
            {
                q1.Insert(temp1.Remove());
                q2.Insert(temp2.Remove());
            }
            return similer;

        }
        static bool IsExit(Queue<int> q1, int num)//it cheack if the one digit number is in the queue 
        {
            Queue<int> temp = new Queue<int>();
            bool found = false;
            while (!q1.IsEmpty())
            {
                if(q1.Head()%10==num)
                {
                    found = true;
                }
                temp.Insert(q1.Remove());
            }
            while (!temp.IsEmpty())
            {
                q1.Insert(temp.Remove());
            }
            return found;

        }
        static Queue<int>clone(Queue<int> q1)//cloning the queue
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> cloneQ = new Queue<int>();
            while (!q1.IsEmpty())
            {
                int item = q1.Remove();
                temp.Insert(item);
                cloneQ.Insert(item);
            }
            while (!temp.IsEmpty())
            {
                q1.Insert(temp.Remove());
            }
            return cloneQ;
        }

        //it check if all the items in the queues first digit Exist in the last digit in all the items in the queue without the users number
        static bool AllExit(Queue<int> q1)
        {
            Queue<int> temp = new Queue<int>();
            bool allFound = true;
            // Collect all last digits in the queue
            Queue<int> temp2 = new Queue<int>();
            Queue<int> cloneQ = new Queue<int>();
            while (!q1.IsEmpty())
            {
                int item = q1.Remove();
                temp.Insert(item);
                cloneQ.Insert(item);
                temp2.Insert(item % 10);
            }
            // Check if each first digit exists in the last digits
            while (!temp.IsEmpty())
            {
                int item = temp.Remove();
                int firstDigit = item;
                while (firstDigit >= 10)
                {
                    firstDigit /= 10;
                }
                bool found = false;
                Queue<int> tempLastDigits = new Queue<int>();
                while (!temp2.IsEmpty())
                {
                    int lastDigit = temp2.Remove();
                    if (lastDigit == firstDigit)
                    {
                        found = true;
                    }
                    tempLastDigits.Insert(lastDigit);
                }
                while (!tempLastDigits.IsEmpty())
                {
                    temp2.Insert(tempLastDigits.Remove());
                }
                if (!found)
                {
                    allFound = false;
                    break;
                }
            }
            while (!cloneQ.IsEmpty())
            {
                q1.Insert(cloneQ.Remove());
            }
            return allFound;
        }




        static void Main(string[] args)
        {
            //CREATING TWO QUEUES
            Console.WriteLine("Creating first queue:");
            Queue<int> queue1 = CreateQueue();
            //Console.WriteLine("Creating second queue:");
            //Queue<int> queue2 = CreateQueue();

            //// Check if the queues are identical/2.4/q1.a
            //Console.WriteLine("_____________________2.4/q1.a____________________________");
            //Console.WriteLine("are The queues identical: " + IsIdentical(queue1, queue2));

            //// Check if the queues are similar/2.4/q1.b
            //Console.WriteLine("_____________________2.4/q1.b____________________________");
            //Console.WriteLine("are The queues similar: " + IsSimiler(queue1, queue2));

            ////Check if an item exists in the queue/ 2.4 / q2
            //Console.WriteLine("_____________________2.4/q2.a____________________________");
            //Console.WriteLine("please enter the number you want to find in queue:");
            //int queueNum = int.Parse(Console.ReadLine());
            //Console.WriteLine("is the item in the queue: " + IsExit(queue1, queueNum));

            ////Clone the queue / 2.4 / q3
            //Console.WriteLine("_____________________2.4/q2.b,1____________________________");
            //Console.WriteLine("The cloned queue items are: " + clone(queue1));

            // Check if all items first number starts with the number the user gives/2.4/q4
            Console.WriteLine("_____________________2.4/q2.b,2____________________________");
            Console.WriteLine("do all items in the queue match the condition: " + AllExit(queue1));
            

            Console.ReadKey();
        }
    }
}
