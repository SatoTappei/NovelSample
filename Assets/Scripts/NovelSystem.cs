using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// 各モジュールを制御するクラス
/// </summary>
public class NovelSystem : MonoBehaviour
{
    [SerializeField] Converter _converter;
    [SerializeField] NovelEventBuilder _novelEventBuilder;
    [Header("表示用のUI")]
    [SerializeField] Text _nameText;
    [SerializeField] Text _lineText;

    async UniTaskVoid Start()
    {
        while (true)
        {
            ConvertData data = _converter.GetConvertData();
            
            if (data == null) break;

            _nameText.text = data.Name;
            _lineText.text = data.Line;
            _novelEventBuilder.ConvertEvent(data.Event);

            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0), cancellationToken: this.GetCancellationTokenOnDestroy());
        }

        Debug.Log("シナリオ終了");
    }
}