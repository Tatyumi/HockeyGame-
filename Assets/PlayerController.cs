using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
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

}
