using UnityEngine;
using System.Collections.Generic;



public class FlockController : MonoBehaviour
{
    [Header("Flock Data")]
    [SerializeField] private int flockSize = 20;
    [SerializeField] private float speedModifier = 5;
    [SerializeField] private float alignmentWeight = 1;
    [SerializeField] private float cohesionWeight = 1;
    [SerializeField] private float separationWeight = 1;
    [SerializeField] private float followWeight = 5;

    [Header("Boid Data")]
    [SerializeField] private Boid prefab;
    [SerializeField] private float spawnRadius = 3.0f;

    [Header("Target Data")]
    [SerializeField] private Transform target;
    [SerializeField] private List<Boid> flockList = new List<Boid>();

    public float SpeedModifier { get { return speedModifier; } }

    private void Awake()
    {
        flockList = new List<Boid>(flockSize);

        CreateBoid(flockSize);
    }

    private void CreateBoid(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 spawnLocation = Random.insideUnitSphere * spawnRadius + transform.position;
            Boid boid = Instantiate(prefab, spawnLocation, transform.rotation) as Boid;

            boid.FlockController = this;
            flockList.Add(boid);
        }

    }


    public Vector3 Flock(Boid boid)
    {
        if (target == null)
        {
            return Vector3.zero;
        }
        flockDirection = Vector3.zero;
        flockCenter = Vector3.zero;
        targetDirection = Vector3.zero;
        boidSeparation = Vector3.zero;
        Vector3 boidPosition = boid.transform.position;

        for (int i = 0; i < flockList.Count; ++i)
        {
            Boid neighbor = flockList[i];
            if (neighbor != boid)
            {
                flockDirection += neighbor.Direction;
                flockCenter += neighbor.transform.position;
                boidSeparation += neighbor.transform.position - boidPosition;
                boidSeparation *= -1;
            }
        }

        //Alignment. The avereage direction of all boids.
        flockDirection /= flockSize;
        flockDirection = flockDirection.normalized * alignmentWeight;

        //Cohesion. The centroid of the flock.
        flockCenter /= flockSize;
        flockCenter = flockCenter.normalized * cohesionWeight;

        //Separation.
        boidSeparation /= flockSize;
        boidSeparation = boidSeparation.normalized * separationWeight;

        //Direction vector to the target of the flock.
        targetDirection = target.position - boidPosition;
        targetDirection = targetDirection * followWeight;

        return flockDirection + flockCenter + boidSeparation + targetDirection;
    }

    private Vector3 flockCenter;
    private Vector3 flockDirection;
    private Vector3 targetDirection;
    private Vector3 boidSeparation;
}