using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveImages : MonoBehaviour
{
    public Image picture1;
    public Image picture2;
    public Image picture3;
    public Image picture4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        picture2.transform.position = Vector3.Lerp(picture2.transform.position, picture1.transform.position, (1f*Time.deltaTime)/2);
        picture3.transform.position = Vector3.Lerp(picture3.transform.position, picture1.transform.position, (1f*Time.deltaTime)/4);
        picture4.transform.position = Vector3.Lerp(picture4.transform.position, picture1.transform.position, (1f*Time.deltaTime)/6);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(2);
        }
    }
}
