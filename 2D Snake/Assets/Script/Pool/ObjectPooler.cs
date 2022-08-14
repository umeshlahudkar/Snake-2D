using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : GenericSingleton<ObjectPooler>
{

    List<PoolItem> pooledItems = new List<PoolItem>();

    public GameObject GetObject(GameObject snakeSegment, ObjectType _objectType)
    {
        if(pooledItems.Count > 0)
        {
            PoolItem segment = pooledItems.Find(item => (item.IsUsed == false) && (item.objectType == _objectType));
            if(segment != null)
            {
                segment.IsUsed = true;
                return segment.Item;
            }
        }
        return CreateNewObject(snakeSegment, _objectType);
    }

    private GameObject CreateNewObject(GameObject snakeSegment, ObjectType _objectType)
    {
        PoolItem newSegment = new PoolItem();
        newSegment.Item = GameObject.Instantiate(snakeSegment);
        newSegment.objectType = _objectType;
        newSegment.IsUsed = true;
        pooledItems.Add(newSegment);
        return newSegment.Item;
    }

    public void ReturnToPool(GameObject segment, ObjectType _objectType)
    {
        PoolItem item = pooledItems.Find(it => (it.Item.Equals(segment)) && (it.objectType == _objectType));
        if(item != null)
        {
            item.IsUsed = false;
        } 
           
    }
}

public class PoolItem
{
    public GameObject Item;
    public ObjectType objectType;
    public bool IsUsed;
}

public enum ObjectType
{
    None,
    MassBurnerFood,
    SnakeSegment
}
