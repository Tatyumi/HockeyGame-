using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Common;

public class TitleDirector : MonoBehaviour {

    /// <summary>セッティングパネル</summary>
    public GameObject SettingPanel;
    /// <summary>セレクトキャラパネル</summary>
    public GameObject SelectCharaPanel;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Awake()
    {
        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        audioManager.PlaySound(Common.SoundName.TITLE_SCENE_BGM);
        this.SettingPanel.SetActive(false);
        this.SelectCharaPanel.SetActive(false);
    }

    /// <summary>
    /// ゲーム設定パネル表示
    /// </summary>
    public void DisplaySettingPanel()
    {
        this.SettingPanel.SetActive(true);
    }

    /// <summary>
    /// キャラタイプ選択パネル表示
    /// </summary>
    /// <param name="panel">現在表示しているパネル</param>
    public void DisplaySelectCharaPanel(GameObject panel)
    {
        panel.SetActive(false);
        this.SelectCharaPanel.SetActive(true);
    }

    /// <summary>
    /// ボタンタップ時のSE再生
    /// </summary>
    public void PlayTapButtonSE()
    {
        audioManager.PlaySound(Common.SoundName.TAP_BUTTON_SE);
    }
}
