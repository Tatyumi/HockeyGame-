using UnityEngine;
using System.Collections;
using Common;

public class PlayerController : MonoBehaviour, IRefrectableBall
{
    /// <summary>移動速度</summary>
    private float speed = 10.0f;
    /// <summary>上に移動ボタン押下判別</summary>
    private bool isMoveUp = false;
    /// <summary>下に移動ボタン押下判別</summary>
    private bool isMoveDown = false;

    // Update is called once per frame
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

        //プレイヤーのY座標が185~-185外の場合
        if (this.transform.localPosition.y >= 185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, 180, 0);
        }
        else if (this.transform.localPosition.y <= -185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, -180, 0);
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
        Debug.Log("プレイヤーに当たった");

        // ボールの進行方向を判別
        if (BallController.BallXRange > 0)
        {
            // ボールを反射かつ加速する
            BallController.BallXRange = BallController.BallXRange * -1 - Constans.ADD_SPEAD;
        }
        else
        {
            // ボールを反射かつ加速する
            BallController.BallXRange = BallController.BallXRange * -1 + Constans.ADD_SPEAD;
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
    }
}
