#pragma strict

function Start () {
	var cupoer : Collider[] =  GameObject.FindGameObjectWithTag("cuerpo").GetComponents.<Collider>();
	var cols : Collider[] = GameObject.FindGameObjectWithTag("Player").GetComponents.<Collider>();
    Physics.IgnoreCollision(cols[0], cupoer[0]);
    
    for (var C : Collider in cols)
    {
        Physics.IgnoreCollision(C, collider);
    }

}

function Update () {

}