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
        audioManager = GameObject.Find(Common.ObjectName.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        audioManager.PlaySound(Common.SoundName.TITLE_SCENE_BGM);
        this.SettingPanel.SetActive(false);
    }
    
    /// <summary>
    /// 目標ポイントを設定し，ゲームシーンに遷移等のゲーム開始にするための処理
    /// </summary>
    /// <param name="selectedPoint">選択した目標ポイント</param>
    public void StartProcess(int selectedPoint) {
        MatchPoint = selectedPoint;
        SceneManager.LoadScene(Common.SceneName.VS_SCENE_NAME);
        audioManager.StopSound();
    }

    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void DisplaySettingPanel()
    {
        this.SettingPanel.SetActive(true);
    }

    /// <summary>
    /// ボタンタップ時のSE再生
    /// </summary>
    public void PlayTapButtonSE()
    {
        audioManager.PlaySound(Common.SoundName.TAP_BUTTON_SE);
    }
}
