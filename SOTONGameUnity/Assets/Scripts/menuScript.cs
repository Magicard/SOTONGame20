using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public AudioSource move;
    public AudioSource accept;

    public GameObject rightArrow;
    public GameObject leftArrow;
    public Transform start;
    public Transform options;
    public Transform exit;
    public Transform start2;
    public Transform options2;
    public Transform exit2;
    public float pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = 0f;
        /*Vector3 temp1 = new Vector3(481, 133, 348);
        start.transform.position = temp1;
        Vector3 temp2 = new Vector3(521, 75, 348);
        options.transform.position = temp2;
        Vector3 temp3 = new Vector3(452, 12, 348);
        exit.transform.position = temp3;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            move.Play(0);
            if (pos == 0 || pos == 1)
            {
                pos++;
            }
            else
            {
                pos = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            move.Play(0);
            if (pos == 1 || pos == 2)
            {
                pos--;
            }
            else
            {
                pos = 2;
            }
        }

        if (pos == 1)
        {
            Debug.Log("yes");
            rightArrow.transform.position = options.transform.position;
            leftArrow.transform.position = options2.transform.position;
        }
        if (pos == 2)
        {
            rightArrow.transform.position = exit.transform.position;
            leftArrow.transform.position = exit2.transform.position;
        }
        if (pos == 0)
        {
            rightArrow.transform.position = start.transform.position;
            leftArrow.transform.position = start2.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            accept.Play(0);
            Invoke("nextScene", 1);
        }

    }

    void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
