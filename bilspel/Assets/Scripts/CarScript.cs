using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [Header("CalculateVelocity")]
    [SerializeField]
    private float enginePower, 
                  drag, 
                  mass, 
                  rollingRes,
                  brakeConst;

    [Header("CalculateRotation")]
    [SerializeField]
    private float wheelDistance,
                  turnSpeed
                  ;


    public Vector3 velocity;
    Vector3 fDrag;
    Vector3 rollingResistance;


    void Start()
    {
        
    }

    
    void Update()
    {
        CalculateVelocity();
        transform.position += velocity * Time.deltaTime;
    }

    private void CalculateVelocity()
    {

        float v = Input.GetAxis("Vertical");

        Vector3 forward = transform.TransformDirection(Vector3.up);
        Vector3 traction = forward * v * enginePower;
        Vector3 brake = -forward * brakeConst;
        Vector3 acceleration;

        float curSpeed = velocity.magnitude;
        Debug.Log(curSpeed);

        rollingResistance = -rollingRes * velocity;
        fDrag.x = -drag * velocity.x * curSpeed;
        fDrag.y = -drag * velocity.y * curSpeed;
        
        if (v < 0)
        {
            acceleration = (brake + fDrag + rollingResistance) / mass;
            
        }
        else
        {
            acceleration = (traction + fDrag + rollingResistance) / mass;
           
        }
            velocity += acceleration * Time.deltaTime;
    }

    private void CalculateRotation()
    {
        float angle = 20;
        float steer = wheelDistance / Mathf.Sin(angle);
    }



}
    