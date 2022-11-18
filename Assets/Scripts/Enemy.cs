using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0;
    public List<Transform> waypoints;
    private int _waypointIndex;
    private float _range;
    void Start()
    {
        _waypointIndex = 0;
        _range = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
          move();          
    }

    void move()
    {
        transform.LookAt(waypoints[_waypointIndex]);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[_waypointIndex].position)<_range)
        {
            _waypointIndex++;
            if (_waypointIndex >= waypoints.Count)
            {
                _waypointIndex = 0;
            }
            
        }
    }
}
