#pragma strict
var projectile: Transform;
var speed = 20;
var pj : Transform;

function Start () {

}

function Update () {

  if(Input.GetButtonDown("Fire1"))
  {
    var clone : Transform;
    clone = Instantiate(projectile,transform.position,transform.rotation);
    Debug.Log(transform);
    var motor : CharacterMotor = pj.GetComponent(typeof(CharacterMotor)) as CharacterMotor;
    Debug.Log(motor.direction_facing);
    Physics.IgnoreCollision(clone.GetComponent.<Collider>(), GetComponent.<Collider>());
    switch(motor.direction_facing)
    {
      case 8:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.forward * 1500);
      break;
      case 2:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.back * 1500);
      break;
      case 6:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.right * 1500);
      break;
      case 4:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.left * 1500);
      break;

    }
    
  }
}