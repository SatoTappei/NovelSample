using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

/// <summary>
/// イベントの登録/実行を行うクラス
/// </summary>
public class NovelEventBuilder : MonoBehaviour
{
    [Serializable]
    public class EventData
    {
        [SerializeField] string _id;
        [SerializeField] NovelEvent _event;

        public string Id { get => _id; }
        public NovelEvent Event { get => _event; }
    }
    /// <summary>動的に引数を渡すので継承させて使う</summary>
    [Serializable]
    public class NovelEvent : UnityEvent<string> { }

    [Header("IDとイベントを紐づける")]
    [SerializeField] EventData[] _eventDataArr;
    [Header("イベント同士を区切る文字")]
    [SerializeField] char _eventSeparator = ';';
    [Header("イベントIDと引数を区切る文字")]
    [SerializeField] char _argSeparator = ':';

    /// <summary>IDに対応したイベントを登録する辞書</summary>
    Dictionary<string, NovelEvent> _eventDic;

    void Awake()
    {
        _eventDic = _eventDataArr.ToDictionary(ed => ed.Id, ed => ed.Event);
    }

    /// <summary>文字列をイベントに変換する</summary>
    public void ConvertEvent(string str)
    {
        if (str == string.Empty) return;

        // 各イベントに区切る
        string[] split = str.Split(_eventSeparator);
        for(int i = 0; i < split.Length; i++)
        {
            // 引数がある場合は更に分割する
            int argSymbol = split[i].IndexOf(_argSeparator);
            if (argSymbol >= 0)
            {
                string key = split[i].Substring(0, argSymbol);
                string arg = split[i].Substring(argSymbol + 1);
                Execute(key, arg);
            }
            else
            {
                string key = split[i];
                Execute(key);
            }
        }
    }

    /// <summary>指定したイベントを実行する</summary>
    void Execute(string key, string arg = null)
    {
        if (_eventDic.TryGetValue(key, out NovelEvent value))
        {
            value.Invoke(arg);
        }
        else
        {
            Debug.LogWarning("対応するイベントが登録されていません: " + key);
        }
    }
}
