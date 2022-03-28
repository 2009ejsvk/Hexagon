using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tr;
    Vector3 move;
    public float speed = 1f;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    private void Update()
    {
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tr.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tr.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
