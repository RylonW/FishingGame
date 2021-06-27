using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class startControl : MonoBehaviour
{
   
    //public Image img;
    public bool press = false;
    public ColorBlock cb = new ColorBlock();
    public ColorBlock notSelect = new ColorBlock();
    public GameObject start_button;
    public GameObject handbook_button;
    public GameObject exit_button;
    public static bool goBack2Start = false;
    // Start is called before the first frame update
    void Start()
    {
        //保存初始颜色状态,存入notSelect
        notSelect = start_button.GetComponent<Button>().colors;
        //指定选中时的颜色；
        cb.normalColor = Color.cyan;
        //不指定显示不出来
        cb.colorMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        select();
    }
        public void select()
    {
        if(-90 < -ports.z && -ports.z < -30)
        {
            //img.GetComponent<VideoPlayer>().Play();
            //start_button.colors = cb;
            start_button.GetComponent<Button>().colors = cb;
            if(ports.pause)
            {
            ports.pause = false;
            SceneManager.LoadScene("Map");
            }
        }
        else start_button.GetComponent<Button>().colors = notSelect;
        if(-30 < -ports.z && -ports.z < 30 )            
        {
            handbook_button.GetComponent<Button>().colors = cb;
            if(ports.pause)
            {
            ports.pause = false;
            Debug.Log("collection");
            SceneManager.LoadScene("Collection");
            //表示从Start场景进入图鉴
            goBack2Start = true;
            }
        }
        else handbook_button.GetComponent<Button>().colors = notSelect;
        if(30 < -ports.z && -ports.z < 90 )           
        {
            exit_button.GetComponent<Button>().colors = cb;
            if(ports.pause)
            {
            ports.pause = false;
            Application.Quit();
            }
        }
        else exit_button.GetComponent<Button>().colors  = notSelect;
    }
}
