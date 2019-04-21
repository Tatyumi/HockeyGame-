using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class WallController : MonoBehaviour, IRefrectableBall
{
    /// <summary>ゲームディレクター</summary>
    public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    void Start()
    {
        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// ボールを反射する
    /// </summary>
    public void RefrectBall()
    {
        // y軸の方向にボールを反転
        BallController.BallYRange *= -1;

        // 反射SEを再生
        audioManager.PlaySound(Common.SoundName.BOUNCE_BALL_SE);
    }
}
