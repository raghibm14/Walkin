using UnityEngine;
using System.Collections;
class rec
{
    public int v;
    public int weight;
    public rec(int i, int j)
    {
        v = i;
        weight = j;
    }
}
class pq
{
    rec[] heap;
    int heapSize;
    rec temp;
    public pq(int source)
    {
        heapSize = 0;
        heap = new rec[100000];
        heap[0] = new rec(0, 0);

        heapSize++;
        heap[1] = new rec(source, 0);
    }
    public void insert(rec entry)
    {
        heapSize++;
        heap[heapSize] = entry;

        int now = heapSize;
        while (heap[now / 2].weight > entry.weight && (now / 2 != 0))
        {
            heap[now] = heap[now / 2];
            now /= 2;
        }
        heap[now] = entry;
    }
    public rec top()
    {
        if (heap[1] != null)
        {
            Debug.Log(heap[1].v + " : " + heap[1].weight);
            return heap[1];
        }
        return null;
    }


  
    int leftc(int i)
    {
        if (2 * i <= heapSize)
            return 2 * i;
        else
            return -1;
    }
    int rightc(int i)
    {
        if (2 * i + 1 <= heapSize)
            return 2 * i + 1;
        else
            return -1;
    }
    void procrate(int i)
    {
        //	cout<<"we are here"<<endl;
        int l = leftc(i);
        int r = rightc(i);
        int min = i;
        if (l != -1 && heap[l].weight < heap[i].weight)
        {
            min = l;
        }

        if (r != -1 && heap[r].weight < heap[min].weight)
        {
            min = r;
        }
        if (min != i)
        {
            rec temp = heap[i];
            heap[i] = heap[min];
            heap[min] = temp;
        }
        if (min != i)
        {
            procrate(min);
        }
    }

    public void delete()
    {
        heap[1] = heap[heapSize];
        heapSize--;
        procrate(1);
    }
    public void print()
    {
        for (int i = 1; i <= heapSize; i++)
        {
            Debug.Log("at " + heap[i].v + " : " + heap[i].weight);
        }
    }
    public int size()
    {
        return heapSize;
    }
    public bool isEmpty()
    {
        if(heapSize==0)
        {
            return true;
        }
        return false;
    }
}