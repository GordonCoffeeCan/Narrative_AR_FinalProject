#pragma strict
#pragma downcast

function FixedUpdate(){
	for (var baby : Transform in transform){
 		baby.parent = null;
 	}
}