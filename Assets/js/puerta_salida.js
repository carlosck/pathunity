#pragma strict

var locacion1 : Transform;
var fadeObj : Transform;
//var myOtherScript: ScriptName;
function OnTriggerEnter (pj : Collider)
{
  if(pj.collider.tag == "Player")
  {
    //var myOtherScript = fadeIn.GetComponentInChildren(ScriptName);        
    

    //var objaScript : fadeIn = fadeObj.GetComponent(typeof(fadeIn)) as fadeIn;
    
    // objaScript.useFixedUpdate=false;
    

    //var pos : Vector3 (0,0,0); // this is where the Cube will appear when it's instantiated
    //var rot : Quaternion = Quaternion.identity; // Quaternion.identity essentially means "no rotation"
    enable_controlls(false);
    Instantiate(fadeObj, Vector3 (0, 0, 0), Quaternion.identity); // The Instantiate command takes a GameObject, a Vector3 for position and a Quaternion for rotation.
    
    yield WaitForSeconds (0.8);
    pj.transform.position = locacion1.position;
    
    yield WaitForSeconds (0.8);
    enable_controlls(true);
    
    //Time.timeScale = 0.0 ;
        
  }
}

function enable_controlls(enable: boolean)
{
  // var objaScript : CharacterMotor = gameObject.FindWithTag("Player").GetComponent(typeof(CharacterMotor)) as CharacterMotor;
  //  objaScript.canControl = enable;

  var objbScript : FPSInputController = gameObject.FindWithTag("Player").GetComponent(typeof(FPSInputController)) as FPSInputController;
  objbScript.setActives(enable);
  // objbScript.enabled = enable;
  if(!enable)
  {
    yield WaitForSeconds(0.8);
    objbScript.setState();
  }
  
}