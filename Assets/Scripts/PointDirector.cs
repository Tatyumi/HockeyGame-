using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PointDirector : MonoBehaviour {

    /// <summary>プレイヤーポイントオブジェクト</summary>
    public GameObject PointScore;
    /// <summary>プレイヤー1ポイントテキスト</summary>
    private Text player1PointText;
    /// <summary>プレイヤーポイント</summary>
    private int playerPoint;
    /// <summary>目標ポイント</summary>
    public int MatchPoint;

    private void Awake()
    {
        player1PointText = PointScore.GetComponent<Text>();
    }

    private void Start()
    {
        // ポイントの初期化
        playerPoint = 0;
        player1PointText.text = playerPoint.ToString();
        // タイトルシーンで指定したポイントを取得
        MatchPoint = SettingPanelController.MatchPoint;
    }

    /// <summary>
    /// ポイント加算処理
    /// </summary>
    public void AddPoint()
    {
        playerPoint++;
        player1PointText.text = playerPoint.ToString();
    }

    /// <summary>
    /// プレイヤーのポイントが目標ポイントに達したか確認
    /// </summary>
    public bool IsCheckPoint()
    {
        return playerPoint == MatchPoint;
    }
}
