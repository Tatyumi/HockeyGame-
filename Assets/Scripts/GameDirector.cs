﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;

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
        AudioManager = GameObject.Find(Constans.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        // 各パネルを初期状態にする
        this.JudagePanel.SetActive(false);
        this.CountinuePanel.SetActive(false);
        this.StartPanel.SetActive(true);

        // タイトルシーンで指定したスコアを取得
        MatchPoint = TitleDirector.MatchPoint;

        // BGM再生
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

        // スタートパネルを非表示にする
        this.StartPanel.SetActive(false);
    }

    /// <summary>
    /// 両スコアが目標スコアに達した時の判定処理
    /// </summary>
    /// <param name="player1Score">プレイヤー1のスコア</param>
    /// <param name="player2Score">プレイヤー2のスコア</param>
    public void CheckScore(int player1Score, int player2Score)
    {
        // プレーヤー1が勝利した場合
        if (player1Score == MatchPoint)
        {
            AudioManager.PlaySound(Constans.END_GAME_SE);

            // プレイヤー１が勝利になるようにジャッジパネルを表示
            this.JudagePanel.SetActive(true);
            this.JudagePanel.transform.Rotate(0, 0, 180);

            Destroy(this.Ball);
        }
        else if (player2Score == MatchPoint)
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
    public void MoveTitleScene()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(Constans.TITLE_SCENE_NAME);
    }

    /// <summary>
    /// VSシーンに遷移
    /// </summary>
    public void MoveVsScene()
    {
        AudioManager.StopSound();
        SceneManager.LoadScene(Constans.VS_SCENE_NAME);
    }

    /// <summary>
    /// ボタンタップ処理
    /// </summary>
    public void PlayTapButtonSE()
    {
        AudioManager.PlaySound(Constans.TAP_BUTTON_SE);
    }
}
