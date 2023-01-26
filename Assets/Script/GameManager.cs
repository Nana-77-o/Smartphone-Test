using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer _playerSp = null;
    [SerializeField] Sprite[] _playersSp = null;
    int _playerIndex = 0;

    void Start()
    {
        _playerIndex = SelectPlayer.Instance.PlayerIndex;
        for(var i = 0; i < _playersSp.Length; i++)
        {
            if(i == _playerIndex)
            {
                _playerSp.sprite = _playersSp[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
