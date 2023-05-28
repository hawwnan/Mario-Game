using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWayPointIndex = 0;
    public float speed = 3f;



    // Update is called once per frame
    void Update()
    {
        //we measure the distance between the platform and waypoint and if they are close then we change directon
        if(Vector3.Distance(transform.position, waypoints[currentWayPointIndex].transform.position) < .1f){
            currentWayPointIndex++;
            if(currentWayPointIndex >= waypoints.Length){
                currentWayPointIndex = 0;
            }
        }

        // we calculate the distace between the two objects and moves the platform towards the waypoint in each frame. we move the object towards the target by updating is position
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
