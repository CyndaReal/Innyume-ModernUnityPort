using System;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Vector3 camAngle;

    private GameObject camOBJ;

    public int location;

    public int frame;

    public float gravity = 0;

    private void Start()
    {
        camAngle = Vector3.zero;

        camOBJ = GameObject.Find("Main Camera");

        frame = 100;
        location = 0;

        Physics.gravity = new Vector3(0f, -98.100006f, 0f);

        camAngle = new Vector3(0f, 180f, 0f);
    }

    private void Update()
    {
        gravity -= 9.81f * Time.deltaTime;

        CharaMove();
        CamRot();

        if (base.gameObject.GetComponent<CharacterController>().isGrounded)
        {
            gravity = 0;
        }
    }

    private void FixedUpdate()
    {
        frame--;

        if (frame > 0)
        {
            GameObject.Find("Black").GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, (float)frame / 100f);
        }
    }

    private void CharaMove()
    {
        Vector3 anglesCurrent = camOBJ.transform.localEulerAngles;
        Vector3 vectorCurrent = new Vector3(Mathf.Cos((anglesCurrent.y - 270f) * ((float)Math.PI / 180f)) * -1f, 0f, Mathf.Sin((anglesCurrent.y - 270f) * ((float)Math.PI / 180f)));

        float axisMultiplier = 0.3f;

        float vertical = Input.GetAxis("Vertical") * axisMultiplier;
        float horizontal = Input.GetAxis("Horizontal") * axisMultiplier;

        Vector3 toMove = new Vector3(0, 0, 0);

        if (vertical != 0f)
        {
            toMove += new Vector3(vectorCurrent.x * vertical, 0f, vectorCurrent.z * vertical);
        }

        if (horizontal != 0f)
        {
            toMove += new Vector3(vectorCurrent.z * horizontal, 0f, (0f - vectorCurrent.x) * horizontal);
        }

        toMove.y = gravity;

        base.gameObject.GetComponent<CharacterController>().Move(toMove);
    }

    private void CamRot()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseMultiplier = -3f;

        camAngle += new Vector3(mouseY * mouseMultiplier, (0f - mouseX) * mouseMultiplier, 0f);
        camOBJ.transform.rotation = Quaternion.Euler(camAngle);

        if (camOBJ.transform.localEulerAngles.x > 60f && camOBJ.transform.localEulerAngles.x <= 180f)
        {
            camOBJ.transform.localEulerAngles = new Vector3(60f, camAngle.y, 0f);
            camAngle = new Vector3(60f, camAngle.y, camAngle.z);
        }

        if (camOBJ.transform.localEulerAngles.x >= 180f && camOBJ.transform.localEulerAngles.x < 300f)
        {
            camOBJ.transform.localEulerAngles = new Vector3(300f, camAngle.y, 0f);
            camAngle = new Vector3(300f, camAngle.y, camAngle.z);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "1F_Right")
        {
            location = 1;
        }

        if (col.gameObject.tag == "1F_Left")
        {
            location = 2;
        }

        if (col.gameObject.tag == "2F_Right")
        {
            location = 3;
        }

        if (col.gameObject.tag == "2F_Left")
        {
            location = 4;
        }

        if (col.gameObject.tag == "3F")
        {
            location = 5;
        }

        if (col.gameObject.tag == "EmerSteps")
        {
            location = 6;
        }
    }
}