using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rig;
    float jumpF = 680.0f;
    float walkF = 30.0f;
    float maxWS = 2.0f;
    Animator ani;

    // Use this for initialization
    void Start()
    {
        this.rig = GetComponent<Rigidbody2D>();
        this.ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rig.AddForce(transform.up * this.jumpF);
        }
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float spX = Mathf.Abs(this.rig.velocity.x);

        if(spX<this.maxWS)
        {
            this.rig.AddForce(transform.right * key * this.walkF);
        }
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.ani.speed = spX / 2.0f;
    }
}
