#pragma strict
var anim : Animator;
var objetodelcofre : GameObject;
var anim_objeto_cofre : Animator;
var abierto : boolean = false;
var cofre: GameObject;
var laluz_container: GameObject;
//var myOtherScript: ScriptName;

function OnTriggerEnter (pj : Collider)
{
  if(pj.GetComponent.<Collider>().tag == "Player" && !abierto)
  {
   
    anim = cofre.GetComponent.<Animator>();
   
    anim.SetInteger("Direction", 1);
    Debug.Log ("contiene a 1");
    var laluz : Light;
    anim_objeto_cofre = objetodelcofre.GetComponent.<Animator>();
    anim_objeto_cofre.SetInteger("activo", 1);
    enable_controlls(false);  
    laluz=laluz_container.GetComponent.<Light>();
    laluz.enabled = true;
    yield WaitForSeconds (3.5);
    abierto = true;
    enable_controlls(true);
    laluz.enabled = false;
        
  }
}

function enable_controlls(enable: boolean)
{
  
  var objbScript : FPSInputController = gameObject.FindWithTag("Player").GetComponent(typeof(FPSInputController)) as FPSInputController;
  // objbScript.setActives(enable);
  // objbScript.enabled = enable;
  if(!enable)
  {
    yield WaitForSeconds(0.8);
    // objbScript.setState();
  }
  
}