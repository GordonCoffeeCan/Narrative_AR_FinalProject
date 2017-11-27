#pragma strict

public class PlantStageClass{
public enum Action{Grow,Decrease};
public enum Rotation{None,Rotate,Billboard};
	var GrowTime:float;
	var GrowGO:GameObject;
	var GrowSpeed:float;
	var X:boolean=true;
	var Y:boolean=true;
	var Z:boolean=true;
	var action:Action;
	var rotation:Rotation;
	var RotationSpeed:Vector3;
}