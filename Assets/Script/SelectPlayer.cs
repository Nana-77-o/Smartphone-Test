using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public static SelectPlayer Instance { get; private set; }

    [SerializeField, Tooltip("���ɑJ�ڂ���V�[���̖��O")] string _nextStage = null;
    [SerializeField, Tooltip("GameStartTextObj")] GameObject _textObj = null;

    private int _playerIndex;
    /// <summary>
    /// �I�񂾃v���C���[�̔ԍ�
    /// </summary>
    public int PlayerIndex { get => _playerIndex; set => _playerIndex = value; }

    public void Players(int playerNum)
    {
        _playerIndex = playerNum;
        _textObj.SetActive(true);
        Debug.Log(_playerIndex);
    }

    public void GameStartButton()
    {
        SceneChenge.Instance.ChengeScene(_nextStage);
    }
}
