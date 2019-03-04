using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class ScoreDirector : MonoBehaviour {

    /// <summary>プレイヤースコアオブジェクト</summary>
    public GameObject PlayerScore;
    /// <summary>プレイヤー1スコアテキスト</summary>
    private Text player1ScoreText;
    /// <summary>プレイヤースコア</summary>
    private int playerScore;
    /// <summary>目標スコア</summary>
    public int MatchScore;

    private void Awake()
    {
        player1ScoreText = PlayerScore.GetComponent<Text>();
    }

    private void Start()
    {
        // スコアの初期化
        playerScore = 0;
        player1ScoreText.text = playerScore.ToString();
        // タイトルシーンで指定したスコアを取得
        MatchScore = TitleDirector.MatchPoint;
    }

    /// <summary>
    /// スコア加算処理
    /// </summary>
    public void AddScore()
    {
        playerScore++;
        player1ScoreText.text = playerScore.ToString();
    }

    /// <summary>
    /// プレイヤーのスコアが目標スコアに達したか確認
    /// </summary>
    public bool IsCheckScore()
    {
        return playerScore == MatchScore;
    }
}
