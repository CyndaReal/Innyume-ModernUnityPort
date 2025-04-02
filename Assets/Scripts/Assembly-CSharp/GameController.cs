using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool[] getItem = new bool[5];

    public GameObject[] getItemPrefab = new GameObject[5];

    private int[] frame = new int[5];

    public GameObject innEventPrefab;

    public GameObject innyumePrefab;

    public GameObject zetInnyumePrefab;

    private bool isAdd_Ga;

    private bool isAdd_Ri;

    private bool isAdd_All;

    private GameObject[] wallOBJ = new GameObject[2];

    public Material colorMAT;

    private void Start()
    {
        wallOBJ[0] = GameObject.Find("Wall");
        wallOBJ[1] = GameObject.Find("Wall_Collision");

        for (int i = 0; i < 5; i++)
        {
            frame[i] = 0;
        }

        isAdd_Ga = false;
        isAdd_Ri = false;
        isAdd_All = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void FixedUpdate()
    {
        float num = -6f;
        int num2 = 0;

        while (num2 < 5)
        {
            if (getItem[num2])
            {
                frame[num2]++;

                if (frame[num2] == 1)
                {
                    Object.Instantiate(getItemPrefab[num2], new Vector3(num, 4f, 10f), Quaternion.Euler(270f, 180f, 0f));
                }

                if (frame[num2] >= 10000)
                {
                    frame[num2] = 10;
                }
            }

            num2++;

            num += 3f;
        }

        if (getItem[4] && !isAdd_Ga)
        {
            GameObject innyumeOne = Object.Instantiate(innyumePrefab, new Vector3(-145f, 20f, -80f), Quaternion.identity);
            innyumeOne.name = "innyume1";
            isAdd_Ga = true;
        }

        if (getItem[0] && !isAdd_Ri)
        {
            GameObject innyumeTwo = Object.Instantiate(innyumePrefab, new Vector3(105f, 20f, -80f), Quaternion.identity);
            innyumeTwo.name = "innyume2";
            isAdd_Ri = true;
        }

        if (getItem[0] && getItem[1] && getItem[2] && getItem[3] && getItem[4])
        {
            if (!isAdd_All)
            {
                Object.Instantiate(zetInnyumePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                Object.Instantiate(zetInnyumePrefab, new Vector3(85f, 20f, -80f), Quaternion.identity);
                Object.Instantiate(zetInnyumePrefab, new Vector3(-65f, 0f, -135f), Quaternion.identity);
                Object.Instantiate(zetInnyumePrefab, new Vector3(85f, 40f, -15f), Quaternion.identity);
                Object.Instantiate(zetInnyumePrefab, new Vector3(35f, 40f, -85f), Quaternion.identity);
                Object.Instantiate(zetInnyumePrefab, new Vector3(-95f, 20f, -25f), Quaternion.identity);

                Object.Destroy(GameObject.Find("innyume0"));
                Object.Destroy(GameObject.Find("InnyumeEye0"));
                Object.Destroy(GameObject.Find("innyume1"));
                Object.Destroy(GameObject.Find("InnyumeEye1"));
                Object.Destroy(GameObject.Find("innyume2"));
                Object.Destroy(GameObject.Find("InnyumeEye2"));

                isAdd_All = true;
            }

            for (int i = 0; i < 5; i++)
            {
                GameObject itemClone = GameObject.Find("Item_" + (i + 1) + "(Clone)");
                itemClone.GetComponent<Renderer>().material = colorMAT;
                Object.Destroy(itemClone.GetComponent<Light>());
            }

            Object.Destroy(wallOBJ[0]);
            Object.Destroy(wallOBJ[1]);
        }
    }
}