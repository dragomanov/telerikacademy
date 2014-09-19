namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Connection
    {
        public Node Node { get; set; }
        public double Distance { get; set; }

        public Connection(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
    }

    public class Node : IComparable<Node>
    {
        public int PointID { get; set; }

        public double DijktraDistance { get; set; }

        public Node(int houseNumber, double dijktraDistance)
        {
            this.PointID = houseNumber;
            this.DijktraDistance = dijktraDistance;
        }

        public override int GetHashCode()
        {
            return this.PointID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return this.PointID.Equals(other.PointID);
        }

        public int CompareTo(Node other)
        {
            return this.DijktraDistance.CompareTo(other.DijktraDistance);
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> bag;

        public PriorityQueue()
        {
            this.bag = new OrderedBag<T>();
        }

        public int Count
        {
            get
            {
                return this.bag.Count;
            }
        }

        public T Peek()
        {
            return bag[0];
        }

        public void Enqueue(T element)
        {
            this.bag.Add(element);
        }

        public T Dequeue()
        {
            var element = this.bag.GetFirst();
            this.bag.RemoveFirst();
            return element;
        }
    }

    public class FriendsOfPesho
    {
        private static Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();


        static void DijkstraAlgorithm(Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijktraDistance = double.PositiveInfinity;
                queue.Enqueue(node.Key);
            }

            source.DijktraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijktraDistance == double.PositiveInfinity)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    double potDistance = currentNode.DijktraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijktraDistance)
                    {
                        neighbour.Node.DijktraDistance = potDistance;
                        //Node next = new Node(neighbour.Node.PointID, potDistance);
                        //queue.Enqueue(next);
                    }
                }

                queue.Dequeue();
            }
        }

        public static void Main()
        {
            //Node test = new Node(11230, double.PositiveInfinity);
            //Node test2 = new Node(11230, double.PositiveInfinity);

            //graph.Add(test, new List<Connection>() { new Connection(test, 123) });

            //Console.WriteLine(graph.ContainsKey(test2));

            string[] initialParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfNodes = int.Parse(initialParams[0]);
            int numberOfStreets = int.Parse(initialParams[1]);
            int numberOfHospitals = int.Parse(initialParams[2]);

            string[] hostitalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hospitalNumbers = new int[hostitalParams.Length];

            for (int i = 0; i < hostitalParams.Length; i++)
            {
                hospitalNumbers[i] = int.Parse(hostitalParams[i]);
            }

            for (int i = 0; i < numberOfStreets; i++)
            {
                string[] currentParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentNumbers = new int[currentParams.Length];

                for (int j = 0; j < currentParams.Length; j++)
                {
                    currentNumbers[j] = int.Parse(currentParams[j]);
                }

                Node firstNode = new Node(currentNumbers[0], double.PositiveInfinity);
                Node secondNode = new Node(currentNumbers[1], double.PositiveInfinity);

                if (graph.ContainsKey(firstNode))
                {
                    graph[firstNode].Add(new Connection(secondNode, currentNumbers[2]));
                }
                else
                {
                    graph.Add(firstNode, new List<Connection>() { new Connection(secondNode, currentNumbers[2]) });
                }

                if (graph.ContainsKey(secondNode))
                {
                    graph[secondNode].Add(new Connection(firstNode, currentNumbers[2]));
                }
                else
                {
                    graph.Add(secondNode, new List<Connection>() { new Connection(firstNode, currentNumbers[2]) });
                }
            }

            double bestSum = double.MaxValue;

            for (int i = 0; i < hospitalNumbers.Length; i++)
            {
                DijkstraAlgorithm(new Node(hospitalNumbers[i], 0));

                double sum = 0;

                foreach (var item in graph)
                {
                    if (!hospitalNumbers.Contains(item.Key.PointID))
                    {
                        sum += item.Key.DijktraDistance;
                    }
                }

                if (sum < bestSum)
                {
                    bestSum = sum;
                }

                Console.WriteLine("HOSPITAL {0}", hospitalNumbers[i]);

                foreach (var item in graph)
                {
                    Console.WriteLine("Edge: {0}, Distanece -----> {1}", item.Key.PointID, item.Key.DijktraDistance);
                }
            }

            Console.WriteLine(bestSum);
        }
    }
}