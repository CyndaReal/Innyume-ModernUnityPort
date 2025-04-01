using UnityEngine;

public class aaa : MonoBehaviour
{
	public Material[] mesMAT = new Material[2];

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseOver()
	{
		base.gameObject.GetComponent<Renderer>().material = mesMAT[1];
	}

	private void OnMouseExit()
	{
		base.gameObject.GetComponent<Renderer>().material = mesMAT[0];
	}
}
