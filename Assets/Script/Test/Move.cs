using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] float jampX = 3f, jampForce = 5f;
    //[SerializeField]
    //Text count;
    //int countItem;
    Rigidbody rb;
    bool _stay = true;
    int _jampCount = 0;

    //コンポーネントの取得
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJamp();
        if(_stay == false) 
        {
            transform.Rotate(0f, 0f, 360.0f * Time.deltaTime);
        }
    }

    private void PlayerJamp()
    {
        if (_jampCount < 2 &&Input.GetMouseButtonDown(0))
        {
            //_stay = false;
            if (_jampCount == 0)
            {
                Debug.Log("Jamp");
                rb.AddForce(new Vector2(jampX, jampForce), ForceMode.Impulse); 
            }            
            else if(_jampCount == 1)
            {
                rb.AddForce(new Vector2(jampX/2, jampForce), ForceMode.Impulse);
            }
            _jampCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _stay = true;
        if(collision.gameObject.tag == "Item")
        {
            //countItem++;
            //count.text += countItem;
            _jampCount = 0;
        }
        if(collision.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene("Rizart");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _stay = false;
    }
}
