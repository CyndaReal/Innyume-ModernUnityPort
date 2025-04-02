using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Innyume : MonoBehaviour
{
    public bool isDiscover;

    public bool isDiscover2;

    private int frame;

    public int beforePos;

    public int aimPos;

    private GameObject[] AIPos = new GameObject[77];

    private GameObject player;

    public GameObject eye;

    private NavMeshAgent agent;

    public GameObject eyePrefab;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        for (int i = 1; i < 77; i++)
        {
            AIPos[i] = GameObject.Find("AI" + i);
        }

        player = GameObject.Find("Player1");

        frame = 0;

        isDiscover = false;
        isDiscover2 = false;

        beforePos = 1;

        NearTarget();

        GameObject eye = Object.Instantiate(eyePrefab, base.gameObject.transform.position, Quaternion.identity);

        eye.name = "InnyumeEye" + base.gameObject.name.Remove(0, 7);
        eye.GetComponent<Inn_Eye2>().innNum = int.Parse(base.gameObject.name.Remove(0, 7));
    }

    private void FixedUpdate()
    {
        frame++;

        for (int i = 1; i < AIPos.Length; i++)
        {
            IsAIPosSuc(i);
        }

        Vector3 currentPosition = base.gameObject.transform.position;
        Vector3 targetPosition = AIPos[aimPos].transform.position;

        if (frame == 9)
        {
            base.gameObject.GetComponent<AudioSource>().volume = 1f;
        }

        if (frame >= 20)
        {
            frame = 10;
        }

        if (isDiscover)
        {
            targetPosition = player.transform.position;
        }

        agent.SetDestination(targetPosition);

        float atanPos = Mathf.Atan2(currentPosition.z - targetPosition.z, currentPosition.x - targetPosition.x) * 57.29578f;
        base.gameObject.transform.eulerAngles = new Vector3(0f, 0f - atanPos + 90f, 0f);

        if (!isDiscover && isDiscover2)
        {
            NearTarget();
            isDiscover2 = false;
        }

        if (isDiscover && !isDiscover2)
        {
            isDiscover = true;
            isDiscover2 = true;
        }
    }

    private void NearTarget()
    {
        float[] targetDistances = new float[77];

        for (int i = 1; i < 77; i++)
        {
            targetDistances[i] = Vector3.Distance(base.gameObject.transform.position, AIPos[i].transform.position);
        }

        float targetVal = 1000f;
        int targetId = 1;

        for (int j = 1; j < 77; j++)
        {
            if (targetDistances[j] <= targetVal)
            {
                targetVal = targetDistances[j];
                targetId = j;
            }
        }

        aimPos = targetId;
        beforePos = 1;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player1")
        {
            GameObject.Find("Black").GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 1f);

            if (GameObject.Find("innyume0") != null)
            {
                Object.Destroy(GameObject.Find("innyume0").GetComponent<AudioSource>());
            }

            if (GameObject.Find("innyume1") != null)
            {
                Object.Destroy(GameObject.Find("innyume1").GetComponent<AudioSource>());
            }

            if (GameObject.Find("innyume2") != null)
            {
                Object.Destroy(GameObject.Find("innyume2").GetComponent<AudioSource>());
            }

            SceneManager.LoadScene("GameOver");
        }
    }

    private void IsAIPosSuc(int _num)
    {
        if (!(Vector3.Distance(AIPos[_num].transform.position, base.gameObject.transform.position) >= 6f) && !(AIPos[_num].name == "AI" + beforePos) && !isDiscover && AIPos[_num].tag == "AIRoute")
        {
            switch (aimPos)
            {
                case 1:
                    aimPos = Randomize(6, 2, 12);
                    beforePos = 1;
                    break;
                case 2:
                    aimPos = Randomize(1, 7, 3);
                    beforePos = 2;
                    break;
                case 3:
                    aimPos = Randomize(2, 13, 9);
                    beforePos = 3;
                    break;
                case 4:
                    aimPos = Randomize(13, 5, 8);
                    beforePos = 4;
                    break;
                case 5:
                    aimPos = Randomize(4, 6, 28);
                    beforePos = 5;
                    break;
                case 6:
                    aimPos = Randomize(1, 5);
                    beforePos = 6;
                    break;
                case 7:
                    aimPos = Randomize(2, 8);
                    beforePos = 7;
                    break;
                case 8:
                    aimPos = Randomize(4, 7);
                    beforePos = 8;
                    break;
                case 9:
                    aimPos = Randomize(3, 10, 19);
                    beforePos = 9;
                    break;
                case 10:
                    aimPos = Randomize(9, 11);
                    beforePos = 10;
                    break;
                case 11:
                    aimPos = Randomize(10, 12, 67);
                    beforePos = 11;
                    break;
                case 12:
                    aimPos = Randomize(1, 11);
                    beforePos = 12;
                    break;
                case 13:
                    aimPos = Randomize(4, 3, 14);
                    beforePos = 13;
                    break;
                case 14:
                    aimPos = Randomize(13, 15, 16);
                    beforePos = 14;
                    break;
                case 15:
                    aimPos = Randomize(19, 14, 16);
                    beforePos = 15;
                    break;
                case 16:
                    aimPos = Randomize(14, 15, 17);
                    beforePos = 16;
                    break;
                case 17:
                    aimPos = Randomize(16, 18, 20);
                    beforePos = 17;
                    break;
                case 18:
                    aimPos = Randomize(17, 19);
                    beforePos = 18;
                    break;
                case 19:
                    aimPos = Randomize(9, 15, 18);
                    beforePos = 19;
                    break;
                case 20:
                    aimPos = Randomize(17, 21, 22, 23);
                    beforePos = 20;
                    break;
                case 21:
                    aimPos = Randomize(20, 22, 26);
                    beforePos = 21;
                    break;
                case 22:
                    aimPos = Randomize(21, 23, 25);
                    beforePos = 22;
                    break;
                case 23:
                    aimPos = Randomize(22, 24);
                    beforePos = 23;
                    break;
                case 25:
                    aimPos = Randomize(22, 24, 26);
                    beforePos = 24;
                    break;
                case 24:
                    aimPos = Randomize(23, 25, 27);
                    beforePos = 25;
                    break;
                case 26:
                    aimPos = Randomize(21, 25);
                    beforePos = 26;
                    break;
                case 27:
                    aimPos = Randomize(24, 25, 26, 63);
                    beforePos = 27;
                    break;
                case 28:
                    aimPos = Randomize(5, 29, 32);
                    beforePos = 28;
                    break;
                case 29:
                    aimPos = Randomize(28, 30, 33);
                    beforePos = 29;
                    break;
                case 30:
                    aimPos = Randomize(29, 31);
                    beforePos = 30;
                    break;
                case 31:
                    aimPos = Randomize(30, 32);
                    beforePos = 31;
                    break;
                case 32:
                    aimPos = Randomize(31, 33);
                    beforePos = 32;
                    break;
                case 33:
                    aimPos = Randomize(28, 29, 32, 34);
                    beforePos = 33;
                    break;
                case 34:
                    aimPos = Randomize(33, 35, 42);
                    beforePos = 34;
                    break;
                case 35:
                    aimPos = Randomize(34, 36, 41);
                    beforePos = 35;
                    break;
                case 36:
                    aimPos = Randomize(35, 37, 40);
                    beforePos = 36;
                    break;
                case 37:
                    aimPos = Randomize(36, 38, 39);
                    beforePos = 37;
                    break;
                case 38:
                    aimPos = Randomize(37, 53);
                    beforePos = 38;
                    break;
                case 39:
                    aimPos = Randomize(37, 40);
                    beforePos = 39;
                    break;
                case 40:
                    aimPos = Randomize(36, 39, 41, 45);
                    beforePos = 40;
                    break;
                case 41:
                    aimPos = Randomize(35, 40, 42, 44);
                    beforePos = 41;
                    break;
                case 42:
                    aimPos = Randomize(34, 41, 43);
                    beforePos = 42;
                    break;
                case 43:
                    aimPos = Randomize(42, 44, 52);
                    beforePos = 43;
                    break;
                case 44:
                    aimPos = Randomize(41, 43, 45, 51);
                    beforePos = 44;
                    break;
                case 45:
                    aimPos = Randomize(40, 44, 46, 50);
                    beforePos = 45;
                    break;
                case 46:
                    aimPos = Randomize(45, 47, 49);
                    beforePos = 46;
                    break;
                case 47:
                    aimPos = Randomize(46, 48, 59);
                    beforePos = 47;
                    break;
                case 48:
                    aimPos = Randomize(47, 49);
                    beforePos = 48;
                    break;
                case 49:
                    aimPos = Randomize(46, 48, 50);
                    beforePos = 49;
                    break;
                case 50:
                    aimPos = Randomize(45, 49, 51);
                    beforePos = 50;
                    break;
                case 51:
                    aimPos = Randomize(44, 50, 52);
                    beforePos = 51;
                    break;
                case 52:
                    aimPos = Randomize(43, 51);
                    beforePos = 52;
                    break;
                case 53:
                    aimPos = Randomize(38, 54);
                    beforePos = 53;
                    break;
                case 54:
                    aimPos = Randomize(53, 55);
                    beforePos = 54;
                    break;
                case 55:
                    aimPos = Randomize(54, 56);
                    beforePos = 55;
                    break;
                case 56:
                    aimPos = Randomize(55, 57, 58);
                    beforePos = 56;
                    break;
                case 57:
                    aimPos = Randomize(56, 58);
                    beforePos = 57;
                    break;
                case 58:
                    aimPos = Randomize(56, 57);
                    beforePos = 58;
                    break;
                case 59:
                    aimPos = Randomize(47, 60);
                    beforePos = 59;
                    break;
                case 60:
                    aimPos = Randomize(59, 61);
                    beforePos = 60;
                    break;
                case 61:
                    aimPos = Randomize(60, 62);
                    beforePos = 61;
                    break;
                case 62:
                    aimPos = Randomize(61, 63);
                    beforePos = 62;
                    break;
                case 63:
                    aimPos = Randomize(27, 62, 64);
                    beforePos = 63;
                    break;
                case 64:
                    aimPos = Randomize(63, 65);
                    beforePos = 64;
                    break;
                case 65:
                    aimPos = Randomize(64, 66);
                    beforePos = 65;
                    break;
                case 66:
                    aimPos = Randomize(65, 67);
                    beforePos = 66;
                    break;
                case 67:
                    aimPos = Randomize(11, 66, 68);
                    beforePos = 67;
                    break;
                case 68:
                    aimPos = Randomize(67, 69);
                    beforePos = 68;
                    break;
                case 69:
                    aimPos = Randomize(68, 70);
                    beforePos = 69;
                    break;
                case 70:
                    aimPos = Randomize(69, 71);
                    beforePos = 70;
                    break;
                case 71:
                    aimPos = Randomize(70, 72);
                    beforePos = 71;
                    break;
                case 72:
                    aimPos = Randomize(71, 73);
                    beforePos = 72;
                    break;
                case 73:
                    aimPos = Randomize(72, 74, 76);
                    beforePos = 73;
                    break;
                case 74:
                    aimPos = Randomize(73, 75);
                    beforePos = 74;
                    break;
                case 75:
                    aimPos = Randomize(74, 76);
                    beforePos = 75;
                    break;
                case 76:
                    aimPos = Randomize(73, 75);
                    beforePos = 76;
                    break;
            }
        }
    }

    private int Randomize(int a, int b)
    {
        if (a == beforePos)
        {
            return b;
        }

        if (b == beforePos)
        {
            return a;
        }

        return a;
    }

    private int Randomize(int a, int b, int c)
    {
        int num = Random.Range(0, 2);

        if (a == beforePos)
        {
            if (num == 0)
            {
                return b;
            }
            return c;
        }

        if (b == beforePos)
        {
            if (num == 0)
            {
                return a;
            }

            return c;
        }

        if (c == beforePos)
        {
            if (num == 0)
            {
                return a;
            }

            return b;
        }

        return a;
    }

    private int Randomize(int a, int b, int c, int d)
    {
        int num = Random.Range(0, 3);

        if (a == beforePos)
        {
            switch (num)
            {
                case 0:
                    return b;
                case 1:
                    return c;
                default:
                    return d;
            }
        }

        if (b == beforePos)
        {
            switch (num)
            {
                case 0:
                    return a;
                case 1:
                    return c;
                default:
                    return d;
            }
        }

        if (c == beforePos)
        {
            switch (num)
            {
                case 0:
                    return a;
                case 1:
                    return b;
                default:
                    return d;
            }
        }

        if (d == beforePos)
        {
            switch (num)
            {
                case 0:
                    return a;
                case 1:
                    return b;
                default:
                    return c;
            }
        }

        return a;
    }
}
