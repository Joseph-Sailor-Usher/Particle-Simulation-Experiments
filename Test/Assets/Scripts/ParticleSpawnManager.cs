using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Particle {
    public Particle(GameObject physicalSphere)
    {
        radius = 0.0f;
        position = Vector3.zero;
        velocity = Vector3.zero;
        mySphere = physicalSphere;
    }
    public float radius;
    public Vector3 position;
    public Vector3 velocity;
    public GameObject mySphere;
}

public class ParticleSpawnManager : MonoBehaviour
{
    public Vector3 grav;
    public Particle[] particles = new Particle[1000];
    public bool Simulate = false;

    public ParticleSpawnManager() {}

    private GameObject tempGameObject;
    public GameObject particlePrefab;
    private Particle tempParticle;
    private int temp = 0;

    public PoolManager ballPooler;

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    tempGameObject = ballPooler.Withdraw();
                    tempGameObject.transform.position = new Vector3(i, j + 0.5f, k);
                    tempGameObject.transform.parent = this.transform;
                    tempParticle = new Particle(tempGameObject);
                    tempParticle.radius = 0.5f;
                    tempParticle.velocity = Vector3.up * 10f;
                    tempParticle.mySphere = tempGameObject;
                    tempParticle.position = tempParticle.mySphere.transform.position;
                    particles[temp] = tempParticle;
                    temp++;
                }
            }
        }
    }

    private void Update()
    {
        if (Simulate == false) return;

        for (int i = 0; i < particles.Length; i++)
        {

            if(particles[i].position.y < 0.5f && particles[i].velocity.y < 0)
                particles[i].velocity *= -1.0f;
        }
        for (int i = 0; i < particles.Length; i++)
        {
            Debug.Log(particles[i].position);
            particles[i].velocity += grav * Time.deltaTime;
            particles[i].position += particles[i].velocity * Time.deltaTime;
            particles[i].mySphere.transform.position = particles[i].position;
        }
    }
}
