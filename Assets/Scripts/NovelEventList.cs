using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イベントの処理をまとめたクラス
/// </summary>
public class NovelEventList : MonoBehaviour
{
    public void SetActorFrame(string fileName)
    {
        Debug.Log(fileName + "を表示します");
    }

    public void DeleteActorFrame()
    {
        Debug.Log("キャラを消します");
    }

    public void Particle()
    {
        Debug.Log("パーティクルを出します");
    }
}
