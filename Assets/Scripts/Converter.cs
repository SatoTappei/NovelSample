using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// CSV����f�[�^�𕶎���ɕϊ����ĕێ����Ă����N���X
/// </summary>
public class Converter : MonoBehaviour
{
    readonly int QueueCap = 4;

    [Header("CSV�`���̑�{")]
    [SerializeField] TextAsset _csvAsset;

    Queue<ConvertData> _dataQueue;

    void Awake()
    {
        _dataQueue = new Queue<ConvertData>(QueueCap);
        Convert();
    }

    /// <summary>�ϊ���̃f�[�^���擾����</summary>
    public ConvertData GetConvertData() => _dataQueue.Count != 0 ? _dataQueue.Dequeue() : null;

    /// <summary>CSV�t�@�C���̃f�[�^��ϊ����ăL���[�Ɋi�[����</summary>
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
