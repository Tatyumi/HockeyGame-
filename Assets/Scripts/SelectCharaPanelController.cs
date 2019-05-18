using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharaPanelController : MonoBehaviour
{
    /// <summary>ガイドテキストオブジェクト</summary>
    public GameObject GuideText;
    /// <summary>セレクトモード</summary>
    private int selectMode = 0;
    /// <summary>ガイドテキスト</summary>
    private Text guideText;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    /// <summary>
    /// セレクトモード
    /// </summary>
    enum SelectMode
    {
        None,
        OnePlayer,  // プレイヤー1選択中
        TwoPlayer   // プレイヤー2選択中
    }

    private void Awake()
    {
        // ガイドテキストのテキストコンプーネントを取得
        guideText = GuideText.GetComponent<Text>();
        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;
    }

    // Use this for initialization
    void Start()
    {
        // 初期化
        selectMode = (int)SelectMode.OnePlayer;
        guideText.text = "1P SELECT!";
    }


    /// <summary>
    /// キャラのタイプを決定する
    /// </summary>
    /// <param name="charaType"></param>
    public void SetCharaType(int charaType)
    {
        // SE再生
        audioManager.PlaySound(Common.SoundName.TAP_BUTTON_SE);

        // 選択しているプレイヤーの判別
        if (selectMode == (int)SelectMode.OnePlayer)
        {
            // プレイヤー１のキャラタイプを選択
            PlayerController.OnePlayerType = charaType;

            // セレクトモードをプレイヤー2に変更
            selectMode = (int)SelectMode.TwoPlayer;
            guideText.text = "2P SELECT!";
        }
        else if (selectMode == (int)SelectMode.TwoPlayer)
        {
            // プレイヤー2のキャラタイプを選択
            PlayerController.TwoPlayerType = charaType;

            // セレクトモードをプレイヤー1に変更
            selectMode = (int)SelectMode.OnePlayer;
            guideText.text = "1P SELECT!";

            // VSシーンに遷移
            SceneManager.LoadScene(Common.SceneName.VS_SCENE_NAME);

            // 音の停止
            audioManager.StopSound();
        }
    }
}
