using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

/// <summary>
/// �C�x���g�̓o�^/���s���s���N���X
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
    /// <summary>���I�Ɉ�����n���̂Ōp�������Ďg��</summary>
    [Serializable]
    public class NovelEvent : UnityEvent<string> { }

    [Header("ID�ƃC�x���g��R�Â���")]
    [SerializeField] EventData[] _eventDataArr;
    [Header("�C�x���g���m����؂镶��")]
    [SerializeField] char _eventSeparator = ';';
    [Header("�C�x���gID�ƈ�������؂镶��")]
    [SerializeField] char _argSeparator = ':';

    /// <summary>ID�ɑΉ������C�x���g��o�^���鎫��</summary>
    Dictionary<string, NovelEvent> _eventDic;

    void Awake()
    {
        _eventDic = _eventDataArr.ToDictionary(ed => ed.Id, ed => ed.Event);
    }

    /// <summary>��������C�x���g�ɕϊ�����</summary>
    public void ConvertEvent(string str)
    {
        if (str == string.Empty) return;

        // �e�C�x���g�ɋ�؂�
        string[] split = str.Split(_eventSeparator);
        for(int i = 0; i < split.Length; i++)
        {
            // ����������ꍇ�͍X�ɕ�������
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

    /// <summary>�w�肵���C�x���g�����s����</summary>
    void Execute(string key, string arg = null)
    {
        if (_eventDic.TryGetValue(key, out NovelEvent value))
        {
            value.Invoke(arg);
        }
        else
        {
            Debug.LogWarning("�Ή�����C�x���g���o�^����Ă��܂���: " + key);
        }
    }
}
