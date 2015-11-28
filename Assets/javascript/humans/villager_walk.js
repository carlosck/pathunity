#pragma strict
public var walk_speed : float = 2f; 
public var patrolWayPoints : Transform[];
public var patrolWaitTime : float = 5f;
var anim : Animator;
var facing_left : boolean=false;

private var agent : NavMeshAgent;
private var patrolTimer : float;
private var wayPointIndex : int;

function Awake () {
 agent = GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
 anim = transform.Find("animator_container").GetComponent(typeof(Animator)) as Animator;

 agent.SetDestination(patrolWayPoints[wayPointIndex].position);
 // agent.destination = patrolWayPoints[wayPointIndex].position;
}

function Update () {
 Patrolling();
 var velocity : Vector3 = agent.velocity;
 if(Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
 {
  if(velocity.x > 0 )
  {
   anim.SetInteger("Direction", 6);
      facing_left = false;
  }
  if(velocity.x < 0 )
  {
   anim.SetInteger("Direction", 4);
      facing_left = true;
  }
 }
 else
 {
  if(velocity.z > 0 )
  {
   anim.SetInteger("Direction", 8);
      facing_left = true;
  }
  if(velocity.z < 0 )
  {
   anim.SetInteger("Direction", 2);
      facing_left = true;
  } 
 }
 
 
 if(velocity.z==0 && velocity.x==0)
 {
  if(facing_left)
    anim.SetInteger("Direction", 5);
  else
    anim.SetInteger("Direction", 1);

 }
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