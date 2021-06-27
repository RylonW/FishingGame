using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolBoxControl : MonoBehaviour
{
    //工具箱背景物体
    public GameObject toolboxBG;
    // Start is called before the first frame update
    void Start()
    {
        initBGPos();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("选中工具箱");
        if(ports.pause)
        {
            ports.pause = false;
            back2OriginBGPos();
            MainPauseControl.state = 0;
        }
        else
        {
            initBGPos();
        }
    }
    void initBGPos()
    {
        Debug.Log("初始化位置");
        toolboxBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(23,154);
    }
    void back2OriginBGPos()
    {
        Debug.Log("toolbox回到原位置");
        toolboxBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000,0);
    }
}
