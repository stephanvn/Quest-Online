using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();   
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigid.MovePosition(rigid.position + movement_vector * Time.deltaTime/2);
        // if (movement_vector != Vector2.zero)
       // {
       //     anim.SetBool("is_walking", true);
       // }
       // else
       // {
        //    anim.SetBool("is_idle", true);
       // }
	}
}
