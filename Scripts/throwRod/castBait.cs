using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基于抛物线的方法low
public class castBait : MonoBehaviour
{
    //挂在shootpoint
    //鱼钩预制体
    public GameObject bulletPrefab;
    //发射点的位置
    public Transform shootPoint;
    //用画线模拟鱼线抛出过程
    public LineRenderer line;
    //鱼钩出射水平速度
    public int bulletSpeed;
    //鱼饵是否发射的标志位,1表示已发射
    private bool flag;
    //每次实例化的鱼钩
    public static GameObject realBait;   
    //鱼钩经过的一系列点
    private List<Vector3> points = new List<Vector3>();
    //钓到鱼的音效object
    public AudioSource hitFish;
    void Start()
    {
        //添加刚体组件,不然无法利用初速度和重力
        //bulletPrefab.AddComponent<Rigidbody>();
        //开局不要发出声音,本脚本只控制落水的声音  
        this.GetComponent<AudioSource>().enabled = false;
        hitFish.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

        //if(ports.Throw)
        if((Input.GetKeyDown(KeyCode.W) || ports.RCB >5) &&  !flag )
        {
            //初始化子弹对象
            realBait = Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);
            //给予初速度
            //transform.right:红色axis
            //transform.forward:蓝色axis
            //realBait.GetComponent<Rigidbody>().velocity = realBait.transform.forward * bulletSpeed;
            
            realBait.GetComponent<Rigidbody>().velocity = realBait.transform.forward *2* (((int)ports.RCB)-5);
            //使用重力,在prefab处修改也可以
            realBait.GetComponent<Rigidbody>().useGravity = true;
            //标志鱼饵已被发射,整个场景中只能有一个鱼饵,销毁后置False
            flag = true;

        }
        //到达目标点前记录位置
        if(flag && realBait != null )
        {
            if(realBait.transform.position.y <= -2)
            {   
                //销毁目标
                Destroy(realBait);
                //清空line
                line.positionCount = 0;
                points.Clear();
                line.SetPositions(points.ToArray());
                //恢复flag为1，保证下一个创建不受影响
                flag = false;
            }
            else 
            {
                if(realBait.transform.position.y <= 0.1)
                {
                    this.GetComponent<AudioSource>().enabled = true;
                    //Debug.Log("play");
                }
                else
                {
                    this.GetComponent<AudioSource>().enabled = false;
                }
                //把鱼饵经过的点添加到line
                points.Add(realBait.transform.position);
                //更新line上点数
                line.positionCount = points.Count;
                //显示line中所有点
                line.SetPositions(points.ToArray());
            }
        } 
        
    }
}
