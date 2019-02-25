using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オーディオ管理クラス．シングルトン．
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    AudioSource audioSource;
    /// <summary>タイトルシーンのBGM</summary>
    public AudioClip TitleSceneBGM;
    /// <summary>プレイシーンのBGM</summary>
    public AudioClip VsSceneBGM;
    /// <summary>ボール反射SE</summary>
    public AudioClip BounceBallSE;
    /// <summary>ゲーム開始SE</summary>
    public AudioClip StartGameSE;
    /// <summary>ゲーム終了SE</summary>
    public AudioClip EndGameSE;
    /// <summary>ボタンタップSE</summary>
    public AudioClip TapButtonSE;
    /// <summary>ゴールSE</summary>
    public AudioClip GoalSE;

    /// <summary>全オウディオ保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> AudioDic;

    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        //シーンが遷移しても破棄されない
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.GetComponent<AudioSource>();

        // オウディオを格納
        AudioDic = new Dictionary<string, AudioClip> {
            { TitleSceneBGM.name, TitleSceneBGM},
            { VsSceneBGM.name, VsSceneBGM },
            { BounceBallSE.name, BounceBallSE },
            { StartGameSE.name, StartGameSE },
            { EndGameSE.name, EndGameSE },
            {TapButtonSE.name, TapButtonSE},
            {GoalSE.name, GoalSE},
        };
    }
    

    /// <summary>
    /// 音を流す
    /// </summary>
    /// <param name="soundName">音の名前</param>
    public void PlaySound(string soundName)
    {
        // 名前のチェック
        if (!AudioDic.ContainsKey(soundName))
        {
            Debug.Log(soundName + "という名前のSEがありません");
            return;
        }
        audioSource.PlayOneShot(AudioDic[soundName]);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopSound()
    {
        audioSource.Stop();
    }
    
}
