using UnityEngine;

public class EventSkip : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindFirstObjectByType<EventController1>().state = 3;
    }
}