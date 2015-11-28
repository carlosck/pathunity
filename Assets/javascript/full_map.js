#pragma strict
var camera_to_show : GameObject;
var is_active: boolean;

function Start () {

}

function Update () {

  if(Input.GetButtonDown("map_full"))
  {
    if(is_active)
    {
      camera_to_show.SetActive(false);
      is_active= false;
    }
    else
    {
     camera_to_show.SetActive(true);
      is_active= true ;
    }
    
  }
}