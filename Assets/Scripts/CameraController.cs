using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    Vector3 targetPos;

    Camera mycam;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        mycam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //mycam.orthographicSize = (Screen.height / 100f) / 4f;
        GameObject player = GameObject.Find("MainPlayer(Clone)");
        if (!target && player)
        {
            target = player.transform;
        }
        else if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -10); ;
        }
    }
}