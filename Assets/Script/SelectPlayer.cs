using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public static SelectPlayer Instance { get; private set; }

    [SerializeField, Tooltip("次に遷移するシーンの名前")] string _nextStage = null;
    [SerializeField, Tooltip("GameStartTextObj")] GameObject _textObj = null;

    private int _playerIndex;
    /// <summary>
    /// 選んだプレイヤーの番号
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
