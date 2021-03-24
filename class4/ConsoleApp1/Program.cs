using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 节点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    /// <summary>
    /// 链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> tem = head;
            while (tem != null)
            {
                action(tem.Data);
                tem = tem.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> linkedList = new GenericList<int>();
            //随便先赋个值
            for(int i = 0; i < 5; i++)
            {
                linkedList.Add((int)Math.Pow(i + 1, 2));
            }
            Node<int> n = linkedList.Head;

            int sum = 0;//求和
            int max = n.Data;//最大
            int min = n.Data;//最小
            Action<int> act = m => sum += m;
            act += m => { if (max < m) max = m; };
            act += m => { if (min > m) min = m; };
            act += m => Console.Write(m + " ");
            //遍历输出
            linkedList.ForEach(act);
            //看结果
            Console.WriteLine($"\n最大值 {max} ,最小值 {min} ,总和{sum}");
        }
    }
}
