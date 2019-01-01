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

    public int score1;
    public int score2;
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
	
    // プレイヤー1にスコア加算
	public void addScore_p1()
    {
        score1 += 1;
        this.playerText1.GetComponent<Text>().text = "1P Score:" + score1.ToString();
        judage(score1,score2);
    }

    // プレイヤー2にスコア加算
    public void addScore_p2()
    {
        score2 += 1;
        this.playerText2.GetComponent<Text>().text = "2P Score:" + score2.ToString();
        judage(score1,score2);
    }

    // 勝敗判定
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
        //this.judagePanel.transform.localPosition = new Vector3(0, 0, 0);


    }

    // アゲインパネル表示
    public void againMove() {

        this.againPanel.transform.localPosition = new Vector3(0, 0, 0);

        Destroy(this.judagePanel);
    }

    // タイトル画面に遷移
    public void titleMove()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // ゲーム再プレイ
    public void playAgain()
    {
        SceneManager.LoadScene("VsScene");
    }
}
