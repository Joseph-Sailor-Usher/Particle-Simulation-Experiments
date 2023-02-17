using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAides : MonoBehaviour
{
    public PoolManager arrowHeadPool, linePool, dashedLinePool;

    public GameObject DrawLine(Vector3 start, Vector3 end)
    {
        GameObject tempGameObject = linePool.Withdraw();
        //All the scaling and translating

        return tempGameObject;
    }
    public GameObject DrawDashedLine(Vector3 start, Vector3 end)
    {
        GameObject tempGameObject = linePool.Withdraw();
        //All the scaling and translating

        return tempGameObject;
    }
    public GameObject DrawArrow(Vector3 start, Vector3 end)
    {
        GameObject tempLine = DrawLine(start, end), tempGameObject = arrowHeadPool.Withdraw();
        tempLine.transform.parent = tempGameObject.transform;
        //All the scaling and translating for the arrowHead

        return tempGameObject;
    }
}
