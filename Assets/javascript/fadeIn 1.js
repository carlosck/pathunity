#pragma strict

var fadeTexture : Texture;
var startColor : Color = Color(0,0,0,1);
var endColor : Color = Color(0,0,0,1);
var duration : float = 0.8;
var activo : boolean = false;
internal var currentColor : Color;
internal var cambio : float ;
internal var cambiando = false;
internal var init_time : float ;

function Start()
{
  Destroy (gameObject, (duration * 2) + 1 );
  cambio = Time.time + duration ;
  init_time = Time.time;
}
function OnGUI()
{
  
    GUI.depth = -10 ;
    GUI.color = currentColor;
    GUI.DrawTexture( Rect(0,0,Screen.width,Screen.height), fadeTexture);  
    
  
}

function FixedUpdate()
{
  if(!cambiando )
  {
    currentColor = Color.Lerp(startColor, endColor,(Time.time-init_time)/duration ); 
    if(Time.time > cambio )
    {
      cambiando = true;
      var temp : Color = startColor;
      startColor = endColor;
      endColor = temp;
      Debug.Log("cambio");
      
    } 

  }
  else
  {
    currentColor = Color.Lerp(startColor, endColor,(Time.time-cambio)/duration );
  }
  
    
  
}