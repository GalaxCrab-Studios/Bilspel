using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject car;
    

    [SerializeField]
    private float aheadSpeed,
                  followDamping,
                  cameraHeight;

    private Vector3 velocity;
    void Awake()
    {
        velocity = car.GetComponent<CarScript>().velocity;
    }

    void Update()
    {
        
        Vector3 targetPosition = car.transform.position + Vector3.forward * cameraHeight + velocity * aheadSpeed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followDamping * Time.deltaTime);
    
    }
}
