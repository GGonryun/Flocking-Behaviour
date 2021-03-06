﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetingMode { None, Leader, Lazy, Circle }

public class Targeter : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private Transform pointFolder;
    [SerializeField] private Transform leader;
    [SerializeField] private TargetingMode mode;
    public TargetingMode Mode
    {
        set => mode = value;
    }
    [SerializeField] private int pointCount;
    [SerializeField] private float circleRadius;
    [SerializeField] private float randomBounds;
    [SerializeField] private FlockController flock;

    private Dictionary<TargetingMode, IWaypointContainer> points;

    private void Awake()
    {
        points = new Dictionary<TargetingMode, IWaypointContainer>()
        {
            {TargetingMode.None, new NoWaypoints() },
            {TargetingMode.Lazy, new RandomWaypoints(pointPrefab, pointFolder, pointCount, randomBounds) },
            {TargetingMode.Circle, new CircleWaypoints(pointPrefab, pointFolder, pointCount, circleRadius) },
            {TargetingMode.Leader, new LeaderWaypoints(leader) }
        };
    }

    float refreshRate = 1f;
    float currentTime = 0f;
    Transform target = null;
    TargetingMode previous;
    private void FixedUpdate()
    {
        if(currentTime > refreshRate)
        {
            if(previous != mode)
            {
                flock.Target = target = null;
            }
            currentTime -= refreshRate;
            flock.Target = target = points[mode].GetTarget(target, flock);
            previous = mode;
        }
        currentTime += Time.deltaTime;
    }
}
