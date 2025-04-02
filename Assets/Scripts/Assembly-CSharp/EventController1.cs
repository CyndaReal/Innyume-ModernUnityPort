using UnityEngine;
using UnityEngine.SceneManagement;

public class EventController1 : MonoBehaviour
{
    public GameObject innyumeOBJ;

    public GameObject textOBJ;

    public GameObject BGOBJ1;

    public GameObject BGOBJ2;

    public GameObject BGOInnyume;

    public Material[] textMat = new Material[4];

    public int state;

    private void Start()
    {
        state = 0;
        textOBJ.GetComponent<Renderer>().material = textMat[0];
    }

    private void FixedUpdate()
    {
        innyumeOBJ.transform.position += new Vector3(-0.01f, 0f, 0f);

        if (innyumeOBJ.transform.position.x <= 4.02f && state == 0)
        {
            textOBJ.GetComponent<Renderer>().material = textMat[1];

            state = 1;

            innyumeOBJ.transform.position = new Vector3(5.11f, innyumeOBJ.transform.position.y, innyumeOBJ.transform.position.z);
        }

        if (innyumeOBJ.transform.position.x <= 1.79f && state == 1)
        {
            textOBJ.GetComponent<Renderer>().material = textMat[2];

            state = 2;

            innyumeOBJ.transform.position = new Vector3(2.3f, innyumeOBJ.transform.position.y, innyumeOBJ.transform.position.z);
        }

        if (innyumeOBJ.transform.position.x <= -1.52f && state == 2)
        {
            textOBJ.GetComponent<Renderer>().material = textMat[3];

            state = 3;
        }

        if (state == 3)
        {
            textOBJ.GetComponent<Renderer>().material = textMat[3];

            GetComponent<AudioSource>().Stop();

            BGOInnyume.transform.position = new Vector3(0f, 0f, -4.1f);

            BGOBJ1.transform.position = new Vector3(0f, 0f, -4f);
            BGOBJ2.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);

            state = 4;
        }

        if (state == 4)
        {
            BGOBJ2.GetComponent<Renderer>().material.color += new Color(0f, 0f, 0f, 0.01f);

            if (BGOBJ2.GetComponent<Renderer>().material.color.a >= 1f)
            {
                SceneManager.LoadScene("Game01");
            }
        }
    }
}