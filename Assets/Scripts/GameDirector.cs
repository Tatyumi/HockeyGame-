using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;

public class GameDirector : MonoBehaviour
{

    /// <summary>プレイヤー1スコア</summary>
    public GameObject Player1ScoreObj;
    /// <summary>プレイヤー2スコア</summary>
    public GameObject Player2ScoreObj;
    /// <summary>ジャッジパネル</summary>
    public GameObject JudagePanel;
    /// <summary>アゲインパネル</summary>
    public GameObject CountinuePanel;
    /// <summary>ボール</summary>
    public GameObject Ball;
    /// <summary>プレイヤー1のポイント</summary>
    public int Player1Score;
    /// <summary>プレイヤー2のポイント</summary>
    public int Player2Score;
    /// <summary>目標ポイント</summary>
    public int MatchPoint;
    /// <summary>オーディオマネージャー</summary>
    public AudioManager AudioManager;
    /// <summary>スタートパネル</summary>
    public GameObject StartPanel;
    /// <summary>ボールコントローラ</summary>
    //private BallController ballController;
    /// <summary>プレイヤー1スコアテキスト</summary>
    private Text player1ScoreText;
    /// <summary>プレイヤー2スコアテキスト</summary>
    private Text player2ScoreText;

    private void Awake()
    {
        AudioManager = GameObject.Find(Constans.AUDIO_MANAGER).GetComponent<AudioManager>();
        player1ScoreText = this.Player1ScoreObj.GetComponent<Text>();
        player2ScoreText = this.Player2ScoreObj.GetComponent<Text>();
        //ballController = Ball.GetComponent<BallController>();
    }

    // Use this for initialization
    void Start()
    {
        // スコアの初期値代入
        Player1Score = 0;
        Player2Score = 0;
        player1ScoreText.text = "1P Score:" + Player1Score.ToString();
        player2ScoreText.text = "2P Score:" + Player2Score.ToString();

        // 各パネルを初期状態にする
        this.JudagePanel.SetActive(false);
        this.CountinuePanel.SetActive(false);
        this.StartPanel.SetActive(true);

        MatchPoint = TitleDirector.MatchPoint;
        AudioManager.PlaySound(Constans.VS_SCENE_BGM);
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void StartGame()
    {
        AudioManager.PlaySound(Constans.START_GAME_SE);

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
        this.StartPanel.SetActive(false);
    }

    /// <summary>
    /// プレイヤー１のスコア加算
    /// </summary>
	public void AddScore_p1()
    {
        Player1Score += 1;
        player1ScoreText.text = "1P Score:" + Player1Score.ToString();
    }

    /// <summary>
    /// プレイヤー2のスコア加算
    /// </summary>
    public void AddScore_p2()
    {
        Player2Score += 1;
        player2ScoreText.text = "2P Score:" + Player2Score.ToString();
    }

    /// <summary>
    /// 両スコアが目標スコアに達した時の判定処理
    /// </summary>
    /// <param name="score1">プレイヤー1のスコア</param>
    /// <param name="score2">プレイヤー2のスコア</param>
    public void CheckScore(int score1, int score2)
    {
        // プレーヤー1が勝利した場合
        if (score1 == MatchPoint)
        {
            AudioManager.PlaySound(Constans.END_GAME_SE);

            // プレイヤー１が勝利になるようにジャッジパネルを表示
            this.JudagePanel.SetActive(true);
            this.JudagePanel.transform.Rotate(0, 0, 180);

            Destroy(this.Ball);
        }
        else if (score2 == MatchPoint)
        {
            AudioManager.PlaySound(Constans.END_GAME_SE);

            // プレイヤー２が勝利になるようにジャッジパネルを表示
            this.JudagePanel.SetActive(true);

            Destroy(this.Ball);
        }
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
    public void TitleSceneMove()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(Constans.TITLE_SCENE_NAME);
    }

    /// <summary>
    /// VSシーンに遷移
    /// </summary>
    public void VsSceneMove()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(Constans.VS_SCENE_NAME);
    }

    /// <summary>
    /// ボタンタップ処理
    /// </summary>
    public void TapButton()
    {
        AudioManager.PlaySound(Constans.TAP_BUTTON_SE);
    }
}
