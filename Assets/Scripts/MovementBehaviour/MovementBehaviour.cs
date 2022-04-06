using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 _velocity;

    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position += _velocity * Time.deltaTime;
    }
}
