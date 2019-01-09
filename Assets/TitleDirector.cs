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
    /// １ポイントマッチを選択
    /// </summary>
    public void SelectOnepointmuch()
    {
        matchNum = 1;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 3ポイントマッチを選択
    /// </summary>
    public void SelectThreepointmuch()
    {
        matchNum = 3;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 5ポイントマッチを選択
    /// </summary>
    public void SelectFivepointmuch()
    {
        matchNum = 5;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void DisplayarrangePanel()
    {
        this.arrangePanel.transform.localPosition = new Vector3(0, -100, 0);
    }
}
