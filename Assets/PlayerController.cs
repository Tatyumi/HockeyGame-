using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    /// <summary>移動量</summary>
    private int move = 0;
    /// <summary>移動速度</summary>
    private float speed = 10.0f;


    // Update is called once per frame
    void Update () {

        switch (move)
        {
            case 1:
                this.transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
                break;

            case 2:
                this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
                break;
        }

        //プレイヤー1のY座標が185~-185外の場合
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
    /// プレイヤー1が上に移動
    /// </summary>
    public void UpMove() {
        move = 1;
    }

    /// <summary>
    /// プレイヤー1が下に移動
    /// </summary>
    public void DownMove()
    {
        move = 2;
    }

    /// <summary>
    /// プレイヤー1が停止
    /// </summary>
    public void ZeroMove()
    {
        move = 0;
    }
}
