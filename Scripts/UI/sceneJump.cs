using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneJump : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //输入:要跳转场景的名称(！！！注意大小写！！！)
    public void clickJump(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //点击退出
    public void clickQuitStart()
    {
        Application.Quit();
    }

}
