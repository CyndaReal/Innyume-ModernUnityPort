using UnityEngine;

public class GameOverCam : MonoBehaviour
{
	public float speed = 0.1f;

	private int frame;

	private GameObject black;

	private bool isClick;

	private void Start()
	{
		frame = 0;
		black = GameObject.Find("Black");
		isClick = false;
	}

	private void FixedUpdate()
	{
		frame++;
		base.gameObject.transform.eulerAngles += new Vector3(0f, speed, 0f);
		if (frame <= 120)
		{
			black.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, -0.01f);
		}
		else
		{
			if (frame < 840)
			{
				return;
			}
			isClick = true;
			if (isClick)
			{
				black.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, 0.01f);
				if (black.GetComponent<Renderer>().material.color.a >= 1f)
				{
					Application.LoadLevel("Title");
				}
			}
		}
	}
}
