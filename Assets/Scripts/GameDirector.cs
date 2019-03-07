using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CommonConstans;

public class GameDirector : MonoBehaviour
{
    /// <summary>ジャッジパネル</summary>
    public GameObject JudagePanel;
    /// <summary>アゲインパネル</summary>
    public GameObject CountinuePanel;
    /// <summary>ボール</summary>
    public GameObject Ball;
    /// <summary>目標ポイント</summary>
    public int MatchPoint;
    /// <summary>オーディオマネージャー</summary>
    public AudioManager AudioManager;
    /// <summary>スタートパネル</summary>
    public GameObject StartPanel;

    private void Awake()
    {
        AudioManager = GameObject.Find(CommonConstans.ObjectName.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        // 各パネルを初期状態にする
        this.JudagePanel.SetActive(false);
        this.CountinuePanel.SetActive(false);
        this.StartPanel.SetActive(true);

        // タイトルシーンで指定したポイントを取得
        MatchPoint = TitleDirector.MatchPoint;

        // BGM再生
        AudioManager.PlaySound(CommonConstans.SoundName.VS_SCENE_BGM);
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void StartGame()
    {
        AudioManager.PlaySound(CommonConstans.SoundName.START_GAME_SE);

        //ボール初期位置に配置
        Ball.transform.localPosition = new Vector3(0, 0, 0);

        //ボールの移動方向を代入
        BallController.BallXRange = Random.Range(-8, 8);
        BallController.BallYRange = Random.Range(-8, 8);

        // ボールの発射角が垂直かどうか判別
        if (-2 < BallController.BallXRange && BallController.BallXRange < 2)
        {
            StartGame();
        }
        else if (-2 < BallController.BallXRange && BallController.BallXRange < 2)
        {
            StartGame();
        }

        // スタートパネルを非表示にする
        this.StartPanel.SetActive(false);
    }

    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    public void FinishedGame(string objName)
    {
        this.JudagePanel.SetActive(true);

        // 勝利したプレイヤーの判別
        if (objName.Contains("2"))
        {
            this.JudagePanel.transform.Rotate(0, 0, 180);
        }

        AudioManager.PlaySound(CommonConstans.SoundName.END_GAME_SE);
        Destroy(this.Ball);
    }

    /// <summary>
    /// コンテニューパネルの表示
    /// </summary>
    public void CountinuePanelDisplay()
    {
        this.CountinuePanel.SetActive(true);
    }

    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitleScene()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(CommonConstans.SceneName.TITLE_SCENE_NAME);
    }

    /// <summary>
    /// VSシーンに遷移
    /// </summary>
    public void MoveVsScene()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(CommonConstans.SceneName.VS_SCENE_NAME);
    }

    /// <summary>
    /// ボタンタップ処理
    /// </summary>
    public void PlayTapButtonSE()
    {
        AudioManager.PlaySound(CommonConstans.SoundName.TAP_BUTTON_SE);
    }
}
