using UnityEngine;
using System.Collections;
using Common;


public class BallController : MonoBehaviour
{
    /// <summary>ボールの縦軸の角度</summary>
    public float BallXRange;
    /// <summary>ボールの横軸の角度</summary>
    public float BallYRange;
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
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {


        //衝突したオブジェクトの判別
        if (other.gameObject.tag == "Player1")
        {
            audioManager.PlaySound(Constans.BOUNCE_BALL_SE);

            // プレイヤー2の方向にボールに速度を加えて反射
            BallXRange = BallXRange * -1 + 2.0f;

            // 反射角が垂直にならないように角度を付ける
            if (this.transform.localPosition.y > 0)
            {
                BallYRange += 1;
            }
            else if (this.transform.localPosition.y < 0)
            {
                BallYRange -= 1;
            }
        }
        else if (other.gameObject.tag == "Player2")
        {
            audioManager.PlaySound(Constans.BOUNCE_BALL_SE);

            // プレイヤー1の方向にボールに速度を加えて反射
            BallXRange = BallXRange * -1 - 2.0f;

            // 反射角が垂直にならないように角度を付ける
            if (this.transform.localPosition.y > 0)
            {
                BallYRange += 1;
            }
            else if (this.transform.localPosition.y < 0)
            {
                BallYRange -= 1;
            }
        }
        else if (other.gameObject.tag == "Wall")
        {
            audioManager.PlaySound(Constans.BOUNCE_BALL_SE);

            // y軸の方向にボールを反転
            BallYRange *= -1;
        }
        else if (other.gameObject.tag == "Goal1")
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
    }
}
