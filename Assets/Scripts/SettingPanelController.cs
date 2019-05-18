using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelController : MonoBehaviour {
    /// <summary>目標ポイント</summary>
    public static int MatchPoint = 0;

    /// <summary>
    /// 目標ポイントの設定
    /// </summary>
    /// <param name="selectedPoint">選択した目標ポイント</param>
    public void SetMatchPoint(int selectedPoint)
    {
        // 目標ポイントの取得
        MatchPoint = selectedPoint;

    }
}
