using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Script for updating a particle system.
/// @author: Tobias Alldén
/// </summary>
public class PartCloudsyste : MonoBehaviour
{
    public GameObject pointCloudBase;
    public GameObject particleGameObject;

    private Dictionary<int,ParticleSystem> particleSystemIdMap;
    private Stack<List<ParticleSystem.Particle>> particleListPool;
    private List<ParticleSystem.Particle> particleBuffer; //allows for reusing particles
    private ParticleSystem.Particle[] oldParticles;
    private List<ParticleSystem.Particle> particleCloud;
    private int maxParticlesPerCloud = 50;
    

    void Awake(){
        // 创建粒子系统
        particleSystemIdMap = new Dictionary<int,ParticleSystem>();
        particleBuffer = new List<ParticleSystem.Particle>();
        particleListPool = new Stack<List<ParticleSystem.Particle>>();
        oldParticles = new ParticleSystem.Particle[maxParticlesPerCloud];
        particleCloud = new List<ParticleSystem.Particle>();

        pointCloudBase = GameObject.FindGameObjectWithTag("PointCloudBase");

        // for(int par_=0;par_ < 100;par_++){
            GameObject newGO = Instantiate(particleGameObject, pointCloudBase.transform.position, Quaternion.identity);
            newGO.name = "pSyst" + 0;
            ParticleSystem p = newGO.GetComponent<ParticleSystem>();
            p.transform.SetParent(pointCloudBase.transform);
            particleSystemIdMap.Add(0, p);
        // }
        float radius = 5f;
        float det = 0.01f;
        for(int p_ =0;p_ < 2000;p_++){
            ParticleSystem.Particle particle = new ParticleSystem.Particle();;
            
            Vector3 cartesian = new Vector3();

            cartesian.y = 10 * Mathf.Sin(det * p_ );
            cartesian.x = radius * Mathf.Sin(p_ * det);
            cartesian.z = radius * Mathf.Cos(p_ * det);
            

            
            particle.startColor = Color.green;
            
            particle.position = cartesian;
            particle.startSize = 0.05f;
            particle.startLifetime = 100f;
            particle.remainingLifetime = 200f;
            particleCloud.Add(particle);
        }        
        particleSystemIdMap[0].SetParticles(particleCloud.ToArray(), particleCloud.Count);
    }


    void OnDestroy()
    {
        
    }

    void  FixedUpdate(){

        // ParticleSystem currentParticleSystem = particleSystemIdMap[usedParticleSystem];

    }
}