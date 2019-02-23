using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    /// <summary>プレイヤー1のスコア</summary>
    public int score1;
    /// <summary>プレイヤー2のスコア</summary>
    public int score2;
    /// <summary>目標スコア</summary>
    public int MatchPoint;

    // Use this for initialization
    void Start () {

        this.PlayerText1.GetComponent<Text>().text = "1P Score:" + score1.ToString();
        this.PlayerText2.GetComponent<Text>().text = "2P Score:" + score2.ToString();
        score1 = 0;
        score2 = 0;
        MatchPoint = TitleDirector.MatchPoint;
    }
	
    /// <summary>
    /// プレイヤー１のスコア加算
    /// </summary>
	public void AddScore_p1()
    {
        score1 += 1;
        this.PlayerText1.GetComponent<Text>().text = "1P Score:" + score1.ToString();
        CheckScore(score1,score2);
    }

    /// <summary>
    /// プレイヤー2のスコア加算
    /// </summary>
    public void AddScore_p2()
    {
        score2 += 1;
        this.PlayerText2.GetComponent<Text>().text = "2P Score:" + score2.ToString();
        CheckScore(score1,score2);
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
            this.JudagePanel.transform.localPosition = new Vector3(0, 0, 0);
            this.JudagePanel.transform.Rotate(0, 0, 180);
            Destroy(this.Ball);
        }
        else if (score2 == MatchPoint)
        {
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
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// VSシーンに遷移
    /// </summary>
    public void VsSceneMove()
    {
        SceneManager.LoadScene("VsScene");
    }
}
