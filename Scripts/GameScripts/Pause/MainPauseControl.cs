using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPauseControl : MonoBehaviour
{
    //是否处于暂停状态
    public static bool pauseOrNot = false;
    //当前所处的状态,控制MainState
    public static int state = 0;
    //挂载各部分控制逻辑的物体//////////////////////////////////////////////
    public GameObject hangFourMainButton;
    public GameObject hangCollection;
    public GameObject hangToolbox;
    public GameObject hangWeel;
    //控制杆,鱼饵相关
    //鱼竿位置相关(playerposition)
    public GameObject rod;
    //发射球球相关
    public GameObject shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        scriptsAllFalse();
    }
    // Update is called once per frame
    void Update()
    {
        if(pauseOrNot)
        {
            Debug.Log("暂停中");
            //被暂停
            pauseRod();
            selectMainState();
        }
        else
        {
            //Debug.Log("正常运行");
            //正常运行
            aliveRod();
            enterPause();
        }
    }
    void enterPause()
    {
        if((Input.GetKeyDown(KeyCode.P) || ports.pause))
        {
            ports.pause = false; 
            Debug.Log("按下暂停");
            pauseOrNot = true;    
        }
    }
    void pauseRod()
    {
        //杆不能动
        rod.GetComponent<rodRotate>().enabled = false;
        shootPoint.GetComponent<castBait>().enabled = false;
        //Debug.Log("杆不能动");
    }
    void aliveRod()
    {
        //恢复鱼竿行动
        rod.GetComponent<rodRotate>().enabled = true;
        shootPoint.GetComponent<castBait>().enabled = true;
    }
    void selectMainState()
    {
        //state:0,只能选中底下四个按钮
        //state:1,选中图鉴页面
        //state:2,单个鱼介绍
        //state:3,工具箱
        //state:4,鱼篓
        //state:5,退出暂停
        //state:6,地图
        switch(state)
        {
            case 0:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = true;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = false;
            break;
            case 1:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = true;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = false;
            break;
            case 2:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = true;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = false;
            break;
            case 3:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = true;
            hangWeel.GetComponent<weelControl>().enabled = false;
            break;
            case 4:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = true;
            break;
            case 5:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = false;
            //解除暂停状态
            MainPauseControl.pauseOrNot = false;
            state = 0;
            break;
            case 6:
            hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
            hangCollection.GetComponent<collectionCon>().enabled = false;
            hangCollection.GetComponent<collectionInfoCon>().enabled = false;
            hangToolbox.GetComponent<toolBoxControl>().enabled = false;
            hangWeel.GetComponent<weelControl>().enabled = false;
            //返回Map页面
            SceneManager.LoadScene("Map");
            state = 5;
            break;
        }
    }
    void scriptsAllFalse()
    {
        hangFourMainButton.GetComponent<fourMainCon>().enabled = false;
        hangCollection.GetComponent<collectionCon>().enabled = false;
        hangCollection.GetComponent<collectionInfoCon>().enabled = false;
        hangToolbox.GetComponent<toolBoxControl>().enabled = false;
        hangWeel.GetComponent<weelControl>().enabled = false;
    }
}

