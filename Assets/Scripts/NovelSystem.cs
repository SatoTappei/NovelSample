using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// �e���W���[���𐧌䂷��N���X
/// </summary>
public class NovelSystem : MonoBehaviour
{
    [SerializeField] Converter _converter;
    [SerializeField] NovelEventBuilder _novelEventBuilder;
    [Header("�\���p��UI")]
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

        Debug.Log("�V�i���I�I��");
    }
}