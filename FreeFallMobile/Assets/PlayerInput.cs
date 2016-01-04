using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.acceleration.x) > 0.05f)
        {
            this.gameObject.transform.position += new Vector3(Input.acceleration.x, 0, 0);
        }
       
        if(Mathf.Abs(Input.acceleration.y) > 0.05f || Mathf.Abs(Input.acceleration.z) > 0.05f)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(Input.acceleration.y,Input.acceleration.z, 0) * 50.0f * Time.deltaTime);
        }
    }

}
