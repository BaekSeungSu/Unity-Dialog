using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private float speed;

    float h;
    float v;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v);
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
}
