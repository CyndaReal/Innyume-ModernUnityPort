using UnityEngine;

public class TitleScript : MonoBehaviour
{
	public Material[] lightMAT = new Material[2];

	private int frame;

	public int state;

	public AudioClip bi;

	private GameObject black;

	private void Start()
	{
		frame = 0;
		state = 0;
		black = GameObject.Find("Black");
		Cursor.visible = true;
	}

	private void FixedUpdate()
	{
		frame++;
		if (frame == 58)
		{
			base.gameObject.GetComponent<AudioSource>().PlayOneShot(bi);
		}
		if (frame == 60)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[1];
			base.gameObject.GetComponent<Light>().range = 17.5f;
		}
		if (frame >= 61 && frame < 80)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[0];
			base.gameObject.GetComponent<Light>().range = 0f;
			base.gameObject.GetComponent<AudioSource>().Stop();
			frame = Random.Range(0, 56);
		}
		if (frame == 101)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[1];
			base.gameObject.GetComponent<Light>().range = 50f;
			base.gameObject.GetComponent<Light>().intensity = 10f;
			base.gameObject.GetComponent<AudioSource>().PlayOneShot(bi);
		}
		if (frame == 102)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[1];
			base.gameObject.GetComponent<Light>().range = 15f;
			base.gameObject.GetComponent<Light>().intensity = 8f;
		}
		if (frame == 103)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[0];
			base.gameObject.GetComponent<Light>().range = 10f;
			base.gameObject.GetComponent<Light>().intensity = 6f;
		}
		if (frame == 104)
		{
			base.gameObject.GetComponent<Renderer>().material = lightMAT[0];
			base.gameObject.GetComponent<Light>().range = 0f;
			base.gameObject.GetComponent<Light>().intensity = 5f;
		}
		if (frame == 107)
		{
			base.gameObject.GetComponent<AudioSource>().Stop();
		}
		if (frame >= 120)
		{
			frame = Random.Range(0, 56);
		}
		if (state == 0)
		{
			black.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, -0.01f);
			if (black.GetComponent<Renderer>().material.color.a <= 0f)
			{
				black.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, 0f);
				state = 1;
			}
		}
		if (state == 2)
		{
			black.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, 0.01f);
			if (black.GetComponent<Renderer>().material.color.a >= 1f)
			{
				Application.LoadLevel("Event");
			}
		}
		if (state == 3)
		{
			Application.Quit();
		}
	}

	private void OnMouseDown()
	{
		if (frame < 100)
		{
			frame = 100;
		}
	}
}
