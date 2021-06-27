using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weelControl : MonoBehaviour
{
    public GameObject weelBG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("鱼篓");
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
        weelBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-22,169);
    }
    void back2OriginBGPos()
    {
        Debug.Log("toolbox回到原位置");
        weelBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-650,449);
    }
}
