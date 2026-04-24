using System.Collections;

namespace LinkedListTask
{
    public class Node
    {
        public char Data { get; set; }
        public Node Next { get; set; }

        public Node(char data)
        {
            Data = data;
            Next = null;
        }
    }
    
    public class LinkedList : IEnumerable
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }
        
        public char this[int index]
        {
            get
            {
                if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative.");
                
                Node current = head;
                int currentIndex = 0;

                while (current != null)
                {
                    if (currentIndex == index) return current.Data;
                    current = current.Next;
                    currentIndex++;
                }
                
                throw new IndexOutOfRangeException("Index is out of bounds.");
            }
            set
            {
                if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative.");
                
                Node current = head;
                int currentIndex = 0;

                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        current.Data = value;
                        return;
                    }
                    current = current.Next;
                    currentIndex++;
                }

                throw new IndexOutOfRangeException("Index is out of bounds.");
            }
        }
        
        public IEnumerator<char> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Prepend(char data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        public (Node node, int index) FindFirstOccurence(char target)
        {
            Node current = head;
            int index = 1;

            while (current != null)
            {
                if (current.Data == target)
                    return (current, index);
                
                current = current.Next;
                index++;
            }
            
            return (null, -1);
        }

        public int SumOfElementsGreaterThan(char target)
        {
            int sum = 0, index = 1;
            Node current = head;

            while (current != null)
            {
                if (current.Data > target)
                    sum += current.Data;
                
                current = current.Next;
                index++;
            }
            
            return sum;
        }

        public (LinkedList newList, int count) GetElementsAfter(char target)
        {
            LinkedList newList = new LinkedList();
            int count = 0;

            var (targetNode, _) = FindFirstOccurence(target);
            if (targetNode != null && targetNode.Next != null)
            {
                Node current = targetNode.Next;
                while (current != null)
                {
                    newList.Prepend(current.Data);
                    current = current.Next;
                    count++;
                }
            }

            return (newList, count);
        }

        public void RemoveElementsBefore(char target)
        {
            var (targetNode, _) = FindFirstOccurence(target);
            if (targetNode != null)
                head = targetNode;
        }

        public void Print()
        {
            Node current = head;
            if (current == null)
            {
                Console.WriteLine("список порожній.");
                return;
            }

            while (current != null)
            {
                Console.Write(current.Data + (current.Next != null ? " -> " : ""));
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}

