using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    /// <summary>ボールの縦軸の角度</summary>
    public float BallXRange;
    /// <summary>ボールの横軸の角度</summary>
    public float BallYRange;
    /// <summary>ボール生成オブジェクト</summary>
    public GameObject PlayGenerator;
    /// <summary>スタートパネル</summary>
    public GameObject StartPanel;

    //GameObject generator = GameObject.Find("PlayGenerator");
    void Start()
    {
        //スタートパネルのの初期位置
        this.StartPanel.transform.localPosition = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void GameStart()
    {
        //ボール初期位置に配置
        this.transform.localPosition = new Vector3(0, 0, 0);
        //ボールの移動方向
        BallXRange = Random.Range(-8, 8);
        BallYRange = Random.Range(-8, 8);
        
        if (-2 < BallXRange && BallXRange < 2)
        {
            GameStart();
        }
        else if (-2 < BallXRange && BallXRange < 2)
        {
            GameStart();
        }
        this.StartPanel.transform.localPosition = new Vector3(0, 450, 0);
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
        {//y軸の方向の反転
            BallYRange *= -1;
        }
        else if (other.gameObject.tag == "Goal1")
        {
            PlayGenerator.GetComponent<PlayGenerator>().AddScore_p2();
            GameStart();
        }
        else if (other.gameObject.tag == "Goal2")
        {
            PlayGenerator.GetComponent<PlayGenerator>().AddScore_p1();
            GameStart();
        }
    }
}
