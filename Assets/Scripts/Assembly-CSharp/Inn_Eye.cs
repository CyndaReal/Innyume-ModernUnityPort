using UnityEngine;

public class Inn_Eye : MonoBehaviour
{
    private GameObject player;

    private int frame;

    public int innNum;

    private void Start()
    {
        player = GameObject.Find("Player1");

        Vector3 playerPos = player.transform.position;

        base.gameObject.transform.LookAt(new Vector3(playerPos.x, playerPos.y + 3f, playerPos.z));

        frame = 0;
    }

    private void FixedUpdate()
    {
        frame++;

        float movementSpeed = 10f;
        base.gameObject.transform.position += base.gameObject.transform.TransformDirection(Vector3.forward) * movementSpeed;

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