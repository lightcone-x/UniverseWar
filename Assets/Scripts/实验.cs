using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 实验 : MonoBehaviour
{
    public Rigidbody A, B, C;
    Vector3 m_force = new Vector3(0.0f, 0.0f, 10.0f);
    public float moveSpeed;
    public Rigidbody obj;



    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.name == "Cube")
                {
                    Vector3 direction = hit.transform.position - obj.transform.position;
                    //发射炮弹
                    obj.GetComponent<Rigidbody>().AddForceAtPosition(direction, hit.transform.position, ForceMode.Impulse);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* if (Input.GetKey(KeyCode.W))
         {
             A.AddForceAtPosition(m_force, A.transform.position, ForceMode.Force);
         }*/
        //通过刚体控制物体移动,需要添加刚体
        Vector3 moveForward = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveForward.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveForward.z += -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveForward.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveForward.x += 1;
        }

        GetComponent<Rigidbody>().MovePosition(Quaternion.LookRotation(transform.forward) * moveForward * moveSpeed * Time.fixedDeltaTime + transform.position);

    }

    /*void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);

    }*/
}
