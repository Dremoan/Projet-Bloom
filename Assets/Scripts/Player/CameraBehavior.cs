using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public Transform target;
	Vector3 velocity = Vector3.zero;


	public float smoothTime = 0.125f;
	public Vector3 offset;

	public bool YMaxEnabled = false;
	public float YMaxValue = 0;

	public bool YMinEnabled = false;
	public float YMinValue = 0;

	public bool XMaxEnabled = false;
	public float XMaxValue = 0;

	public bool XMinEnabled = false;
	public float XMinValue = 0;

	void FixedUpdate()
	{
		Vector3 targetPos = target.position;
		Vector3 transformPos = transform.position;
		targetPos.z = transform.position.z;
		transformPos.z = -10;

		if(YMinEnabled && YMaxEnabled)
		{
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, YMaxValue);
		}
		else if(YMinEnabled)
		{
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, target.position.y);
		}
		else if(YMaxEnabled)
		{
			targetPos.y = Mathf.Clamp (target.position.y, target.position.y, YMaxValue);
		}

		if(XMinEnabled && XMaxEnabled)
		{
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, XMaxValue);
		}
		else if(XMinEnabled)
		{
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, target.position.x);
		}
		else if(XMaxEnabled)
		{
			targetPos.x = Mathf.Clamp (target.position.x, target.position.x, XMaxValue);
		}


		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);



	}
}
