using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;

    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        //This trigger movement when player touches the GO.
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            //Increases waypoint array by 1.
            currentWaypointIndex++;
            //waypoints.length is the total of arrays we have. If it go past the maximum, currentwaypoints resets to 0.
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        //GO position moves from position to position.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position,
                                speed * Time.deltaTime);
    }

    public void ElevatorOnEnable()
    {
        this.gameObject.GetComponent<WayPointFollower>().enabled = true;
    }
}
