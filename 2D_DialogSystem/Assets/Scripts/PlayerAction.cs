using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public GameManager gameManager;

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
        Interaction();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * speed;
        Investigation();
    }

    void Move()
    {
        //Direction Find
        bool hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");
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
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
            scanObj = null;
    }

    //상호작용
    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F) && scanObj !=null)
        {
            gameManager.Action(scanObj);
        }
    }
}
