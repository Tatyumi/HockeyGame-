using UnityEngine;
using System.Collections;
using Common;

public class BallController : MonoBehaviour
{
    /// <summary>ボールの縦軸の角度</summary>
    public float BallXRange;
    /// <summary>ボールの横軸の角度</summary>
    public float BallYRange;
    /// <summary>ボール生成オブジェクト</summary>
    public GameObject PlayGenerator;
    /// <summary>ゲームディレクター</summary>
    public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    //GameObject generator = GameObject.Find("PlayGenerator");
    private void Awake()
    {
    }

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
            //x軸に方向の反転
            BallXRange = BallXRange * -1 + 2.0f;
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
            //x軸に方向の反転
            BallXRange = BallXRange * -1 - 2.0f;
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
            //y軸の方向の反転
            BallYRange *= -1;
        }
        else if (other.gameObject.tag == "Goal1")
        {
            PlayGenerator.GetComponent<GameDirector>().AddScore_p2();
            GameDirector.StartGame();
        }
        else if (other.gameObject.tag == "Goal2")
        {
            PlayGenerator.GetComponent<GameDirector>().AddScore_p1();
            GameDirector.StartGame();
        }
    }
}
