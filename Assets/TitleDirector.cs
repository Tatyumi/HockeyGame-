using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

    /// <summary>目標スコア</summary>
    public static int matchNum = 0;

    GameObject arrangePanel;

    void Start()
    {
        this.arrangePanel = GameObject.Find("ArrangePanel");
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// １ポイントマッチ
    /// </summary>
    public void p_Push1()
    {
        matchNum = 1;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 3ポイントマッチ
    /// </summary>
    public void p_Push3()
    {
        matchNum = 3;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 5ポイントマッチ
    /// </summary>
    public void p_Push5()
    {
        matchNum = 5;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void vssceneMove()
    {
        this.arrangePanel.transform.localPosition = new Vector3(0, -100, 0);
    }
}
