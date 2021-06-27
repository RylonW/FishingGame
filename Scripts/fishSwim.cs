using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dataset;
public class fish
{
    public int id;
    public Transform[] path;
    public int pathID;
    public double des2bait;
    public GameObject prefab;
}
public class fishSwim : MonoBehaviour
{
    //生成路径
    //初始生成点
    public Transform startPoint;
    //路径序列
    public Transform[] pathList0;
    public Transform[] pathList1;
    public Transform[] pathList2;
    public Transform[] pathList3;
    public Transform[] pathList4;
    public Transform[] pathList5;
    public Transform[] pathList6;
    public Transform[] deletePath;
    /////////////////////////////////////////////////////////////
    //生成鱼类
    //鱼类预制体array
    public GameObject[] fishPrefabList;
    //实例化对象list
    public List<fish> fishInGame = new List<fish>();
    //开始游戏时鱼的条数
    public static int fishNum = 0;
    //游戏中实际鱼的条数
    public static int nowFishNum = 0;
    //游动速度
    public float speed = 1f;
    /////////////////////////////////////////////////////////////
    //音效
    public AudioSource hitFish;
    ////////////////////////////////////////////////////////////
    private bool fishHasBeenStopped = false;
    //删除相关//////////////////////////////////////////////////
    //被钓到的index,传给GameMisson用,在7个中选
    static public int deleteIndex;
    //储存被打中的鱼的序列
    public static bool[] delet_index = new bool[] {false,false,false,false,false,false,false};

    // Start is called before the first frame update
    void Start()
    {
        initFish();
    }
    // Update is called once per frame
    void Update()
    {   
        updateDes2Bait();
        deleteFish();
        //printInfo();
    }
    //隔一定的时间更新一次
    void FixedUpdate()
    {
        if(!MainPauseControl.pauseOrNot)
        {
            swim();
        }
        else if(!fishHasBeenStopped) 
        {
            Debug.Log("暂停鱼");
        }
        //显示
        //presentMissionProcess();
    }
    void initFish()
    {
        for(int i = 0;i < 7;i++)
        {
            fish tmp = new fish();
            tmp.id = i;
            tmp.pathID = 0;
            tmp.des2bait = 100;
            tmp.path = initPath(i);
            tmp.prefab = Instantiate(fishPrefabList[i],startPoint.position+new Vector3(i,0,0),startPoint.rotation);
            fishInGame.Add(tmp);
        }
        //初始化数量
        fishNum = fishInGame.Count;
        nowFishNum = fishNum;
    }
    Transform[] initPath(int i)
    {
        switch(i)
        {
            case 0:   
            return pathList0;
            case 1:
            return pathList1;
            case 2:
            return pathList2;
            case 3:
            return pathList3;
            case 4:
            return pathList4;
            case 5:
            return pathList5;
            case 6:
            return pathList6;
        }
        //不是前几种情况时
        return pathList0;
    }
    void deleteFish()
    {
        //避免被选到
        int deleteID = fishNum+1;
        for(int i =0;i<nowFishNum;i++)
        {
            if(fishInGame[i].des2bait < 1)
            {
                deleteID = i;
                break;
            }
        }
        if(deleteID == fishNum+1)
        {
            //什么都不做
        }
        else
        {
            passValue(fishInGame[deleteID].id);
            //fishInGame[deleteID].path = deletePath;
            Debug.Log("删除鱼"+deleteID);
            Destroy(fishInGame[deleteID].prefab);
            fishInGame[deleteID].prefab = new GameObject();
            fishInGame.RemoveAt(deleteID);
            Debug.Log("长度"+fishInGame.Count);
            nowFishNum = fishInGame.Count;
        }
    }
    void updateDes2Bait()
    {
        //更新与鱼饵间距
        for(int i =0;i<nowFishNum;i++)
        {
            if(castBait.realBait != null)
            {
            fishInGame[i].des2bait = Vector3.Distance(fishInGame[i].prefab.transform.position,castBait.realBait.transform.position);
            }
            else{}
        }
    }
    void swim()
    {
        float des = new float();
        for(int i = 0;i<nowFishNum;i++)
        {
            
            fishInGame[i].prefab.transform.LookAt(fishInGame[i].path[fishInGame[i].pathID]);
            des = Vector3.Distance(fishInGame[i].prefab.transform.position,fishInGame[i].path[fishInGame[i].pathID].position);
            fishInGame[i].prefab.transform.position = Vector3.MoveTowards(fishInGame[i].prefab.transform.position,fishInGame[i].path[fishInGame[i].pathID].position,Time.deltaTime * speed);
            if(des < 0.1f && fishInGame[i].pathID < fishInGame[i].path.Length)
            {
                //Debug.Log("鱼"+i);
                fishInGame[i].pathID++;
                fishInGame[i].pathID = fishInGame[i].pathID%fishInGame[i].path.Length;
            }
        }
    }
    void printInfo()
    {
        for(int i = 0;i<nowFishNum;i++)
        {
            Debug.Log(fishInGame[i].id);
        }
    }
    void passValue(int index)
    {
        deleteIndex = index;
        delet_index[index] = true;
    }
}
