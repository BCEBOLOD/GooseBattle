using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractChar : MonoBehaviour, Ichar
{
    public  void Action()
    {
        Move();
    }

    protected virtual void Move()
    {        
            transform.position =new  Vector3(transform.position.x + 1f * Time.deltaTime, transform.position.y + 0.2f * Time.deltaTime, 0);
    }

}
