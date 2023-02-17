using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    public Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject prefabObject;
    private GameObject tempGameObject;
    public int defaultObjectCount = 101;
    private void Start()
    {
        ResizePool(defaultObjectCount);
    }
    public void Deposit(GameObject usedElement)
    {
        usedElement.SetActive(false);
        pool.Enqueue(usedElement);
    }
    public GameObject Withdraw()
    {
        if(pool.Count <= 0)
            ResizePool(defaultObjectCount);
        tempGameObject = pool.Dequeue();
        tempGameObject.SetActive(true);
        return tempGameObject;
    }
    public void ResizePool(int newSize)
    {
        defaultObjectCount = newSize;
        if (prefabObject == null)
        {
            //Debug.Log("No default object on " + gameObject.name);
            gameObject.SetActive(false);
            return;
        }
        while (pool.Count < defaultObjectCount)
        {
            tempGameObject = Instantiate(prefabObject, transform.position, Quaternion.identity, this.transform);
            tempGameObject.SetActive(false);
            pool.Enqueue(tempGameObject);
        }
    }
}
