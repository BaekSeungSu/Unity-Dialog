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

    Vector3 dirVec;
    GameObject scanObj;

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
        rigid.velocity = new Vector2(h, v) * speed;
        Investigation();
        interaction();
    }

    void Move()
    {
        //Direction Find
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

    }

    void Investigation()
    {
        //Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Obejct"));

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
            scanObj = null;
    }

    //��ȣ�ۿ�
    void interaction()
    {
        if (Input.GetButtonDown("Jump") && scanObj !=null)
        {
            Debug.Log("This is " + scanObj.name);
        }
    }
}
