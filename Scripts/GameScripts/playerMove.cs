using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //键盘控制旋转
    public GameObject player;
    
   //放在Updata里面每一帧都会执行，导致不能够保存前一时刻的值 
    void Update()
    {   //按下向左旋转 
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,-5,0),Space.World);
        }
        //按下向右旋转
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,5,0),Space.World);
        }
    }
    void FixedUpdate()
    {
    
    }
}

