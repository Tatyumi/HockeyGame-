using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGenerator : MonoBehaviour {


    GameObject playerText1;
    GameObject playerText2;
    GameObject judagePanel;
    GameObject againPanel;
    GameObject ball;
    /// <summary>プレイヤー1のスコア</summary>
    public int score1;
    /// <summary>プレイヤー2のスコア</summary>
    public int score2;
    /// <summary>目標スコア</summary>
    public int mNum;

    // Use this for initialization
    void Start () {
        this.playerText1 = GameObject.Find("Player1Score");
        this.playerText2 = GameObject.Find("Player2Score");
        this.judagePanel = GameObject.Find("JudagePanel");
        this.againPanel = GameObject.Find("AgainPanel");
        this.ball = GameObject.Find("Ball");

        this.playerText1.GetComponent<Text>().text = "1P Score:" + score1.ToString();
        this.playerText2.GetComponent<Text>().text = "2P Score:" + score2.ToString();
        score1 = 0;
        score2 = 0;
        mNum = TitleDirector.matchNum;
    }
	
    /// <summary>
    /// プレイヤー１のスコア加算
    /// </summary>
	public void addScore_p1()
    {
        score1 += 1;
        this.playerText1.GetComponent<Text>().text = "1P Score:" + score1.ToString();
        judage(score1,score2);
    }

    /// <summary>
    /// プレイヤー2のスコア加算
    /// </summary>
    public void addScore_p2()
    {
        score2 += 1;
        this.playerText2.GetComponent<Text>().text = "2P Score:" + score2.ToString();
        judage(score1,score2);
    }

    /// <summary>
    /// 両スコアが目標スコアに達した時の判定処理
    /// </summary>
    /// <param name="score1"></param>
    /// <param name="score2"></param>
    public void judage(int score1,int score2)
    {
        // プレーヤー1が勝利した場合
        if (score1 == mNum)
        {
            this.judagePanel.transform.localPosition = new Vector3(0, 0, 0);
            this.judagePanel.transform.Rotate(0, 0, 180);
            Destroy(this.ball);
        }
        else if (score2 == mNum)
        {
            this.judagePanel.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(this.ball);
        }
    }
    
    /// <summary>
    /// コンテニューパネルの表示
    /// </summary>
    public void againMove() {

        this.againPanel.transform.localPosition = new Vector3(0, 0, 0);

        Destroy(this.judagePanel);
    }
    
    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void titleMove()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// VSシーンに遷移
    /// </summary>
    public void playAgain()
    {
        SceneManager.LoadScene("VsScene");
    }
}
