using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playe : AbstractChar
{
    protected override void Move()
    {
        transform.position = new Vector3(transform.position.x + 1f * Time.deltaTime,
            transform.position.y + 0.2f * Time.deltaTime, 0);
        print("CallingPlayer");

    }
}
