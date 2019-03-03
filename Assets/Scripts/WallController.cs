using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour, IRefrectableBall
{

    /// <summary>
    /// ボールを反射する
    /// </summary>
    public void RefrectBall()
    {
        Debug.Log("壁に当たった");
        // y軸の方向にボールを反転
        BallController.BallYRange *= -1;
    }
}
