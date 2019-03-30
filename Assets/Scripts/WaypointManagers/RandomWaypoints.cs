using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWaypoints : IWaypointContainer
{
    public RandomWaypoints(GameObject prefab, Transform folder, int pointCount, float range)
    {
        _prefab = prefab;
        _pointCount = pointCount;
        _range = range;
        _folder = folder;
    }

    Transform IWaypointContainer.GetTarget(Transform current, FlockController flock)
    {
        Transform target = current;
        if(_waypoints == null)
        {
            Draw(_range);
        }

        if (target == null || FlockController.WithinRange(target, flock))
        {
            int index = Random.Range(0, _waypoints.Count);
            target = _waypoints[index];
        }
        return target;
    }

    void Draw(float range)
    {
        _waypoints = new List<Transform>(_pointCount);
        for (int i = 0; i < _pointCount; i++)
        {
            GameObject go = GameObject.Instantiate(_prefab, new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)), Quaternion.identity, _folder);
            go.name = $"Random Waypoint #{i}";
            _waypoints.Add(go.transform);
        }
    }
    private readonly int _pointCount;
    private readonly float _range;
    private readonly GameObject _prefab;
    private readonly Transform _folder;
    private List<Transform> _waypoints;
}
