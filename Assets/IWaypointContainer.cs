using System.Collections.Generic;
using UnityEngine;

public interface IWaypointContainer
{
    Transform GetTarget(Transform current, FlockController flock);
}