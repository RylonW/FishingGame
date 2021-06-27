using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourMainCon : MonoBehaviour
{
    public GameObject collectionIcon;
    public GameObject toolBoxIcon;
    public GameObject weelIcon;
    public GameObject mapIcon;
    public GameObject returnIcon;
    private Color notSelect = Color.white;
    private Color Select = Color.cyan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("四个主要按钮脚本执行中");
        selectMainButton(judgeMainButton(-ports.z));
    }
    void resetMainButton()
    {
        collectionIcon.GetComponent<Image>().color = notSelect;
        toolBoxIcon.GetComponent<Image>().color = notSelect;
        weelIcon.GetComponent<Image>().color = notSelect;
        mapIcon.GetComponent<Image>().color = notSelect;
        returnIcon.GetComponent<Image>().color = notSelect;
    }
    int judgeMainButton(int x)
    {
        int index = 3;
        if(-90 <= x && x < -54 )
        {
            index = 0;
        }
        else if(-54 <= x && x < -18)
        {
            index = 1;
        }
        else if(-18 <= x && x < 18 )
        {
            index = 2;
        }
        else if(18 <= x && x<54)
        {
            index = 4;
        }
        else index = 3;
        return index;
    }
     void selectMainButton(int index)
    {
        resetMainButton();
        switch(index)
        {
            case 0: //图鉴
            {
                collectionIcon.GetComponent<Image>().color = Select;
                if(ports.pause || Input.GetKeyDown(KeyCode.P))
                {
                    //点击打开图鉴
                    ports.pause = false;
                    Debug.Log("打开图鉴");  
                    MainPauseControl.state = 1;
                    //新版本图鉴不在新场景,换用浮窗展示
                    //SceneManager.LoadScene("Collection");
                }
                break;
            }
            case 1: //工具箱
            {
                toolBoxIcon.GetComponent<Image>().color = Select;   
                if( Input.GetKeyDown(KeyCode.P) || ports.pause)
                {         
                    ports.pause = false;
                    Debug.Log("打开工具箱");
                    MainPauseControl.state = 3;
                }    
                break;
            }
            case 2: //鱼篓
            {
                weelIcon.GetComponent<Image>().color = Select;
                if(ports.pause)
                {
                    ports.pause = false;
                    Debug.Log("打开鱼篓");
                    MainPauseControl.state = 4;
                }    
                break;
            }
            case 3: //退出
            {
                Debug.Log("选中退出键");
                returnIcon.GetComponent<Image>().color = Select;
                //Debug.Log(Input.GetKeyDown(KeyCode.P));
                if(ports.pause || Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("退出暂停");
                    ports.pause = false;
                    resetMainButton();
                    MainPauseControl.state = 5;
                    //解除暂停状态
                    //MainPauseControl.pauseOrNot = false;
                }    
                break;
            }
            case 4:
            {
                Debug.Log("选中地图键");
                mapIcon.GetComponent<Image>().color = Select;
                if(ports.pause)
                {
                    ports.pause = false;
                    MainPauseControl.state = 6;
                }
                break; 
            }
            case 5:
            break;
        }
    }
}
