using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShip : MonoBehaviour
{
    public float MainEngine;
    public float RcsEngine;
    public float SasForce;
    
    public GameObject flame;
    
    public Transform left;
    public Transform left_forward;
    public Transform left_up;
    public Transform left_down;
    public Transform left_back;
    //public Transform left_back_up;
    //public Transform left_back_down;

    public Transform right;
    public Transform right_forward;
    public Transform right_up;
    public Transform right_down;
    public Transform right_back;
    //public Transform right_back_up;
    //public Transform right_back_down;

    public Transform up;
    public Transform up_forward;
    public Transform up_back;

    public Transform down;
    public Transform down_forward;
    public Transform down_back;

    public Transform main_engine;
    public Transform main_engine1;
    public Transform forward;

    public Vector3 centerOfMass;
    public Rigidbody rb;

    public Rigidbody rigi;
    public Dictionary<string, Transform> flame_Effects; // 特效对应表  喷火口名——喷火口的火焰特效

    public ShipMachine shipMachine;  // 状态驱动机

   

    void Start()
    {
        shipMachine = new ShipMachine(this);
        rigi = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        InitAllEffect();
    }

    // Update is called once per frame
    void Update()
    {


        


    }

    private void FixedUpdate()
    {

        shipMachine.OnFixedUpdate();

        return;

        if (Input.GetKey(KeyCode.W))
        {

            

            Vector3 force = transform.forward * MainEngine;
            Vector3 force1 = transform.forward * MainEngine;

            rigi.AddForceAtPosition(force, flame_Effects["main_engine"].transform.position); // 受力
            rigi.AddForceAtPosition(force1, flame_Effects["main_engine1"].transform.position);



            /* Rigidbody rigi = gameObject.GetComponent<Rigidbody>();
             Vector3 force = transform.forward * MainEngine;
             //main_engine.transform.forward * MainEngine;
             //Vector3 direction = main_engine.transform.position * MainEngine;
             rigi.AddForce(force);


             GameObject _flame = Instantiate(flame, main_engine.position, main_engine.rotation);
             _flame.transform.SetParent(this.transform);//实例化火焰*/

            /*Vector3 force = transform.forward * MainEngine;

            GameObject _flame = Instantiate(flame, main_engine.position, main_engine.rotation); // 先生成火焰
            rigi.AddForceAtPosition(force, _flame.transform.position); // 后进行受力

            _flame.transform.SetParent(this.transform);*///实例化火焰


        }
        if (Input.GetKey(KeyCode.S))
        {


            

            Vector3 force = transform.forward * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["forward"].transform.position);

        }
        if (Input.GetKey(KeyCode.A))
        {


            Vector3 force = transform.right * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["right"].transform.position);

        }
        if (Input.GetKey(KeyCode.D))
        {


            Vector3 force = transform.right * RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["left"].transform.position);

        }

        if (Input.GetKey(KeyCode.R))
        {


            Vector3 force = transform.up * RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["down"].transform.position);

        }

        if (Input.GetKey(KeyCode.F))
        {


            Vector3 force = transform.up * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["up"].transform.position);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 force = transform.up * RcsEngine;
            Vector3 force1 = transform.up * -RcsEngine;
            

            rigi.AddForceAtPosition(force, flame_Effects["right_up"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["left_down"].transform.position);
            


            //transform.Rotate(Vector3.forward * SasForce);

            /*Vector3 force = transform.forward * -RcsEngine;
            Vector3 force1 = transform.forward * RcsEngine;

            GameObject _flame = Instantiate(flame, right_forward_up.position, right_forward_up.rotation);
            GameObject _flame1 = Instantiate(flame, right_back_up.position, right_back_up.rotation);
            rigi.AddForceAtPosition(force, _flame.transform.position);
            rigi.AddForceAtPosition(force1, _flame1.transform.position);

            _flame.transform.SetParent(this.transform);
            _flame1.transform.SetParent(this.transform);*/
        }

        if (Input.GetKey(KeyCode.E))
        {
            //transform.Rotate(Vector3.forward * -SasForce);

            Vector3 force = transform.up * -RcsEngine;
            Vector3 force1 = transform.up * RcsEngine;


            rigi.AddForceAtPosition(force, flame_Effects["right_down"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["left_up"].transform.position);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 force = transform.up * -RcsEngine;
            Vector3 force1 = transform.up * RcsEngine;


            rigi.AddForceAtPosition(force, flame_Effects["up_forward"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["down_back"].transform.position);

            /*Vector3 force = transform.forward * RcsEngine;
            Vector3 force1 = transform.forward * -RcsEngine;

            GameObject _flame = Instantiate(flame, up_forward.position, up_forward.rotation);
            GameObject _flame1 = Instantiate(flame, down_back.position, down_back.rotation);
            rigi.AddForceAtPosition(force, _flame.transform.position);
            rigi.AddForceAtPosition(force1, _flame1.transform.position);

            _flame.transform.SetParent(this.transform);
            _flame1.transform.SetParent(this.transform);*/

            //transform.Rotate(Vector3.right * RcsEngine * Time.deltaTime);

            //down_back.AddForceAtPosition(force, down_back.transform.position + new Vector3(0.0f, 0.3f, 0.0f), ForceMode.Force);
            //down_back.AddForce(Vector3.right * 15f, ForceMode.Force);



            /*Rigidbody rigi = gameObject.GetComponent<Rigidbody>();
            Vector3 force = down_back.transform.right * RcsEngine;
            Vector3 force1 = up_forward.transform.right * -RcsEngine;
            rigi.AddForce(force);
            rigi.AddForce(force1);*/

            /*GameObject _flame = Instantiate(flame, down_back.position, down_back.rotation);
             GameObject _flame1 = Instantiate(flame, up_forward.position, up_forward.rotation);
             _flame.transform.SetParent(this.transform);
             _flame1.transform.SetParent(this.transform);*/

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 force = transform.up * RcsEngine;
            Vector3 force1 = transform.up * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["down_forward"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["up_back"].transform.position);



        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 force = transform.forward * RcsEngine;
            Vector3 force1 = transform.forward * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["right_forward"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["left_back"].transform.position);




        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 force = transform.forward * RcsEngine;
            Vector3 force1 = transform.forward * -RcsEngine;

            rigi.AddForceAtPosition(force, flame_Effects["left_forward"].transform.position);
            rigi.AddForceAtPosition(force1, flame_Effects["right_back"].transform.position);

        }
    }
    private void InitAllEffect()
    {
        flame_Effects = new Dictionary<string, Transform>()
        {
            { "left", left.Find("flame") },
            { "left_forward", left_forward.Find("flame")},
            { "left_up", left_up.Find("flame")},
            { "left_down", left_down.Find("flame")},
            { "left_back", left_back.Find("flame") },
            //{ "left_back_up", left_back_up.Find("flame") },
            //{ "left_back_down", left_back_down.Find("flame") },   
            
            { "right", right.Find("flame") },
            { "right_forward", right_forward.Find("flame") },
            { "right_up", right_up.Find("flame") },
            { "right_down", right_down.Find("flame") },
            { "right_back", right_back.Find("flame") },
            //{ "right_back_up", right_back_up.Find("flame") },
            //{ "right_back_down", right_back_down.Find("flame") },

            { "up", up.Find("flame")},
            { "up_forward", up_forward.Find("flame")},
            { "up_back", up_back.Find("flame")},

            { "down", down.Find("flame") },
            { "down_forward",down_forward.Find("flame") },
            { "down_back", down_back.Find("flame")},

            { "main_engine", main_engine.Find("flame") },
            { "main_engine1", main_engine1.Find("flame") },

            { "forward", forward.Find("flame") }

        };
    }
}
