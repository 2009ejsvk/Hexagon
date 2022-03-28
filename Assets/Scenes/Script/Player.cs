using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;
    public float range;
    public float range_me;
    public float speed;
    Vector3 target_1;

    private void Awake()
    {
        instance = this;
    }

    public void Move(Vector3 target)
    {
        // Debug.Log(target_1);
        // Debug.Log(transform.position);
        //transform.position = target;

        Hex_Originally();

        target_1 = target;
        speed = 0.05f;

    }

    // Start is called before the first frame update
    void Start()
    {
        Hex_Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Debug.Log(speed);
        if (speed > 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_1, speed);

            if (target_1 == transform.position)
            {
                speed = 0f;
                Hex_Check();
            }
        }
    }

    public void Hex_Check()
    {
        // Debug.Log("Hex_Check");
        Collider[] colls = Physics.OverlapSphere(Player.instance.gameObject.transform.position, range);
        Collider[] colls_me = Physics.OverlapSphere(Player.instance.gameObject.transform.position, range_me);

        // Debug.Log(colls.Length);
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].transform.Find("Hex_Move") != null)
            {
                for (int j = 0; j < colls_me.Length; j++)
                {
                    if (colls_me[j].transform.Find("Hex_Move") != null && colls[i].transform.Find("Hex_Move").position.x != colls_me[j].transform.Find("Hex_Move").position.x)
                    {
                        //Debug.Log(colls[i].transform.Find("Hex_Move").position.x);

                        colls[i].transform.Find("Hex_Move").position = new Vector3(colls[i].transform.Find("Hex_Inside").position.x
                                                                                  ,colls[i].transform.Find("Hex_Inside").position.y
                                                                                  ,colls[i].transform.Find("Hex_Inside").position.z);

                        colls[i].transform.Find("Hex_Inside").position = new Vector3(colls[i].transform.Find("Hex_Inside").transform.position.x
                                                                                    ,colls[i].transform.Find("Hex_Inside").transform.position.y - 0.1f
                                                                                    ,colls[i].transform.Find("Hex_Inside").transform.position.z);
                    }
                }
            }
        }
    }

    public void Hex_Originally()
    {
        // Debug.Log("Hex_Check");
        Collider[] colls = Physics.OverlapSphere(Player.instance.gameObject.transform.position, range);
        Collider[] colls_me = Physics.OverlapSphere(Player.instance.gameObject.transform.position, range_me);

        // Debug.Log(colls.Length);
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].transform.Find("Hex_Move") != null)
            {
                for (int j = 0; j < colls_me.Length; j++)
                {
                    if (colls_me[j].transform.Find("Hex_Move") != null && colls[i].transform.Find("Hex_Move").position.x != colls_me[j].transform.Find("Hex_Move").position.x)
                    {
                        //Debug.Log(colls[i].transform.Find("Hex_Move").position.x);

                        colls[i].transform.Find("Hex_Inside").position = new Vector3(colls[i].transform.Find("Hex_Move").position.x
                                                                                    ,colls[i].transform.Find("Hex_Move").position.y
                                                                                    ,colls[i].transform.Find("Hex_Move").position.z);

                        colls[i].transform.Find("Hex_Move").position = new Vector3(colls[i].transform.Find("Hex_Move").transform.position.x
                                                                                  ,colls[i].transform.Find("Hex_Move").transform.position.y - 0.1f
                                                                                  ,colls[i].transform.Find("Hex_Move").transform.position.z);
                    }
                }
            }
        }
    }

    


}
