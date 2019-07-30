using System;
using System.Collections.Generic;
using System.Text;

namespace PitchMetrics.Models
{
    public class Node
    {
        public double Data { get; set; }
        public Node Next { get; set; }
        public Node(double data)
        {
            this.Data = data;
        }
    }
    public class Queue
    {
        private Node _head;
        private Node _tail;
        private int _count = 0;

        public Queue() { }

        public void Enqueue(double data)
        {
            Node _newNode = new Node(data);
            if (_head == null)
            {
                _head = _newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = _newNode;
                _tail = _tail.Next;
            }
            _count++;
        }
        public double Dequeue()
        {
            if (_head == null)
            {
                throw new Exception("Queue is Empty");
            }
            double _result = _head.Data;
            _head = _head.Next;
            return _result;
        }
        public int Count
        {
            get
            {
                return this._count;
            }
        }
    }
}
