using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float jampX = 3f, jampForce = 5f, minijampX = 1.5f;

    [SerializeField]
    //private Text count;

    //private float countItem;

    private Rigidbody2D rb;

    private bool stay;
    private int jampCount = 0;

    //コンポーネントの取得
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJamp();
        if(stay == false) 
        {
            transform.Rotate(0f, 0f, 180.0f * Time.deltaTime);
        }
    }

    private void PlayerJamp()
    {
        if (jampCount < 2 &&Input.GetMouseButtonDown(0))
        {
            if(jampCount == 0)
            {
                rb.AddForce(new Vector2(jampX, jampForce), ForceMode2D.Impulse);                
            }            
            else if(jampCount == 1)
            {
                rb.AddForce(new Vector2(jampX/2, jampForce), ForceMode2D.Impulse);
            }
            jampCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stay = true;
        if(collision.gameObject.tag == "Item")
        {
            //countItem++;
            //count.text += countItem;
            jampCount = 0;
        }
        if(collision.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene("Rizart");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        stay = false;
    }
}
