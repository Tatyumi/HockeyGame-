using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

    /// <summary>目標スコア</summary>
    public static int MatchNum = 0;
    /// <summary>セッティングパネル</summary>
    public GameObject SettingPanel;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// １ポイントマッチを選択
    /// </summary>
    public void SelectOnepointmuch()
    {
        MatchNum = 1;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 3ポイントマッチを選択
    /// </summary>
    public void SelectThreepointmuch()
    {
        MatchNum = 3;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// 5ポイントマッチを選択
    /// </summary>
    public void SelectFivepointmuch()
    {
        MatchNum = 5;
        SceneManager.LoadScene("VsScene");
    }

    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void DisplayarrangePanel()
    {
        this.SettingPanel.transform.localPosition = new Vector3(0, -100, 0);
    }
}
