using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
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
        public const string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>VSシーン名</summary>
        public const string VS_SCENE_NAME = "VsScene";
    }

    // オブジェクト名
    public static class ObjectName
    {
        /// <summary>オーディオマネージャー</summary>
        public const string AUDIO_MANAGER = "AudioManager";
    }

    // 定数
    public static class Constans
    {
        /// <summary>ボール反射時の加速度</summary>
        public const float BALL_ADD_SPEAD = 2.0f;
        /// <summary>ノーマルタイプのキャラサイズ</summary>
        public const int NORMAL_TYPE_HEIGHT = 160;
        /// <summary>スピードタイプのキャラサイズ</summary>
        public const int SPEED_TYPE_HEIGHT = 100;
        /// <summary>ワイドタイプのキャラサイズ</summary>
        public const int WIDE_TYPE_HEIGHT = 360;
        /// <summary>ノーマルタイプのキャラスピード</summary>
        public const float NORMAL_TYPE_SPEED = 15.0f;
        /// <summary>スピードタイプのキャラスピード</summary>
        public const float SPEED_TYPE_SPEED = 30.0f;
        /// <summary>ワイドタイプのキャラスピード</summary>
        public const float WIDE_TYPE_SPEED = 6.0f;
    }

    // キャラクタータイプ
    public static class CharaType
    {
        /// <summary>ノーマルタイプ</summary>
        public const int NORMAL = 1;
        /// <summary>スピードタイプ</summary>
        public const int SPEED = 2;
        /// <summary>ワイドタイプ</summary>
        public const int WIDE = 3;
    }
}