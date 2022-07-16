using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetRot = transform.eulerAngles + transform.forward * speed * Time.fixedDeltaTime;
        rig.MoveRotation(Quaternion.Euler(targetRot));
    }
}
