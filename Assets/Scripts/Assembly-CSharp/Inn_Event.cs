using UnityEngine;

public class Inn_Event : MonoBehaviour
{
	public GameObject innEvePrefab;

	private GameObject aaa;

	private int state;

	private void Start()
	{
		state = 0;
		aaa = null;
	}

	private void FixedUpdate()
	{
		if (state == 1)
		{
			aaa = Object.Instantiate(innEvePrefab, new Vector3(-23f, 0f, -84f), Quaternion.Euler(0f, 180f, 0f)) as GameObject;
			state = 2;
		}
		if (aaa != null)
		{
			aaa.GetComponentInChildren<AudioSource>().volume -= 0.01f;
			aaa.transform.position += new Vector3(0f, 0f, 0.5f);
			if (aaa.GetComponentInChildren<AudioSource>().volume <= 0f)
			{
				Object.Destroy(aaa);
			}
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player1" && state == 0)
		{
			state = 1;
		}
	}
}
