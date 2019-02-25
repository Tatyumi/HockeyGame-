using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;

public class GameDirector : MonoBehaviour {
    
    /// <summary>プレイヤー1テキスト</summary>
    public GameObject PlayerText1;
    /// <summary>プレイヤー2テキスト</summary>
    public GameObject PlayerText2;
    /// <summary>ジャッジパネル</summary>
    public GameObject JudagePanel;
    /// <summary>アゲインパネル</summary>
    public GameObject AgainPanel;
    /// <summary>ボール</summary>
    public GameObject Ball;
    /// <summary>プレイヤー1のポイント</summary>
    public int OnePlayerPoint;
    /// <summary>プレイヤー2のポイント</summary>
    public int TwoPlayerPoint;
    /// <summary>目標ポイント</summary>
    public int MatchPoint;
    /// <summary>オーディオマネージャー</summary>
    public AudioManager AudioManager;
    /// <summary>スタートパネル</summary>
    public GameObject StartPanel;
    /// <summary>ボールコントローラ</summary>
    private BallController ballController;

    private void Awake()
    {
        AudioManager = GameObject.Find(Constans.AUDIO_MANAGER).GetComponent<AudioManager>();
        ballController = Ball.GetComponent<BallController>();
    }

    // Use this for initialization
    void Start () {

        this.PlayerText1.GetComponent<Text>().text = "1P Score:" + OnePlayerPoint.ToString();
        this.PlayerText2.GetComponent<Text>().text = "2P Score:" + TwoPlayerPoint.ToString();
        OnePlayerPoint = 0;
        TwoPlayerPoint = 0;
        MatchPoint = TitleDirector.MatchPoint;
        AudioManager.PlaySound(Constans.VS_SCENE_BGM);
        //スタートパネルのの初期位置
        this.StartPanel.transform.localPosition = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void StartGame()
    {
        Debug.Log("ゲームスタート！");
        //ボール初期位置に配置
        Ball.transform.localPosition = new Vector3(0, 0, 0);
        //ボールの移動方向
        ballController.BallXRange = Random.Range(-8, 8);
        ballController.BallYRange = Random.Range(-8, 8);

        if (-2 < ballController.BallXRange && ballController.BallXRange < 2)
        {
            StartGame();
        }
        else if (-2 < ballController.BallXRange && ballController.BallXRange < 2)
        {
            StartGame();
        }
        this.StartPanel.transform.localPosition = new Vector3(0, 450, 0);
    }

    /// <summary>
    /// プレイヤー１のスコア加算
    /// </summary>
	public void AddScore_p1()
    {
        OnePlayerPoint += 1;
        this.PlayerText1.GetComponent<Text>().text = "1P Score:" + OnePlayerPoint.ToString();
        CheckScore(OnePlayerPoint,TwoPlayerPoint);
    }

    /// <summary>
    /// プレイヤー2のスコア加算
    /// </summary>
    public void AddScore_p2()
    {
        TwoPlayerPoint += 1;
        this.PlayerText2.GetComponent<Text>().text = "2P Score:" + TwoPlayerPoint.ToString();
        CheckScore(OnePlayerPoint,TwoPlayerPoint);
    }

    /// <summary>
    /// 両スコアが目標スコアに達した時の判定処理
    /// </summary>
    /// <param name="score1"></param>
    /// <param name="score2"></param>
    public void CheckScore(int score1,int score2)
    {
        // プレーヤー1が勝利した場合
        if (score1 == MatchPoint)
        {
            AudioManager.PlaySound(Constans.END_GAME_SE);
            this.JudagePanel.transform.localPosition = new Vector3(0, 0, 0);
            this.JudagePanel.transform.Rotate(0, 0, 180);
            Destroy(this.Ball);
        }
        else if (score2 == MatchPoint)
        {
            AudioManager.PlaySound(Constans.END_GAME_SE);
            this.JudagePanel.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(this.Ball);
        }
    }
    
    /// <summary>
    /// コンテニューパネルの表示
    /// </summary>
    public void CountinuePanelDisplay() {

        this.AgainPanel.transform.localPosition = new Vector3(0, 0, 0);

        Destroy(this.JudagePanel);
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
}
