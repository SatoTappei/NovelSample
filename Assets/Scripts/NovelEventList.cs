using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �C�x���g�̏������܂Ƃ߂��N���X
/// </summary>
public class NovelEventList : MonoBehaviour
{
    public void SetActorFrame(string fileName)
    {
        Debug.Log(fileName + "��\�����܂�");
    }

    public void DeleteActorFrame()
    {
        Debug.Log("�L�����������܂�");
    }

    public void Particle()
    {
        Debug.Log("�p�[�e�B�N�����o���܂�");
    }
}
