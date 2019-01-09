using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    /// <summary></summary>
    public float xR;
    /// <summary></summary>
    public float yR;
    /// <summary>ボール生成オブジェクト</summary>
    GameObject generator;
    /// <summary>開始ボタン</summary>
    GameObject startButton;

    //GameObject generator = GameObject.Find("PlayGenerator");
    void Start()
    {
        this.generator = GameObject.Find("PlayGenerator");
        this.startButton = GameObject.Find("StartPanel");

        this.startButton.transform.localPosition = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void GameStart()
    {
        //ボール初期位置に配置
        this.transform.localPosition = new Vector3(0, 0, 0);
        //ボールの移動方向
        xR = Random.Range(-8, 8);
        yR = Random.Range(-8, 8);
        
        if (-2 < xR && xR < 2)
        {
            GameStart();
        }
        else if (-2 < xR && xR < 2)
        {
            GameStart();
        }
        this.startButton.transform.localPosition = new Vector3(0, 450, 0);
    }

    void Update()
    {
        this.transform.Translate(xR, yR, 0);

        //Y方向の移動量が0の場合
        if (yR == 0)
        {
            yR += 3;
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
            //x軸に方向の反転
            xR = xR * -1 + 2.0f;
            if (this.transform.localPosition.y > 0)
            {
                yR += 1;
            }
            else if (this.transform.localPosition.y < 0)
            {
                yR -= 1;
            }
        }
        else if (other.gameObject.tag == "Player2")
        {
            //x軸に方向の反転
            xR = xR * -1 - 2.0f;
            if (this.transform.localPosition.y > 0)
            {
                yR += 1;
            }
            else if (this.transform.localPosition.y < 0)
            {
                yR -= 1;
            }
        }
        else if (other.gameObject.tag == "Wall")
        {//y軸の方向の反転
            yR *= -1;
        }
        else if (other.gameObject.tag == "Goal1")
        {
            generator.GetComponent<PlayGenerator>().addScore_p2();
            GameStart();
        }
        else if (other.gameObject.tag == "Goal2")
        {
            generator.GetComponent<PlayGenerator>().addScore_p1();
            GameStart();
        }
    }
}
