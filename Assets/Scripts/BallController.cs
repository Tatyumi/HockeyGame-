using UnityEngine;
using System.Collections;
using Common;


public class BallController : MonoBehaviour
{
    /// <summary>ボールの縦軸の角度</summary>
    public static float BallXRange;
    /// <summary>ボールの横軸の角度</summary>
    public static float BallYRange;
    /// <summary>ゲームディレクター</summary>
    public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameDirector.AudioManager;
    }

    void Update()
    {
        this.transform.Translate(BallXRange, BallYRange, 0);

        //Y方向の移動量が0の場合
        if (BallYRange == 0)
        {
            BallYRange += 3;
        }
    }

    /// <summary>
    /// 衝突したオブジェクトの判別
    /// </summary>
    /// <param name="other">衝突したオブジェクト</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal1")
        {
            // プレイヤー2にスコアを加算
            GameDirector.AddScore_p2();
            GameDirector.CheckScore(GameDirector.Player1Score, GameDirector.Player2Score);
            GameDirector.StartGame();
        }
        else if (other.gameObject.tag == "Goal2")
        {
            // プレイヤー1にスコアを加算
            GameDirector.AddScore_p1();
            GameDirector.CheckScore(GameDirector.Player1Score, GameDirector.Player2Score);
            GameDirector.StartGame();
        }
        else
        {
            audioManager.PlaySound(Constans.BOUNCE_BALL_SE);
            var obj = other.gameObject.GetComponent<IRefrectableBall>();
            if (obj != null)
            {
                obj.RefrectBall();
            }
        }
    }
}
