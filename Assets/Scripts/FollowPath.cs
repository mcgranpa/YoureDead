using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPath : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] float Speed = 10f;

    int pointIndex;

    void Start()
    {
        pointIndex = 0;
    }

    void Update()
    {
        if (pointIndex > (Points.Length - 1))
        {
            pointIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].position, Time.deltaTime * Speed);

        if (transform.position == Points[pointIndex].position)
            pointIndex++;

    }

    public void OnDrawGizmos()
    {
        if (Points == null || Points.Length < 2)
            return;

        var points = Points.Where(t => t != null).ToList();
        if (points.Count < 2)
            return;

        for (var i = 1; i < points.Count; i++)
        {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }
    }

}
