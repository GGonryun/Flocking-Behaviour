using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWaypoints : IWaypointContainer
{
    public CircleWaypoints(GameObject prefab, Transform folder, int pointCount, float radius)
    {
        _prefab = prefab;
        _pointCount = pointCount;
        _radius = radius;
        _folder = folder;
    }

    Transform IWaypointContainer.GetTarget(Transform current, FlockController flock)
    {
        Transform target = current;
        if(_waypoints == null)
        {
            Draw(_radius);
        }

        if (target == null)
        {
            target = _waypoints.Dequeue();
        }
        else if (FlockController.WithinRange(target, flock))
        {
            _waypoints.Enqueue(target);
            target = _waypoints.Dequeue();
        }

        return target;
    }

    void Draw(float radius)
    {
        float step = 2 * Mathf.PI / _pointCount;
        _waypoints = new Queue<Transform>(_pointCount);
        //x = r*cosθ
        //y = r*sinθ
        int i = 0;
        for (float theta = 0; theta <= 360f; theta += step)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            GameObject go = GameObject.Instantiate(_prefab, new Vector3(x, 0, z), Quaternion.identity, _folder);
            go.name = $"Circle Point #{i++}";
            _waypoints.Enqueue(go.transform);
        }
    }
    private readonly float _radius;
    private readonly int _pointCount;
    private readonly GameObject _prefab;
    private readonly Transform _folder;
    private Queue<Transform> _waypoints;
}
