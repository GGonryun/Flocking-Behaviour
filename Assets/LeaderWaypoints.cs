using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderWaypoints : IWaypointContainer
{
    private readonly Transform _leader;

    public LeaderWaypoints(Transform leader)
    {
        _leader = leader;
    }

    public Transform GetTarget(Transform current, FlockController flock)
    {
        return _leader;
    }
}
