using UnityEngine;
using System.Collections;
using Common;

public class PlayerController : MonoBehaviour, IRefrectableBall
{
    /// <summary>ゲームディレクター</summary>
    //public GameDirector GameDirector;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>移動速度</summary>
    private float speed = 0.0f;
    /// <summary>上に移動ボタン押下判別</summary>
    private bool isMoveUp = false;
    /// <summary>下に移動ボタン押下判別</summary>
    private bool isMoveDown = false;
    /// <summary>1プレイヤーのタイプ </summary>
    public static int OnePlayerType;
    /// <summary>2プレイヤーのタイプ</summary>
    public static int TwoPlayerType;

    void Start()
    {
        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;

        // 選択肢タイプの高さ
        int selectTypeHeight = 0;

        // オブジェクト名を判別
        if (this.gameObject.name == "Player1")
        {

            // キャラタイプの判別
            if (OnePlayerType == Common.CharaType.NORMAL)
            {
                // ノーマルタイプの場合
                selectTypeHeight = Common.Constans.NORMAL_TYPE_HEIGHT;
                speed = Common.Constans.NORMAL_TYPE_SPEED;
            }
            else if (OnePlayerType == Common.CharaType.SPEED)
            {
                // スピードタイプの場合
                selectTypeHeight = Common.Constans.SPEED_TYPE_HEIGHT;
                speed = Common.Constans.SPEED_TYPE_SPEED;
            }
            else if (OnePlayerType == Common.CharaType.WIDE)
            {
                // ワイドタイプの場合
                selectTypeHeight = Common.Constans.WIDE_TYPE_HEIGHT;
                speed = Common.Constans.WIDE_TYPE_SPEED;
            }

        }
        else if (this.gameObject.name == "Player2")
        {
            // キャラタイプの判別
            if (TwoPlayerType == Common.CharaType.NORMAL)
            {
                // ノーマルタイプの場合
                selectTypeHeight = Common.Constans.NORMAL_TYPE_HEIGHT;
                speed = Common.Constans.NORMAL_TYPE_SPEED;
            }
            else if (TwoPlayerType == Common.CharaType.SPEED)
            {
                // スピードタイプの場合
                selectTypeHeight = Common.Constans.SPEED_TYPE_HEIGHT;
                speed = Common.Constans.SPEED_TYPE_SPEED;
            }
            else if (TwoPlayerType == Common.CharaType.WIDE)
            {
                // ワイドタイプの場合
                selectTypeHeight = Common.Constans.WIDE_TYPE_HEIGHT;
                speed = Common.Constans.WIDE_TYPE_SPEED;
            }
        }

        // プレイヤーオブジェクトのサイズを取得
        var playerSize = this.gameObject.GetComponent<RectTransform>().sizeDelta;
        var playerBoxCollderSize = this.gameObject.GetComponent<BoxCollider2D>().size;

        // サイズの代入
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(playerSize.x, selectTypeHeight);
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(playerBoxCollderSize.x, selectTypeHeight);
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
        if (this.transform.localPosition.y >= Common.Constans.PLAYER_MAX_YPOSITION)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, Common.Constans.PLAYER_MAX_YPOSITION - 5, 0);
        }
        else if (this.transform.localPosition.y <= Common.Constans.PLAYER_MIN_YPOSITION)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, Common.Constans.PLAYER_MIN_YPOSITION + 5, 0);
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
            BallController.BallXRange = BallController.BallXRange * -1 - Common.Constans.BALL_ADD_SPEAD;
        }
        else
        {
            // ボールを反射かつ加速する
            BallController.BallXRange = BallController.BallXRange * -1 + Common.Constans.BALL_ADD_SPEAD;
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
        audioManager.PlaySound(Common.SoundName.BOUNCE_BALL_SE);
    }
}
