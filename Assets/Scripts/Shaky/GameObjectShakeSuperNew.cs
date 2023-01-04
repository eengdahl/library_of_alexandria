using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectShakeSuperNew : MonoBehaviour {
	//More or less stolen script
	Vector3 objectInitialPosition;
	public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
	public GameObject choosenObject;

	public void ShakeIt()
	{
		objectInitialPosition = choosenObject.transform.localPosition;
		InvokeRepeating ("StartObjectShaking", 0f, 0.005f);
		Invoke ("StopObjectShaking", shakeTime);
	}

	void StartObjectShaking()
	{
		float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		Vector3 cameraIntermadiatePosition = choosenObject.transform.localPosition;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		choosenObject.transform.localPosition = cameraIntermadiatePosition;
	}

	void StopObjectShaking()
	{
		CancelInvoke ("StartObjectShaking");
		choosenObject.transform.localPosition = objectInitialPosition;
	}

}
