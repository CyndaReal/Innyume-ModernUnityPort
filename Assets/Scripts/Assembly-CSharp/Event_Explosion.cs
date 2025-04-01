using UnityEngine;

public class Event_Explosion : MonoBehaviour
{
	private int frame;

	public Material[] explosionMAT = new Material[132];

	private void Start()
	{
		frame = 0;
	}

	private void FixedUpdate()
	{
		base.gameObject.GetComponent<Renderer>().material = explosionMAT[frame];
		frame++;
		if (frame >= 132)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
