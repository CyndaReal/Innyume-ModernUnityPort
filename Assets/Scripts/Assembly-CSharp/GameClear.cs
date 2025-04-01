using UnityEngine;

public class GameClear : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player1")
		{
			GameObject.Find("Black").GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 1f);
			Application.LoadLevel("GameClear");
		}
	}
}
