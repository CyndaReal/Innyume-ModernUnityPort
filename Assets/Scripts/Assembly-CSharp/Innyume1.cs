using UnityEngine;

public class Innyume1 : MonoBehaviour
{
	private GameObject player;

	private NavMeshAgent agent;

	private int frame;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.Find("Player1");
		frame = 0;
	}

	private void FixedUpdate()
	{
		agent.SetDestination(player.transform.position);
		frame++;
		if (frame >= 1800)
		{
			agent.speed = 40f;
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player1")
		{
			GameObject.Find("Black").GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 1f);
			Application.LoadLevel("GameOver");
		}
	}
}
