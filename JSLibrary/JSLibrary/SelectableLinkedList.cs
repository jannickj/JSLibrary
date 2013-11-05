using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace JSLibrary
{
    [Serializable]
    public class SelectableLinkedList<T> : LinkedList<T>
    {

        [NonSerialized]
        private Dictionary<T, LinkedListNode<T>> selectableNodes = new Dictionary<T, LinkedListNode<T>>();

        public SelectableLinkedList()
        {
            
        }

        // Summary:
        //     Adds the specified new node after the specified existing node in the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The System.Collections.Generic.LinkedListNode<T> after which to insert newNode.
        //
        //   newNode:
        //     The new System.Collections.Generic.LinkedListNode<T> to add to the System.Collections.Generic.LinkedList<T>.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.  -or- newNode is null.
        //
        //   System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList<T>.  -or-
        //     newNode belongs to another System.Collections.Generic.LinkedList<T>.
        public new void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            base.AddAfter(node, newNode);
            selectableNodes[newNode.Value] = newNode;
        }
        //
        // Summary:
        //     Adds a new node containing the specified value after the specified existing
        //     node in the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The System.Collections.Generic.LinkedListNode<T> after which to insert a
        //     new System.Collections.Generic.LinkedListNode<T> containing value.
        //
        //   value:
        //     The value to add to the System.Collections.Generic.LinkedList<T>.
        //
        // Returns:
        //     The new System.Collections.Generic.LinkedListNode<T> containing value.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.
        //
        //   System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList<T>.
        public new LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> l = base.AddAfter(node, value);
            selectableNodes[value] = l;
            return l;
        }
        public LinkedListNode<T> AddAfter(T reference, T value)
        {
            LinkedListNode<T> l = base.AddAfter(selectableNodes[reference], value);
            selectableNodes[value] = l;
            return l;
        }
        //
        // Summary:
        //     Adds the specified new node before the specified existing node in the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The System.Collections.Generic.LinkedListNode<T> before which to insert newNode.
        //
        //   newNode:
        //     The new System.Collections.Generic.LinkedListNode<T> to add to the System.Collections.Generic.LinkedList<T>.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.  -or- newNode is null.
        //
        //   System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList<T>.  -or-
        //     newNode belongs to another System.Collections.Generic.LinkedList<T>.
        public new void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            base.AddBefore(node, newNode);
            selectableNodes[newNode.Value] = newNode;
        }
        //
        // Summary:
        //     Adds a new node containing the specified value before the specified existing
        //     node in the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The System.Collections.Generic.LinkedListNode<T> before which to insert a
        //     new System.Collections.Generic.LinkedListNode<T> containing value.
        //
        //   value:
        //     The value to add to the System.Collections.Generic.LinkedList<T>.
        //
        // Returns:
        //     The new System.Collections.Generic.LinkedListNode<T> containing value.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.
        //
        //   System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList<T>.
        public new LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> l = base.AddBefore(node, value);
            selectableNodes[value] = l;
            return l;
        }
        public LinkedListNode<T> AddBefore(T reference, T value)
        {
            LinkedListNode<T> l = base.AddBefore(selectableNodes[reference], value);
            selectableNodes[value] = l;
            return l;
        }
        //
        // Summary:
        //     Adds the specified new node at the start of the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The new System.Collections.Generic.LinkedListNode<T> to add at the start
        //     of the System.Collections.Generic.LinkedList<T>.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.
        //
        //   System.InvalidOperationException:
        //     node belongs to another System.Collections.Generic.LinkedList<T>.
        public new void AddFirst(LinkedListNode<T> node)
        {
            base.AddFirst(node);
            selectableNodes[node.Value] = node;
        }
        //
        // Summary:
        //     Adds a new node containing the specified value at the start of the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   value:
        //     The value to add at the start of the System.Collections.Generic.LinkedList<T>.
        //
        // Returns:
        //     The new System.Collections.Generic.LinkedListNode<T> containing value.
        public new LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> l = base.AddFirst(value);
            selectableNodes[value] = l;
            return l;
        }
        //
        // Summary:
        //     Adds the specified new node at the end of the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   node:
        //     The new System.Collections.Generic.LinkedListNode<T> to add at the end of
        //     the System.Collections.Generic.LinkedList<T>.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     node is null.
        //
        //   System.InvalidOperationException:
        //     node belongs to another System.Collections.Generic.LinkedList<T>.
        public new void AddLast(LinkedListNode<T> node)
        {
            base.AddLast(node);
            selectableNodes[node.Value] = node;
        }
        //
        // Summary:
        //     Adds a new node containing the specified value at the end of the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   value:
        //     The value to add at the end of the System.Collections.Generic.LinkedList<T>.
        //
        // Returns:
        //     The new System.Collections.Generic.LinkedListNode<T> containing value.
        public new LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> l = base.AddLast(value);
            selectableNodes[value] = l;
            return l;
        }
        //
        // Summary:
        //     Removes the first occurrence of the specified value from the System.Collections.Generic.LinkedList<T>.
        //
        // Parameters:
        //   value:
        //     The value to remove from the System.Collections.Generic.LinkedList<T>.
        //
        // Returns:
        //     true if the element containing value is successfully removed; otherwise,
        //     false. This method also returns false if value was not found in the original
        //     System.Collections.Generic.LinkedList<T>.
        public new bool Remove(T value)
        {
            if (!selectableNodes.ContainsKey(value))
                return false;
            else
            {
                LinkedListNode<T> node = selectableNodes[value];
                base.Remove(node);
                selectableNodes.Remove(value);
            }
            return true;
        }

        public void Replace(T Old, T New)
        {
            //LinkedListNode<T> l = selectableNodes[Old];
            //l.Value = New;
            //selectableNodes.Remove(Old);
            //selectableNodes.Add(New, l);
            this.AddAfter(Old, New);
            this.Remove(Old);

        }


        public LinkedListNode<T> this[T i]
        {
            get
            {
                return selectableNodes[i];
            }
        }

        public new bool Contains(T t)
        {
            return this.selectableNodes.ContainsKey(t);
        }

        public override void OnDeserialization(object sender)
        {
            base.OnDeserialization(sender);
            this.selectableNodes = new Dictionary<T, LinkedListNode<T>>();
            LinkedListNode<T> first = this.First;

            while (first != null)
            {
                this.selectableNodes[first.Value] = first;
                first = first.Next;
            }
        }

        

       
        
    }
}
