using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rodRotate : MonoBehaviour
{
    //鱼竿姿态映射脚本
    // Start is called before the first frame update
    public GameObject rod;
    public int xAngle,yAngle,zAngle;
    public Text textx,texty,textz;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        xAngle = ports.x;
        yAngle = ports.y;
        zAngle = ports.z;
        //Debug.Log("x:"+xAngle);
        //Debug.Log("y:"+yAngle);
        //Debug.Log("z:"+zAngle);
        //port控制鱼竿旋转,有数据传入时才用,无数据传入时用A/D控制左右旋转
        if(xAngle == 0 && yAngle == 0 && zAngle == 0)
        {}
        else rod.transform.rotation = Quaternion.Euler(new Vector3((ports.x>60)?60:ports.x,-ports.z,ports.y));
    }
}
