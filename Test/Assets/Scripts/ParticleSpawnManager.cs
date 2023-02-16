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
    public Particle[] particles;
    public bool Simulate = false;

    public ParticleSpawnManager() {}

    private GameObject tempGameObject;
    public GameObject particlePrefab;
    private Particle tempParticle;
    public Vector3 initialParticles = Vector3.one;
    private int temp = 0;

    public PoolManager ballPooler;

    private void Start()
    {
        particles = new Particle[(int)(initialParticles.x * initialParticles.y * initialParticles.z)];
        for(int i = 0; i < initialParticles.x; i++)
        {
            for (int j = 0; j < initialParticles.y; j++)
            {
                for (int k = 0; k < initialParticles.z; k++)
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

        StartCoroutine("PhysicsTick");
    }
    private IEnumerator PhysicsTick()
    {
        //Bounce when you hit the ground
        for (int i = 0; i < particles.Length; i++)
            if(particles[i].position.y < 0.5f && particles[i].velocity.y< 0)
                particles[i].velocity *= -1.0f;

        UpdateVelocityandPositionForAllParticles();

        yield return new WaitForSeconds(0.01f);
        StartCoroutine("PhysicsTick");
    }

    private void UpdateVelocityandPositionForAllParticles()
    {
        if (Simulate == false) return;
        //Apply gravitational acceleration and update position, and 
        for (int i = 0; i < particles.Length; i++)
        {
            //Debug.Log(particles[i].position);
            particles[i].velocity += grav * 0.01f;
            particles[i].position += particles[i].velocity * 0.01f;
            particles[i].mySphere.transform.position = particles[i].position;
        }
    }
}
