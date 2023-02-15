using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //Velocity and position need to be vector3's
    //Get radius from GetComponent RigidBody
    public float radius { get; set; }
    public Vector3 position { get; set; }
    public Vector3 velocity { get; set; }
    public GameObject mySphere;

    public ParticleController()
    {
        mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        position = 
        velocity = Vector3.zero;
        radius = 1f;
    }
    public ParticleController(GameObject parent)
    {
        mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        velocity = Vector3.zero;
        radius = 1f;
    }
    public ParticleController(GameObject parent, Vector3 position)
    {
        mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.transform.parent = parent.transform;
        mySphere.transform.position = position;
        velocity = Vector3.zero;
        radius = 1f;
    }
}
