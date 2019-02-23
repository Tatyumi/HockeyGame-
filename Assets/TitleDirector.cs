using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Common;

public class TitleDirector : MonoBehaviour {

    /// <summary>目標ポイント</summary>
    public static int MatchPoint = 0;
    /// <summary>セッティングパネル</summary>
    public GameObject SettingPanel;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find(Constans.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        audioManager.PlaySound(Constans.TITLE_SCENE_BGM);
    }
    
    /// <summary>
    /// 目標ポイントを設定し，ゲームシーンに遷移等のゲーム開始にするための処理
    /// </summary>
    /// <param name="selectedPoint">選択した目標ポイント</param>
    public void StartProcess(int selectedPoint) {
        MatchPoint = selectedPoint;
        SceneManager.LoadScene(Constans.VS_SCENE_NAME);
        audioManager.StopSound();
    }


    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void DisplaySettingPanel()
    {
        this.SettingPanel.transform.localPosition = new Vector3(0, -100, 0);
    }
}
