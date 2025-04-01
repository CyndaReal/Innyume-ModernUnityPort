using UnityEngine;

public class TitleMes : MonoBehaviour
{
	public int mesNum;

	public Material[] mesMAT = new Material[2];

	private GameObject lightCOM;

	private void Start()
	{
		lightCOM = GameObject.Find("LightBlock.003");
	}

	private void FixedUpdate()
	{
		if (lightCOM.GetComponent<TitleScript>().state == 2)
		{
			base.gameObject.GetComponent<Renderer>().material = mesMAT[0];
		}
	}

	private void OnMouseOver()
	{
		if (lightCOM.GetComponent<TitleScript>().state == 1)
		{
			base.gameObject.GetComponent<Renderer>().material = mesMAT[1];
		}
	}

	private void OnMouseExit()
	{
		if (lightCOM.GetComponent<TitleScript>().state == 1)
		{
			base.gameObject.GetComponent<Renderer>().material = mesMAT[0];
		}
	}

	private void OnMouseDown()
	{
		if (lightCOM.GetComponent<TitleScript>().state == 1)
		{
			lightCOM.GetComponent<TitleScript>().state = mesNum + 2;
		}
	}
}
