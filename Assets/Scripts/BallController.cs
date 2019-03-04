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

    void Update()
    {
        // ボール移動
        this.transform.Translate(BallXRange, BallYRange, 0);
    }

    /// <summary>
    /// 衝突したオブジェクトの判別
    /// </summary>
    /// <param name="other">衝突したオブジェクト</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトを判別
        if (other.gameObject.tag == "Goal")
        {
            var obj = other.gameObject.GetComponent<ScoreDirector>();
            
            // 存在チェック
            if (obj != null)
            {
                // スコア加算
                obj.AddScore();

                //　目標スコアに達したか判別
                if (obj.IsCheckScore())
                {
                    // ゲーム終了処理
                    Debug.Log("ゲーム終了");
                }
                else
                {
                    // ゲーム再スタート
                    GameDirector.StartGame();
                }
            }
        }
        else
        {
            var obj = other.gameObject.GetComponent<IRefrectableBall>();

            // 存在チェック
            if (obj != null)
            {
                // ボール反射処理
                obj.RefrectBall();
            }

            // Y軸角度が0の場合
            if (BallYRange == 0)
            {
                BallYRange += 3;
            }
        }
    }
}
