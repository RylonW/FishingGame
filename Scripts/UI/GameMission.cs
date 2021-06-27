using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dataset;

public class GameMission : MonoBehaviour
{
    //挂在Game->Canvas->Mission
    public Image img;
    public GameObject Num;
    public GameObject Introduction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Num.GetComponent<Text>().text = fishSwim.nowFishNum + "/" + fishSwim.fishNum;
        ReadHabitatFromJson(fishSwim.deleteIndex);
    }
    void ReadHabitatFromJson(int index)
    {
        TextAsset itemText = Resources.Load<TextAsset>("dataset");  //从Resources文件夹下直接加载json文件
        string itemJson = itemText.text;
        ItemData data = JsonUtility.FromJson<ItemData>(itemJson);
        Introduction.GetComponent<Text>().text = data.Infolist[index].name + data.Infolist[index].habitat ;
        img.sprite = Resources.Load<Sprite>(data.Infolist[index].sprites);
    }

}
