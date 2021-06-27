using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mapControl : MonoBehaviour
{
    //要控制的三个button
    public GameObject map0;
    public GameObject map1;
    public GameObject back;
    //未选中的颜色
    private Color notSelect = Color.white;
    //被选中的颜色
    private Color select = Color.cyan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        initIcons();
        Debug.Log("map running");
        //选中map0
        if(-ports.z <-15)
        {
            map0.GetComponent<RectTransform>().sizeDelta = new Vector2(200,200);
            if(ports.pause || Input.GetKeyDown(KeyCode.P))
            {
                ports.pause = false;
                Debug.Log("map0");
                SceneManager.LoadScene("Game");
            }
        }
        //选中map1
        else if(-15 <= -ports.z && -ports.z < 15)            
        {
            map1.GetComponent<RectTransform>().sizeDelta = new Vector2(200,200);
        }
        else
        {
            //选中back
            back.GetComponent<RectTransform>().sizeDelta = new Vector2(150,150);
            if(ports.pause)
            {
                ports.pause = false;
                SceneManager.LoadScene("Start");
            }
        }
    }
    void initIcons()
    {
        map0.GetComponent<RectTransform>().sizeDelta = new Vector2(150,150);
        map1.GetComponent<RectTransform>().sizeDelta = new Vector2(150,150);
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
    }
}
