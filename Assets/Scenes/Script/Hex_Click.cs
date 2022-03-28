using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Click : MonoBehaviour
{
    public GameObject move_form;
    public float range;

    Transform tr;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() // 마우스로 클릭했을때 실행됨, 콜라이더 없으면 안됨
    {
        Collider[] colls = Physics.OverlapSphere(Player.instance.gameObject.transform.position, range);
        // Debug.Log("Player : " + Player.instance.gameObject.transform.position);

        if (Player.instance.speed == 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                // Debug.Log(i + " : " + colls[i].transform.position);
                if (colls[i].transform.position == gameObject.transform.position)
                {
                    // Debug.Log("클릭된 오브젝트 이름 : " + gameObject.name);
                    // Debug.Log("클릭된 오브젝트 위치 : " + gameObject.transform.position);
                    // Debug.Log("클릭된 오브젝트 스케일 : " + gameObject.transform.localScale);
                    // Debug.Log("클릭된 오브젝트 X : " + gameObject.transform.position.x) ;
                    // Debug.Log("클릭된 오브젝트 Y : " + gameObject.transform.position.y) ;
                    // Debug.Log("클릭된 오브젝트 Z : " + gameObject.transform.position.z) ;
                    float move_form_position_x = gameObject.transform.position.x;
                    float move_form_position_y = gameObject.transform.position.y;
                    float move_form_position_z = gameObject.transform.position.z;
                    float move_form_localScale_x = gameObject.transform.localScale.x;
                    float move_form_localScale_y = gameObject.transform.localScale.y;
                    float move_form_localScale_z = gameObject.transform.localScale.z;
                    float player_localScale_x = Player.instance.gameObject.transform.localScale.x;
                    float player_localScale_y = Player.instance.gameObject.transform.localScale.y;
                    float player_localScale_z = Player.instance.gameObject.transform.localScale.z;

                    // Debug.Log(colls[i].transform.position);

                    Player.instance.Move(new Vector3(move_form_position_x - (move_form_localScale_x / 2) + player_localScale_x
                                                    , Player.instance.gameObject.transform.position.y
                                                    , move_form_position_z + (move_form_localScale_z / 2) - (player_localScale_z / 2)
                                                    ));

                }
            }
        }


    }

    private void FixedUpdate()
    {

    }


}
