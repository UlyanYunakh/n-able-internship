using System;
using System.Collections;

// 
// Связный список
// 

// Примечание:
// 1) методы Remove по коду отличаются только в одном месте, мб это можно всё сделать одним методом.
// 2) список очень похож по базовой функциональности стандартного List, там тоже можно по индексам 
// обращаться. мб я задачу неправильно решил. 
// 3) имплементацию IEnumerable подсмотрел, нужно нормально разобраться в этом интерфейсе, а то я 
// пропустил как-то
// 4) сортировка не работает :с

public class LinkedList<T> : IEnumerable where T : IComparable
{
    public int Count
    {
        get  // кол-во узлов в списке
        {
            int count = 0;
            Node<T> curr = _head;
            while (curr != null)
            {
                count++;
                curr = curr.Next;
            }
            return count;
        }
    }

    public T this[int reqIndex]  // индексатор
    {
        get
        {
            Node<T> curr = _head;
            for (int index = 0; index < Count; index++)
            {
                if (index == reqIndex)
                {
                    return curr.Value;
                }
                else
                {
                    curr = curr.Next;
                }
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            Node<T> curr = _head;
            for (int index = 0; index < Count; index++)
            {
                if (index == reqIndex)
                {
                    curr.Value = value;
                    return;
                }
                else
                {
                    curr = curr.Next;
                }
            }

            throw new IndexOutOfRangeException();
        }
    }

    private Node<T> _head;

    public void Add(T newValue) // в конец
    {
        Node<T> newNode = new Node<T>() { Value = newValue };
        Node<T> tail = _head;

        if (tail != null)
        {
            while (tail.Next != null)
            {
                tail = tail.Next;
            }
            tail.Next = newNode;
        }
        else
        {
            _head = newNode;
        }
    }

    public void Insert(T newValue) // в начало
    {
        Node<T> newNode = new Node<T>() { Value = newValue };
        newNode.Next = _head;
        _head = newNode;
    }

    public void Insert(T newValue, int reqIndex) // после reqIndex
    {
        Node<T> newNode = new Node<T>() { Value = newValue };
        Node<T> curr = _head;

        for (int index = 0; index < Count; index++)
        {
            if (index == reqIndex)
            {
                newNode.Next = curr.Next;
                curr.Next = newNode;
                return;
            }
            else
            {
                curr = curr.Next;
            }
        }

        throw new IndexOutOfRangeException();
    }

    public void Remove(T removeValue) // по первому совпавшему значению
    {
        Node<T> curr = _head;
        Node<T> prev = null;

        while (curr != null)
        {
            if (curr.Value.CompareTo(removeValue) == 0)
            {
                if (prev == null)
                {
                    _head = curr.Next;
                }
                else if (curr.Next == null)
                {
                    prev.Next = null;
                }
                else
                {
                    prev.Next = curr.Next;
                }
                return;
            }
            else
            {
                prev = curr;
                curr = curr.Next;
            }
        }
    }

    public void Remove(int reqIndex) // по индексу
    {
        Node<T> curr = _head;
        Node<T> prev = null;

        for (int index = 0; index < Count; index++)
        {
            if (index == reqIndex)
            {
                if (prev == null)
                {
                    _head = curr.Next;
                }
                else if (curr.Next == null)
                {
                    prev.Next = null;
                }
                else
                {
                    prev.Next = curr.Next;
                }
                return;
            }
            else
            {
                prev = curr;
                curr = curr.Next;
            }
        }

        throw new IndexOutOfRangeException();
    }

    public void Sort()
    {
        // Node<T> curr = _head;
        // Node<T> newHead = _head;
        // 
        // while (curr != null)
        // {
        //     Node<T> min = curr;
        //     Node<T> temp = curr.Next;
        //     Node<T> prev = null;
        // 
        //     while (temp != null)
        //     {
        //         if (temp.Value.CompareTo(min.Value) < 0)
        //         {
        //             min = temp;
        //         }
        //     }
        // 
        //     temp.Next = curr.Next;
        //     curr.Next = _head;
        //     _head = curr;
        //     curr = temp.Next;
        // }
        // 
        // // // тупая версия: создавать новый список
        // 
        // LinkedList<T> newList = new LinkedList<T>();
        // 
        // for (int index = 0; index < Count; index++)
        // {
        //     int minIndex = index;
        //     for (int i = index + 1; i < Count; i++)
        //     {
        //         if (this[i].CompareTo(this[minIndex]) < 0)
        //         {
        //             minIndex = i;
        //         }
        //     }
        // 
        //     newList.Add(this[minIndex]);
        // }
        // 
        // return newList;
    }

    public void Reverse()
    {
        Node<T> curr = _head.Next;
        Node<T> temp = new Node<T>();
        temp.Next = curr;
        _head.Next = null;

        while (curr != null)
        {
            temp.Next = curr.Next;
            curr.Next = _head;
            _head = curr;
            curr = temp.Next;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        Node<T> curr = _head;
        while (curr != null)
        {
            yield return curr.Value;
            curr = curr.Next;
        }
    }
}