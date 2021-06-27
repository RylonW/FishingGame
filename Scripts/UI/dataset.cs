using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

namespace dataset
{
//定义数据集命名空间
[System.Serializable]
public class ItemInfo           //数据模板类
{
    public int id;
    public string name;
    public string habitat;
    public string content;
    public string sprites;//图片存放地址
}


public class ItemData           //数据接收类
{
    public List<ItemInfo> Infolist;
	public int total;
}

public class dataset : MonoBehaviour          //测试类
{
	private void Start()
   {
      ParseItemJson();
   }
   
	private void ParseItemJson()
   {
      TextAsset itemText = Resources.Load<TextAsset>("dataset");  //从Resources文件夹下直接加载json文件
      string itemJson = itemText.text;
      ItemData data = JsonUtility.FromJson<ItemData>(itemJson);
      Debug.Log(data.total);
      Debug.Log(data.Infolist[0].id);
      foreach (ItemInfo info in data.Infolist)
      {
         Debug.Log(info.id);
         Debug.Log(info.name);
         Debug.Log(info.habitat);
         Debug.Log(info.content);
         Debug.Log(info.sprites);
      }
   }
}
}
