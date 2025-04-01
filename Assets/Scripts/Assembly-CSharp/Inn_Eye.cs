using UnityEngine;

public class Inn_Eye : MonoBehaviour
{
	private GameObject player;

	private int frame;

	public int innNum;

	private void Start()
	{
		player = GameObject.Find("Player1");
		Vector3 position = player.transform.position;
		base.gameObject.transform.LookAt(new Vector3(position.x, position.y + 3f, position.z));
		frame = 0;
	}

	private void FixedUpdate()
	{
		frame++;
		float num = 10f;
		base.gameObject.transform.position += base.gameObject.transform.TransformDirection(Vector3.forward) * num;
		if (frame >= 6)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void InnyumeNum(int a)
	{
		innNum = a;
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player1")
		{
			Object.Destroy(base.gameObject);
		}
		if (col.gameObject.tag == "Stage")
		{
			Object.Destroy(base.gameObject);
		}
		if (col.gameObject.name == "Player1")
		{
			GameObject.Find("innyume" + innNum).GetComponent<Innyume>().isDiscover = true;
		}
	}
}
