using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.speed = 0.8f;
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
            anim.speed = .2f;
        }
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
}
