using UnityEngine;

public class Face_LookAt : MonoBehaviour
{
    private GameObject camOBJ;

    private void Start()
    {
        camOBJ = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        base.gameObject.transform.rotation = Quaternion.Euler(0f - camOBJ.transform.eulerAngles.x, 180f + camOBJ.transform.eulerAngles.y, 0f - camOBJ.transform.eulerAngles.z);
    }
}