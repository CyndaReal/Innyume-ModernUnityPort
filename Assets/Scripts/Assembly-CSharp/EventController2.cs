using UnityEngine;

public class EventController2 : MonoBehaviour
{
	public GameObject earthOBJ;

	public GameObject explosionPrefab;

	public GameObject audioPrefab;

	public GameObject innyumeOBJ;

	public GameObject SZKOBJ;

	public GameObject innMesOBJ;

	public Material[] SZKMAT = new Material[4];

	private int frame;

	private int frame2;

	private float rotate;

	private void Start()
	{
		frame = 0;
		frame2 = 0;
		rotate = 0f;
		Cursor.visible = true;
	}

	private void FixedUpdate()
	{
		frame++;
		if (frame < 30)
		{
			earthOBJ.transform.localScale -= new Vector3(0.8f, 0.8f, 0f);
		}
		if (frame >= 30 && frame < 180)
		{
			rotate += 0.8f;
			earthOBJ.transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
			earthOBJ.transform.eulerAngles = new Vector3(0f, 0f, rotate);
		}
		if (frame >= 180 && frame < 240)
		{
			rotate += 5f;
			earthOBJ.transform.localScale -= new Vector3(0.08f, 0.08f, 0f);
			earthOBJ.transform.eulerAngles = new Vector3(0f, 0f, rotate);
			if (earthOBJ.transform.localScale.x <= 0f)
			{
				earthOBJ.transform.localScale = new Vector3(0f, 0f, 1f);
			}
		}
		if (frame == 30)
		{
			Object.Instantiate(explosionPrefab, new Vector3(-0.6f, 0.14f, -1f), Quaternion.identity);
		}
		if (frame == 40)
		{
			Object.Instantiate(explosionPrefab, new Vector3(-1.2f, 1.6f, -1.1f), Quaternion.identity);
		}
		if (frame == 60)
		{
			Object.Instantiate(explosionPrefab, new Vector3(-1.6f, -1.6f, -1.2f), Quaternion.identity);
		}
		if (frame == 70)
		{
			Object.Instantiate(explosionPrefab, new Vector3(1.6f, 0.6f, -1.3f), Quaternion.identity);
		}
		if (frame == 90)
		{
			Object.Instantiate(explosionPrefab, new Vector3(0.9f, -1.2f, -1.4f), Quaternion.identity);
		}
		innyumeOBJ.transform.position += new Vector3(-0.01f, 0f, 0f);
		innyumeOBJ.transform.eulerAngles += new Vector3(0f, 0f, 10f);
		innyumeOBJ.transform.localScale += new Vector3(0.01f, 0.01f, 0f);
		innMesOBJ.transform.position += new Vector3(-0.01f, 0.005f, 0f);
		SZKOBJ.transform.position += new Vector3(0.01f, 0f, 0f);
		SZKOBJ.transform.eulerAngles += new Vector3(0f, 0f, -5f);
		SZKOBJ.transform.localScale += new Vector3(0.01f, 0.01f, 0f);
		int num = 3;
		frame2++;
		if (frame2 >= num * 0 && frame2 < num * 1)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[0];
		}
		if (frame2 >= num * 1 && frame2 < num * 2)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[1];
		}
		if (frame2 >= num * 2 && frame2 < num * 3)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[2];
		}
		if (frame2 >= num * 3 && frame2 < num * 4)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[3];
		}
		if (frame2 >= num * 4 && frame2 < num * 5)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[2];
		}
		if (frame2 >= num * 5 && frame2 < num * 6)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[1];
		}
		if (frame2 >= num * 6)
		{
			SZKOBJ.GetComponentInChildren<Renderer>().material = SZKMAT[0];
			frame2 = 0;
		}
		if (frame == 120)
		{
			Object.Instantiate(audioPrefab, new Vector3(0f, 0f, -10f), Quaternion.identity);
		}
		if (frame == 240)
		{
			GameObject.Find("Main Camera").transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		if (frame == 242)
		{
			Object.Instantiate(explosionPrefab, new Vector3(0f, 0f, -10.5f), Quaternion.Euler(0f, 180f, 0f));
			Object.Instantiate(explosionPrefab, new Vector3(0f, 0f, -10.5f), Quaternion.Euler(0f, 180f, 0f));
			Object.Instantiate(explosionPrefab, new Vector3(0f, 0f, -10.5f), Quaternion.Euler(0f, 180f, 0f));
			Object.Instantiate(explosionPrefab, new Vector3(0f, 0f, -10.5f), Quaternion.Euler(0f, 180f, 0f));
		}
		if (frame == 373)
		{
			GameObject.Find("Main Camera").transform.position += new Vector3(100f, 0f, 0f);
		}
		if (frame == 640)
		{
			Application.LoadLevel("Title");
		}
	}
}
