#pragma strict
var anim : Animator;
var abierto : boolean = false;
var cofre: GameObject;
//var myOtherScript: ScriptName;

function OnTriggerEnter (pj : Collider)
{
  if(pj.collider.tag == "Player" && !abierto)
  {
   
    anim = cofre.GetComponent.<Animator>();
   
    anim.SetInteger("Direction", 1);
    Debug.Log ("contiene a 1");
   
    enable_controlls(false);  
  
    yield WaitForSeconds (1.5);
    abierto = true;
    enable_controlls(true);
        
  }
}

function enable_controlls(enable: boolean)
{
  
  var objbScript : FPSInputController = gameObject.FindWithTag("Player").GetComponent(typeof(FPSInputController)) as FPSInputController;
  objbScript.setActives(enable);
  // objbScript.enabled = enable;
  if(!enable)
  {
    yield WaitForSeconds(0.8);
    objbScript.setState();
  }
  
}