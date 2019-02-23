using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    // 定数クラス
    public static class Constans
    {
        //サウンド名
        /// <summary>タイトルシーンのBGM名</summary>
        public const string TITLE_SCENE_BGM = "TitleSceneBGM";
        /// <summary>プレイシーンのBGM名</summary>
        public const string PLAY_SCENE_BGM = "PlaySceneBGM";
        /// <summary>ボール反射SE名</summary>
        public const string BOUNCE_BALL_SE = "BounceBallSE";
        /// <summary>ゲーム開始SE名</summary>
        public const string START_GAME_SE = "StartGameSE";
        /// <summary>ゲーム終了SE名</summary>
        public const string END_GAME_SE = "EndGameSE";

        // シーン名
        /// <summary>タイトルシーン名</summary>
        public static string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>VSシーン名</summary>
        public static string VS_SCENE_NAME = "VsScene";

        // オブジェクト名
        public static string AUDIO_MANAGER = "AudioManager";
    }
}