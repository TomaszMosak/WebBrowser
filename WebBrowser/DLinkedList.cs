using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser {
    public class Node<K, V> {
        private Node<K, V> Previous { get; set; } //previous node 
        private Node<K, V> Next { get; set; } //next node 
        private Tuple<K, V> data; //data/element
        
        /// <summary>
        /// First element of the list constructor
        /// </summary>
        /// <param name="data">The Key, Value of the Node</param>
        public Node(Tuple<K, V> data) {
            this.data = data;
            
        }

        /// <summary>
        /// 2nd Constructor for all other elements of the DLL
        /// </summary>
        /// <param name="data">The Key, Value of the Node</param>
        /// <param name="prevNode">A pointer to the previous node</param>
        public Node(Tuple<K, V> data, Node<K, V> prevNode) {
            this.data = data;
            this.Previous = prevNode;
            prevNode.Next = this;
        }

        /// <summary>
        /// Property for showing the previous node
        /// </summary>
        public Node<K, V> GetPrevious {
            get { return this.Previous; }
            set { this.Previous = value; }
        }

        /// <summary>
        /// Property for showing the next node
        /// </summary>
        public Node<K,V> GetNext {
            get { return this.Next; }
            set { this.Next = value; }
        }

        /// <summary>
        /// Property for showing the data (used with conjunction of the indexer to get the K,V values
        /// </summary>
        public Tuple<K, V> GetData {
            get { return this.data; }
        }


    }
    public class DoublyLinkedList<K, V>
{
    Node<K, V> Head { get; set; }
    Node<K, V> Tail { get; set; }
    private int count;
    
        /// <summary>
        /// New instance of the DLL is empty
        /// </summary>
    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
        this.count = 0;
    }

        /// <summary>
        /// Returns the size of the DLL
        /// </summary>
        public int Count {
            get {  return this.count;  }
        }

        /// <summary>
        /// Indexer over all the nodes
        /// </summary>
        /// <param name="index">A integer which gives each node a value</param>
        /// <returns>CurrentNode</returns>
        public Node<K,V> this[int index] {
            get {
                if (index >= count || index < 0) {
                    throw new ArgumentOutOfRangeException("Out of Range, UNACCEPTABLE!");
                }
                Node<K, V> currentNode = this.Head;
                for (int i = 0; i < index; i++) {
                    currentNode = currentNode.GetNext;
                }
                return currentNode; 
            }
            set {
                if (index >= this.count || index < 0) {
                    throw new ArgumentOutOfRangeException("Out of Range, UNACCEPTABLE!");
                }
                Node<K, V> currentNode = this.Head;
                for (int i=0; i < index; i++) {
                    currentNode = currentNode.GetNext;
                }
                currentNode = value;
            }
        }

        /// <summary>
        /// Inserts a new node into the DLL by moving pointers to the new node inserted
        /// </summary>
        /// <param name="key">This is different for History/Favourites</param>
        /// <param name="URL">This is the value of all nodes, called URL as this is always a URL string</param>
    public void Insert(K key, V URL) {
        Node<K, V> newN = new Node<K, V>(new Tuple<K, V>(key, URL));
        if (this.Head == null) {
                this.Head = new Node<K, V>(new Tuple<K, V>(key, URL));
                this.Tail = this.Head;
            } else {
                Node<K,V> newItem = new Node<K, V>(new Tuple<K, V>(key, URL), Tail);
                this.Tail = newItem;
            }
            count++;
    }

        /// <summary>
        /// This removes the node which is under the index which is passed in
        /// </summary>
        /// <param name="index">A number</param>
    public void Remove(int index) {
            if (index >= this.count || index < 0) {
                throw new ArgumentOutOfRangeException("Out of Range, UNACCEPTABLE!");
            }
            int currentIndex = 0;
            Node<K, V> currentItem = this.Head;
            Node<K, V> prevItem = null;
            while(currentIndex < index) {
                prevItem = currentItem;
                currentItem = currentItem.GetNext;
                currentIndex++;
            }
            if (this.count == 0) {
                this.Head = null;
            } else if (prevItem == null) {
                this.Head = currentItem.GetNext;
                this.Head.GetPrevious = null;
            } else if (index == count - 1) {
                prevItem.GetNext = currentItem.GetNext;
                Tail = prevItem;
                currentItem = null;
            } else {
                prevItem.GetNext = currentItem.GetNext;
                currentItem.GetNext.GetPrevious = prevItem;
            }
            count--;
        }

        /// <summary>
        /// Checks if the key appears in the DLL
        /// </summary>
        /// <param name="key">The key to find</param>
        /// <returns>Bool expression - True/False</returns>
        public bool ContainsKey(K key) {
            for (int i = 0; i < count; i++) {
                if (this[i].GetData.Item1.Equals(key)) return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the value appears in the DLL
        /// </summary>
        /// <param name="key">The value to find</param>
        /// <returns>Bool expression - True/False</returns>
        public bool ContainsValue(V URL) {
            for (int i = 0; i < count; i++) {
                if (this[i].GetData.Item2.Equals(URL)) return true;
            }
            return false;
        }


        /// <summary>
        /// Removes the pointers and allows garbage collector to take care of deleting the actual nodes
        /// Sets the count back to 0
        /// </summary>
        public void Clear() {
            this.Head = null;
            this.Tail = null;
            this.count = 0;
        }

}
}