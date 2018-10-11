using System;
using System.Collections;
using UnityEngine;

//Referenced from Sebastian Lague's A* Pathfinding Tutorial: heap optimization

public class Heap<T> where T : IHeapItem<T>{

    T[] items;
    int currentItemCount;
	
    public Heap(int maxHeapSize){
        items = new T[maxHeapSize];
    }

    public void Add(T item){
        item.HeapIndex = currentItemCount;
        //insert at end of array
        items[currentItemCount] = item;
        SortUp(item);
        currentItemCount++;
    }

    public T RemoveFirst() {
        T firstItem = items[0];
        currentItemCount--;
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return firstItem;
    }

    public void UpdateItem(T item) {
        SortUp(item);
        //in pathfinding, we only really ever need to sort up
    }

    public int Count {
        get {
            return currentItemCount;
        }
    }

    public bool Contains(T item) {
        //check if item is same as idem passed in
        return Equals(items[item.HeapIndex], item);
    }

    void SortDown(T item) {
        while (true) {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;
            
            if(childIndexLeft < currentItemCount) { //if item has one child (left child)
                swapIndex = childIndexLeft;

                if(childIndexRight < currentItemCount) { //check if there's right child
                    if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0) {
                        //if left is smaller than right
                        swapIndex = childIndexRight;
                    }
                }

                if(item.CompareTo(items[swapIndex]) < 0) {
                    Swap(item, items[swapIndex]);
                }
                else { //parent has higher priority than both children
                    return;
                }
            }
            else {//parent has no children
                return;
            }
        }
    }
    
    void SortUp(T item) {
        int parentIndex = (item.HeapIndex - 1) / 2;
        while (true) {
            T parentItem = items[parentIndex];
            if(item.CompareTo(parentItem) > 0) {
                Swap(item, parentItem);
            }
            else {
                break;
            }

            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }

    void Swap(T itemA, T itemB) {
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;
        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }
}

public interface IHeapItem<T> : IComparable<T>{
    int HeapIndex {
        get;
        set;
    }
}
