using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Iterator
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        public abstract int key();
        public abstract object Current();
        public abstract bool MoveNext();
        public abstract void Reset();        
    }

    abstract class IteratorAggregate: IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection _collection;

        private int _position = -1;

        private bool _reverse  = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = this._collection.getItems().Count;
            }
        }

        public override object Current()
        {
            return this._collection.getItems()[this._position];
        }

        public override int key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);
            if(updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.getItems().Count-1 : 0;
        }
    }

    class WordsCollection: IteratorAggregate
    {
        List<string> _collection = new List<string>();
        bool _direction = false;
        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<string> getItems()
        {
            return _collection;
        }

        public void AddItem(string item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new WordsCollection();
            collection.AddItem("a");
            collection.AddItem("b");
            collection.AddItem("c");

            Console.WriteLine("Straight traversal:");
            foreach(var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Reverse traversal:");
            collection.ReverseDirection();
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

        }
    }
}
