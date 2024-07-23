using System.Diagnostics;
using UnityEngine;

public class SecondaryEntrancetoReception : MonoBehaviour
{
    public GameObject arrowPrefab; // The 3D arrow model
    public Transform[] waypoints;  // The waypoints to guide the user
    public GameObject finalWaypointPrefab;
    public float thresholdDistance = 2.0f; // The distance at which the next arrow is shown, adjust as needed
    public int x, y, z;

    private GameObject currentArrow; // The current arrow being displayed
    private int currentWaypointIndex = 0; // The index of the current waypoint
    private bool isNavigationActive = false;

    void Start()
    {
        // Initially, do not instantiate any arrows until the QR code is detected
    }

    void Update()
    {
        // Only proceed with navigation if it's active
        if (isNavigationActive)
        {
            if (currentWaypointIndex < waypoints.Length && Vector3.Distance(Camera.main.transform.position, waypoints[currentWaypointIndex].position) < thresholdDistance)
            {
                MoveToNextWaypoint();
            }
        }
    }


    public void StartNavigation()
    {
        if (currentArrow != null)
        {
            Destroy(currentArrow);
        }

        currentArrow = Instantiate(arrowPrefab, waypoints[0].position, Quaternion.identity);
        currentWaypointIndex = 1; // Start checking for movement to the second waypoint
        isNavigationActive = true;

        if (finalWaypointPrefab == null)
        {
            UnityEngine.Debug.LogError("Final waypoint prefab is not assigned in the inspector.");
        }
    }


    private void MoveToNextWaypoint()
    {
        // If there's an arrow already, remove it
        if (currentArrow != null)
        {
            Destroy(currentArrow);
        }

        // If there are more waypoints, instantiate the next arrow
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            Vector3 position = waypoints[currentWaypointIndex].position;
            Vector3 directionToNextWaypoint = waypoints[currentWaypointIndex + 1].position - position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToNextWaypoint);

            // If you need to apply an additional rotation offset to align the arrow prefab correctly
            Quaternion offsetRotation = Quaternion.Euler(x, y, z); // Replace with the necessary x, y, z values
            Quaternion combinedRotation = lookRotation * offsetRotation;

            currentArrow = Instantiate(arrowPrefab, position, combinedRotation);
            currentWaypointIndex++;
        }
        else if (currentWaypointIndex == waypoints.Length - 1)
        {
            // Reached the final waypoint
            currentArrow = Instantiate(finalWaypointPrefab, waypoints[currentWaypointIndex].position, Quaternion.identity);
            UnityEngine.Debug.Log("Destination reached");
            isNavigationActive = false;
        }
    }
}
