
var agent : NavMeshAgent;
var player : GameObject;
var anim : Animator;
var facing_left : boolean=false; 
function Awake()
{
  agent = GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
  anim = transform.Find("animator_container").GetComponent(typeof(Animator)) as Animator;
}

function Update()
{
   agent.SetDestination(player.transform.position);
   // Debug.Log(agent.velocity);
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
