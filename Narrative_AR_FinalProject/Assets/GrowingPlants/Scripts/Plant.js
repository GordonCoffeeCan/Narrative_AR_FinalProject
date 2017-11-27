#pragma strict
#pragma downcast
import System.Collections.Generic;

var GizmoColor:Color=Color(255,0,0,255);
var GizmoSize:float=0.5;
var GrowSizeMin:Vector3;
var Stages:List.<PlantStageClass> = new List.<PlantStageClass>();
var Loop:boolean;
var LoopFrom:int;
private var StageId:int;
private var Plant:GameObject;
private var Mass:List.<Transform> = new List.<Transform>();
private var currentTime:float;

function Start () {
	transform.localScale=Vector3(GrowSizeMin.x,GrowSizeMin.y,GrowSizeMin.z);
	StageId=-1;
	NextStage();
}

function LateUpdate () {
	if(StageId>=0){
	Plant.transform.localScale=transform.localScale;
	 	if(currentTime>0f){
			currentTime-=Time.deltaTime;
			if(Stages[StageId].action==Stages[StageId].action.Grow){
				if(Stages[StageId].X) transform.localScale.x+=Stages[StageId].GrowSpeed*Time.deltaTime;
				if(Stages[StageId].Y) transform.localScale.y+=Stages[StageId].GrowSpeed*Time.deltaTime;
				if(Stages[StageId].Z) transform.localScale.z+=Stages[StageId].GrowSpeed*Time.deltaTime;
			}
			if(Stages[StageId].action==Stages[StageId].action.Decrease){
				if(Stages[StageId].X && transform.localScale.x>0.0) transform.localScale.x-=Stages[StageId].GrowSpeed*Time.deltaTime;
				if(Stages[StageId].Y && transform.localScale.y>0.0) transform.localScale.y-=Stages[StageId].GrowSpeed*Time.deltaTime;
				if(Stages[StageId].Z && transform.localScale.z>0.0) transform.localScale.z-=Stages[StageId].GrowSpeed*Time.deltaTime;
			}
			if(Stages[StageId].rotation==Stages[StageId].rotation.Rotate) transform.Rotate(Stages[StageId].RotationSpeed.x*Time.deltaTime, Stages[StageId].RotationSpeed.y*Time.deltaTime, Stages[StageId].RotationSpeed.z*Time.deltaTime);
			
		}else
		if(StageId+1 <Stages.Count) NextStage();
		else if(Loop){
		 StageId=LoopFrom-1;
		 NextStage();
		 }
	}
	if(Stages[StageId].rotation==Stages[StageId].rotation.Billboard)transform.rotation = Camera.main.transform.rotation;
}

function NextStage(){
	StageId++;
	currentTime=Stages[StageId].GrowTime;
	Plant=Instantiate(Stages[StageId].GrowGO, transform.position,transform.rotation);
	Plant.transform.parent=transform;
	Plant.transform.localScale=transform.localScale;
	yield WaitForSeconds(0.001);
	for (var child : Transform in transform) {
		Mass.Add(child);
		if(Mass.Count>1){
        Destroy(Mass[0].gameObject);
        Mass.RemoveAt(0);
        }
	}
}

function OnDrawGizmos () {
		Gizmos.color = GizmoColor;
		Gizmos.DrawCube (transform.position, Vector3(GizmoSize,GizmoSize,GizmoSize));
}