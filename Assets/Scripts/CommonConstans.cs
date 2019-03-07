using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonConstans
{
    //サウンド名
    public static class SoundName
    {
        /// <summary>タイトルシーンのBGM名</summary>
        public const string TITLE_SCENE_BGM = "TitleSceneBGM";
        /// <summary>プレイシーンのBGM名</summary>
        public const string VS_SCENE_BGM = "VsSceneBGM";
        /// <summary>ボール反射SE名</summary>
        public const string BOUNCE_BALL_SE = "BounceBallSE";
        /// <summary>ゲーム開始SE名</summary>
        public const string START_GAME_SE = "StartGameSE";
        /// <summary>ゲーム終了SE名</summary>
        public const string END_GAME_SE = "EndGameSE";
        /// <summary>タップボタンSE名</summary>
        public const string TAP_BUTTON_SE = "TapButtonSE";
        /// <summary>ゴールSE名</summary>
        public const string GOAL_SE = "GoalSE";

    }

    // シーン名
    public static class SceneName
    {
        /// <summary>タイトルシーン名</summary>
        public static string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>VSシーン名</summary>
        public static string VS_SCENE_NAME = "VsScene";
    }

    // オブジェクト名
    public static class ObjectName
    {
        /// <summary>オーディオマネージャー</summary>
        public static string AUDIO_MANAGER = "AudioManager";
    }

    // 値
    public static class Value
    {
        /// <summary>ボール反射時の加速度</summary>
        public static float BALL_ADD_SPEAD = 2.0f;
        /// <summary>プレイヤーのY座標上限値</summary>
        public static int PLAYER_MAX_YPOSITION = 185;
        /// <summary>プレイヤーのY座標下限値</summary>
        public static int PLAYER_MIN_YPOSITION = -185;
    }
}