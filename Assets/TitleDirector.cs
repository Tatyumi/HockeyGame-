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
    /// 目標ポイントを設定し，ゲームシーンに遷移等のゲーム開始にするための処理
    /// </summary>
    /// <param name="selectedPoint">選択した目標ポイント</param>
    public void StartProcess(int selectedPoint) {
        MatchNum = selectedPoint;
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
