using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWaypoints : IWaypointContainer
{
    Transform IWaypointContainer.GetTarget(Transform current, FlockController flock)
    {
        return null;
    }

   
}
