using UnityEngine;

public class EventSkip : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
		GameObject.Find("EventController").GetComponent<EventController1>().state = 3;
	}
}
