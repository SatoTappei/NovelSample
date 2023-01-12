using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// CSVからデータを文字列に変換して保持しておくクラス
/// </summary>
public class Converter : MonoBehaviour
{
    readonly int QueueCap = 4;

    [Header("CSV形式の台本")]
    [SerializeField] TextAsset _csvAsset;

    Queue<ConvertData> _dataQueue;

    void Awake()
    {
        _dataQueue = new Queue<ConvertData>(QueueCap);
        Convert();
    }

    /// <summary>変換後のデータを取得する</summary>
    public ConvertData GetConvertData() => _dataQueue.Count != 0 ? _dataQueue.Dequeue() : null;

    /// <summary>CSVファイルのデータを変換してキューに格納する</summary>
    void Convert()
    {
        using (StringReader reader = new StringReader(_csvAsset.text))
        {
            while (reader.Peek() > -1)
            {
                string[] split = reader.ReadLine().Split(',');

                _dataQueue.Enqueue(new ConvertData(split));
            }
        }
    }
}
