#pragma strict
public var walk_speed : float = 2f; 
public var patrolWayPoints : Transform[];
public var patrolWaitTime : float = 5f;


private var agent : UnityEngine.AI.NavMeshAgent;
private var patrolTimer : float;
private var wayPointIndex : int;

function Awake () {
 agent = GetComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
 

 agent.SetDestination(patrolWayPoints[wayPointIndex].position);
 
}

function Update () {
 Patrolling();
 
}

function Patrolling ()
{
    // Set an appropriate speed for the NavMeshAgent.
    // nav.speed = walk_speed;
    if (Vector3.Distance(transform.position, patrolWayPoints[wayPointIndex].position)<4)
    {
        if(wayPointIndex == patrolWayPoints.Length - 1)
          wayPointIndex = 0;
        else
        {
          wayPointIndex++;        
        }        
        agent.SetDestination(patrolWayPoints[wayPointIndex].position);
    }
    
        
    // If near the next waypoint or there is no destination...
    // if(nav.remainingDistance < nav.stoppingDistance)
    // {
    //     // ... increment the timer.
    //     patrolTimer += Time.deltaTime;
        
    //     // If the timer exceeds the wait time...
    //     if(patrolTimer >= patrolWaitTime)
    //     {
    //         // ... increment the wayPointIndex.
    //         if(wayPointIndex == patrolWayPoints.Length - 1)
    //             wayPointIndex = 0;
    //         else
    //             wayPointIndex++;
            
    //         // Reset the timer.
    //         patrolTimer = 0;
    //     }
    // }
    // else
    // {
    //   patrolTimer = 0;
    //   nav.destination = patrolWayPoints[wayPointIndex].position;
    // }
        // If not near a destination, reset the timer.
        
    
    // Set the destination to the patrolWayPoint.
    
}