using UnityEngine;

public class Item : MonoBehaviour
{
	public int itemNum = 1;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		base.gameObject.transform.eulerAngles += new Vector3(0f, 5f, 0f);
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player1")
		{
			GameObject.Find("GameController").GetComponent<GameController>().getItem[itemNum] = true;
			Object.Destroy(base.gameObject);
		}
	}
}
