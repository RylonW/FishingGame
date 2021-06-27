using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dataset;
public class collectionInfoCon : MonoBehaviour
{
    public GameObject collectionInfoBG;
    //0:图片,1:种类,2:栖息地,3:介绍

    public GameObject fishPic;
    public GameObject Name;
    public GameObject Habitat;
    public GameObject Content;
    //public GameObject return2Col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("显示单个鱼信息中");
        if(ports.pause)
        {
            ports.pause = false;
            back2OriginBGPos();
            MainPauseControl.state = 1;
        }
        else
        {
            initBGPos();
            showIntro(collectionCon.tmpBtn);
        }
    }
    void initBGPos()
    {
        collectionInfoBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,369);
    }
    void back2OriginBGPos()
    {
        Debug.Log("collection回到原位置");
        collectionInfoBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1023,0);
    }
    void showIntro(int index)
    {
        TextAsset itemText = Resources.Load<TextAsset>("dataset");  //从Resources文件夹下直接加载json文件
        string itemJson = itemText.text;
        ItemData data = JsonUtility.FromJson<ItemData>(itemJson);
        fishPic.GetComponent<Image>().sprite = Resources.Load<Sprite>(data.Infolist[index].sprites);
        Name.GetComponent<Text>().text = data.Infolist[index].name;
        Habitat.GetComponent<Text>().text = data.Infolist[index].habitat;
        Content.GetComponent<Text>().text = data.Infolist[index].content;
    }
}
