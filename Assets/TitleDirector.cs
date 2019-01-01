using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

    public static int matchNum = 0;

    GameObject arrangePanel;

    void Start()
    {
        this.arrangePanel = GameObject.Find("ArrangePanel");
        DontDestroyOnLoad(this);
    }

    public void p_Push1()
    {
        matchNum = 1;
        SceneManager.LoadScene("VsScene");
    }
    public void p_Push3()
    {
        matchNum = 3;
        SceneManager.LoadScene("VsScene");
    }
    public void p_Push5()
    {
        matchNum = 5;
        SceneManager.LoadScene("VsScene");
    }


    public void vssceneMove()
    {
        this.arrangePanel.transform.localPosition = new Vector3(0, -100, 0);
    }
}
