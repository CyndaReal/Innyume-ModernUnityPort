using UnityEngine;

public class Inn_Eye2 : MonoBehaviour
{
    private GameObject innyume;

    public int innNum;

    private void Start()
    {
        innyume = GameObject.Find("innyume" + innNum);
    }

    private void FixedUpdate()
    {
        base.gameObject.transform.position = innyume.transform.position;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player1")
        {
            innyume.GetComponent<Innyume>().isDiscover = true;
            innyume.GetComponent<Innyume>().isDiscover2 = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player1")
        {
            innyume.GetComponent<Innyume>().isDiscover = false;
        }
    }
}