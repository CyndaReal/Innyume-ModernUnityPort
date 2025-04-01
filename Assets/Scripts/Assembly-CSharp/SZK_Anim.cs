using UnityEngine;

public class SZK_Anim : MonoBehaviour
{
	public Material[] mat = new Material[4];

	private int frame;

	private void Start()
	{
		frame = 0;
	}

	private void FixedUpdate()
	{
		frame++;
		int num = 3;
		if (frame >= num * 0 && frame < num * 1)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[0];
		}
		if (frame >= num * 1 && frame < num * 2)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[1];
		}
		if (frame >= num * 2 && frame < num * 3)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[2];
		}
		if (frame >= num * 3 && frame < num * 4)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[3];
		}
		if (frame >= num * 4 && frame < num * 5)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[2];
		}
		if (frame >= num * 5 && frame < num * 6)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[1];
		}
		if (frame >= num * 6)
		{
			base.gameObject.GetComponent<Renderer>().material = mat[0];
			frame = 0;
		}
	}
}
