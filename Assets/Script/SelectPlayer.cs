using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SelectPlayer : MonoBehaviour
{
    private static SelectPlayer instance;

    [SerializeField, Tooltip("���ɑJ�ڂ���V�[���̖��O")] string _nextStage = null;
    [SerializeField, Tooltip("GameStartTextObj")] GameObject _textObj = null;

    private int _playerIndex;
    /// <summary>
    /// �I�񂾃v���C���[�̔ԍ�
    /// </summary>
    public int PlayerIndex { get => _playerIndex; set => _playerIndex = value; }
    public static SelectPlayer Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }
    public void Players(int playerNum)
    {
        _playerIndex = playerNum;
        _textObj.SetActive(true);
    }

    public void GameStartButton()
    {
        SceneChenge.Instance.ChengeScene(_nextStage);
    }
}
