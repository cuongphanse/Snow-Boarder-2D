using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlayer : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    bool activeMove = true;
    Rigidbody2D rg2d;
    SurfaceEffector2D surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(activeMove){
        RotationPlayer();
        RepondToBoost();
       }
    }

    public void DisableController(){
        activeMove = false;
    }

    void RepondToBoost(){
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
            surfaceEffector2D.speed = baseSpeed;
        }
    }
    void RotationPlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rg2d.AddTorque(-torqueAmount);
        }
    }
}
