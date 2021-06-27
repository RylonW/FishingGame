using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectionCon : MonoBehaviour
{
    public GameObject collectionBG;
    //17个按钮
    public GameObject[] fish_icon = new GameObject[17];
    //一些参数
    private const int init_posx = 40;
    private const int init_posy = 160;
    private const int sidelen_x = 220;
    private const int sidelen_y = 120;
    public static int choose_x, choose_y,choose_button;
    private const short x_upbound = 32;
    private const short y_upbound = 64;
    private const short x_downbound = -32;
    private const short y_downbound = -64;
    //鱼的名称
    private string[] fishNames = new string[7] {"金鱼","香鱼","西太公鱼","蓝鳃太阳鱼","蓝刺尾鱼","狮子鱼","条石鲷"};
    public static int tmpBtn;
    // Start is called before the first frame update
    void Start()
    {
        initFishIconPos();
        initBGPos();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("图鉴脚本执行中");
        if(ports.pause) //按下按钮
        {   ports.pause = false;
            PressButton();
        }
        else
        {
            initBGPos();
            ScanChooseFish((short)(-(int)ports.z), ports.x);
            ChangeSelectedFishIcon();
            Debug.Log("cb:"+choose_button);
        }
    }
    void initBGPos()
    {
        Debug.Log("初始化位置");
        collectionBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,369);
    }
    void back2OriginBGPos()
    {
        Debug.Log("collection回到原位置");
        collectionBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-459);
    }
    void initFishIconPos()
    {
        int row_delta, column_delta; //表征第i个按钮的行和列变换系数
        int posx_i, posy_i;
        // 放16个按钮，根据行和列的变换系数来设置锚点位置
        for (int i = 0; i < 16; i++)
        {
            row_delta = i % 4;
            column_delta = (int)Math.Floor((double)i / 4);
            posx_i = init_posx + row_delta * sidelen_x;
            posy_i = init_posy - column_delta * sidelen_y;
            fish_icon[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx_i, posy_i);
        }
    }
    void ScanChooseFish(int xangle, int yangle)
    {
        //当欧拉角处于规定范围内时
        if (x_downbound < xangle && xangle < x_upbound && y_downbound < yangle && yangle < y_upbound)
        {
            //一共十六个按钮，横向和纵向分别index为0,1,2,3
            //通过xangle和yangle分别计算横纵向的index
            choose_x = (int)Math.Floor((double)(4 * (xangle - x_downbound) / (x_upbound - x_downbound)));
            choose_y = (int)Math.Floor((double)(4 * (yangle - y_downbound) / (y_upbound - y_downbound)));
            //通过Index计算选中的是第几个按钮
            choose_button = 4 * choose_y + choose_x;

        }
        //将规定范围之外设定为退出
        else
            choose_button = 16;//0~15为鱼，16是退出
        //Debug.Log(choose_button);

    }     
    void ResetFishIconImg()
    {
        //前7条鱼，根据被打中与否加载图像
        for(int i = 0;i<7;i++)
        {
            //该鱼已经被击中,常态图标变为init/x
            if(fishSwim.delet_index[i])
            {
                fish_icon[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("init/"+fishNames[i]);
            }
            else
            {
                fish_icon[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("init/锁");
            }
            
        }
        //剩下的鱼
        for(int i = 7;i<16;i++)
        {
            fish_icon[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("init/锁");
        }
        //退出键
        fish_icon[16].GetComponent<Image>().color = Color.white;
    }
     void ChangeSelectedFishIcon()
    {
        ResetFishIconImg(); //初始化图标
        if(choose_button < 7)
        {
            if(fishSwim.delet_index[choose_button])
            {
                //显示被选中的图片
                fish_icon[choose_button].GetComponent<Image>().sprite = Resources.Load<Sprite>("selected/"+fishNames[choose_button]);
            }
            else
            {
                //显示未解锁黑泡泡
                fish_icon[choose_button].GetComponent<Image>().sprite = Resources.Load<Sprite>("selected/黑泡");
            }
        }
        else
        {
            if(choose_button == 16)//退出
            {
                fish_icon[16].GetComponent<Image>().color = Color.cyan;
            }
            else//其他根本就没有的鱼
            {
                fish_icon[choose_button].GetComponent<Image>().sprite = Resources.Load<Sprite>("selected/黑泡");
            }
        }
    }
    void PressButton()
    {
        if(choose_button == 16)
        {
            //回到4button状态
            MainPauseControl.state = 0;
            back2OriginBGPos();
        }
        else if(choose_button <= 6)
        {
            //储存当前值
            tmpBtn = choose_button;
            //转去执行显示单个鱼信息
            MainPauseControl.state = 2;
            back2OriginBGPos();
        }
        else
        {
            //停留在当前状态
            MainPauseControl.state = 1;
        }
    }
}
