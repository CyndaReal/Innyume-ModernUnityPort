using System;
using UnityEngine;

public class Player1 : MonoBehaviour
{
	private Vector3 camAngle;

	private GameObject camOBJ;

	public int location;

	public int frame;

	private void Start()
	{
		camAngle = Vector3.zero;
		camOBJ = GameObject.Find("Main Camera");
		frame = 100;
		location = 0;
		Physics.gravity = new Vector3(0f, -98.100006f, 0f);
		camAngle = new Vector3(0f, 180f, 0f);
	}

	private void FixedUpdate()
	{
		CharaMove();
		CamRot();
		frame--;
		if (frame > 0)
		{
			GameObject.Find("Black").GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, (float)frame / 100f);
		}
	}

	private void CharaMove()
	{
		Vector3 localEulerAngles = camOBJ.transform.localEulerAngles;
		Vector3 vector = new Vector3(Mathf.Cos((localEulerAngles.y - 270f) * ((float)Math.PI / 180f)) * -1f, 0f, Mathf.Sin((localEulerAngles.y - 270f) * ((float)Math.PI / 180f)));
		float num = 0.3f;
		float num2 = Input.GetAxis("Vertical") * num;
		if (num2 != 0f)
		{
			base.gameObject.GetComponent<Rigidbody>().transform.position += new Vector3(vector.x * num2, 0f, vector.z * num2);
		}
		float num3 = Input.GetAxis("Horizontal") * num;
		if (num3 != 0f)
		{
			base.gameObject.GetComponent<Rigidbody>().transform.position += new Vector3(vector.z * num3, 0f, (0f - vector.x) * num3);
		}
	}

	private void CamRot()
	{
		float axis = Input.GetAxis("Mouse X");
		float axis2 = Input.GetAxis("Mouse Y");
		float num = -3f;
		camAngle += new Vector3(axis2 * num, (0f - axis) * num, 0f);
		camOBJ.transform.rotation = Quaternion.Euler(camAngle);
		if (camOBJ.transform.localEulerAngles.x > 60f && camOBJ.transform.localEulerAngles.x <= 180f)
		{
			camOBJ.transform.localEulerAngles = new Vector3(60f, camAngle.y, 0f);
			camAngle = new Vector3(60f, camAngle.y, camAngle.z);
		}
		if (camOBJ.transform.localEulerAngles.x >= 180f && camOBJ.transform.localEulerAngles.x < 300f)
		{
			camOBJ.transform.localEulerAngles = new Vector3(300f, camAngle.y, 0f);
			camAngle = new Vector3(300f, camAngle.y, camAngle.z);
		}
	}

	private void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "1F_Right")
		{
			location = 1;
		}
		if (col.gameObject.tag == "1F_Left")
		{
			location = 2;
		}
		if (col.gameObject.tag == "2F_Right")
		{
			location = 3;
		}
		if (col.gameObject.tag == "2F_Left")
		{
			location = 4;
		}
		if (col.gameObject.tag == "3F")
		{
			location = 5;
		}
		if (col.gameObject.tag == "EmerSteps")
		{
			location = 6;
		}
	}
}
