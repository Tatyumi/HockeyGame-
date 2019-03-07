using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonConstans;

public class WallController : MonoBehaviour, IRefrectableBall
{
    /// <summary>ゲームディレクター</summary>
    public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameDirector.AudioManager;
    }

    /// <summary>
    /// ボールを反射する
    /// </summary>
    public void RefrectBall()
    {
        // y軸の方向にボールを反転
        BallController.BallYRange *= -1;

        // 反射SEを再生
        audioManager.PlaySound(CommonConstans.SoundName.BOUNCE_BALL_SE);
    }
}
