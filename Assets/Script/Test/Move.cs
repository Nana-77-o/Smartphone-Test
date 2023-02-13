using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] 
    private float _jampForce = 5f;
    [SerializeField]
    private float _jampRot = 45f;
    [SerializeField]
    private Text _count = null;
    [SerializeField]
    private string _nextStage = null;

    private int _score = 0;
    private int _jampCount = 0;
    private Rigidbody rb = null;
    private bool _stay = true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _count.text = $"0";
    }

    
    void Update()
    {
        if (_jampCount < 2 && Input.GetMouseButtonDown(0))
        {
            _stay = false;
            if (_jampCount == 0)
            {
                rb.AddForce(new Vector2(0, _jampForce), ForceMode.Impulse);
            }
            else if (_jampCount == 1)
            {
                rb.AddForce(new Vector2(0, _jampForce/1.2f), ForceMode.Impulse);
            }
            _jampCount++;
        }
        if (_stay == false) 
        {
            transform.Rotate(0f, 0f, _jampRot * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _stay = true;
        if(collision.gameObject.CompareTag("Item"))
        {
            _score++;
            _count.text += _score;
            _jampCount = 0;
            collision.gameObject.tag = "CountEnd";
        }
        if(collision.gameObject.CompareTag("CountEnd")) { _stay = true; _jampCount = 0; }
        if(collision.gameObject.CompareTag("Ground"))
        {
            SceneChenge.Instance.ChengeScene(_nextStage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //_stay = false;
    }
}
