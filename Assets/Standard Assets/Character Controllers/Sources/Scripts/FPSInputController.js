private var motor : CharacterMotor;
var anim : Animator;
var facing_left : boolean = false ;
var Mainactive : boolean = true;
// Use this for initialization
function start()
{

	Debug.Log ("Hello");
	Mainactive= true;
}
function Awake () {
	motor = GetComponent(CharacterMotor);
	anim = GameObject.FindGameObjectWithTag("animacion").GetComponent.<Animator>();
	Mainactive= true;
	// Debug.Log ("Hello");
	// anim.SetInteger("Direction", 2);
	
}

// Update is called once per frame
function Update () {
	if(!Mainactive)
	{
		return false;
	}
	var vertical = Input.GetAxis("Vertical");
	var horizontal = Input.GetAxis("Horizontal");
	//GameObject.FindGameObjectWithTag("animacion").transform.localScale = Vector3(1,1,1);
	if (vertical > 0)
	{
	    anim.SetInteger("Direction", 2);
	}
	else if (vertical < 0)
	{
	    anim.SetInteger("Direction", 4);
	}
	else if (horizontal > 0)
	{
	    anim.SetInteger("Direction", 3);
	    facing_left = true;
	}
	else if (horizontal < 0)
	{
	    anim.SetInteger("Direction", 1);
	    facing_left = true;
	}
	//Debug.Log ("Hello a");

	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	else
	{
		// if (facing_left)
		// 	GameObject.FindGameObjectWithTag("animacion").transform.localScale = Vector3(-1,1,1);
		anim.SetInteger("Direction", 0);
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}
function setState(){
  
  	anim.SetInteger("Direction", 0);
  
  
}
function setActives(active_ : boolean){
  Mainactive = active_;
  motor.canControl = active_ ;  
  
}
// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
