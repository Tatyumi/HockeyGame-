using UnityEngine;
using System.Collections;
using CommonConstans;

public class PlayerController : MonoBehaviour, IRefrectableBall
{
    /// <summary>ゲームディレクター</summary>
    public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>移動速度</summary>
    private float speed = 10.0f;
    /// <summary>上に移動ボタン押下判別</summary>
    private bool isMoveUp = false;
    /// <summary>下に移動ボタン押下判別</summary>
    private bool isMoveDown = false;

    void Start()
    {
        audioManager = GameDirector.AudioManager;
    }

    void Update()
    {
        //上に移動ボタンが押されている場合
        if (isMoveUp)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
        }

        //下に移動ボタンが押されている場合
        if (isMoveDown)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
        }

        //プレイヤーのY座標が既定の範囲内か判別
        if (this.transform.localPosition.y >= CommonConstans.Value.PLAYER_MAX_YPOSITION)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, CommonConstans.Value.PLAYER_MAX_YPOSITION - 5, 0);
        }
        else if (this.transform.localPosition.y <= CommonConstans.Value.PLAYER_MIN_YPOSITION)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, CommonConstans.Value.PLAYER_MIN_YPOSITION + 5, 0);
        }
    }

    /// <summary>
    /// 上に移動ボタンを押す
    /// </summary>
    public void PushDownMoveUp()
    {
        isMoveUp = true;
    }

    /// <summary>
    /// 上に移動ボタンを離す
    /// </summary>
    public void PushUpMoveUp()
    {
        isMoveUp = false;
    }

    /// <summary>
    /// 下に移動ボタンを押す
    /// </summary>
    public void PushDownMoveDown()
    {
        isMoveDown = true;
    }

    /// <summary>
    /// 下に移動ボタンを離す
    /// </summary>
    public void PushUpMoveDown()
    {
        isMoveDown = false;
    }

    /// <summary>
    /// ボールを反射する
    /// </summary>
    public void RefrectBall()
    {
        // ボールの進行方向を判別
        if (BallController.BallXRange > 0)
        {
            // ボールを反射かつ加速する
            BallController.BallXRange = BallController.BallXRange * -1 - CommonConstans.Value.BALL_ADD_SPEAD;
        }
        else
        {
            // ボールを反射かつ加速する
            BallController.BallXRange = BallController.BallXRange * -1 + CommonConstans.Value.BALL_ADD_SPEAD;
        }

        // 反射角が垂直か判別
        if (this.transform.localPosition.y > 0)
        {
            BallController.BallYRange += 1;
        }
        else if (this.transform.localPosition.y < 0)
        {
            BallController.BallYRange -= 1;
        }

        // 反射SEを再生
        audioManager.PlaySound(CommonConstans.SoundName.BOUNCE_BALL_SE);
    }
}
