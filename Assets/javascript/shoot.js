#pragma strict
var projectile: Transform;
var speed = 1500;
var pj : Transform;

function Start () {

}

function Update () {

  if(Input.GetButtonDown("Fire1"))
  {
    var clone : Transform;
    clone = Instantiate(projectile,transform.position,transform.rotation);
    Debug.Log(transform);
    var motor : CharacterMotor = transform.GetComponent(typeof(CharacterMotor)) as CharacterMotor;
    Debug.Log(motor.direction_facing);
    Physics.IgnoreCollision(clone.GetComponent.<Collider>(), GetComponent.<Collider>());
    switch(motor.direction_facing)
    {
      case 8:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.forward * speed);
      break;
      case 2:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.back * speed);
      break;
      case 6:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.right * speed);
      break;
      case 4:  clone.GetComponent.<Rigidbody>().AddForce(Vector3.left * speed);
      break;

    }
    
  }
}