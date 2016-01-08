using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public GameObject cam = null;

    float vertRotationMultiplier = 60;
    Vector3 startVector;
    void Awake()
    {
        if (cam == null)
            cam = GameObject.Find("Main Camera");
    }
    void Start()
    {
        startVector = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
    }

    void FixedUpdate()
    {
        Vector3 trueTilt = Vector3.zero;
        trueTilt.x = Input.acceleration.x - startVector.x;
        trueTilt.y = Input.acceleration.y - startVector.y;
        trueTilt.z = Input.acceleration.z - startVector.z;
        if (trueTilt.sqrMagnitude > 1)
            trueTilt.Normalize();

        if (Mathf.Abs(Input.acceleration.x) > 0.2f)
        {
            this.gameObject.transform.position += new Vector3(trueTilt.x, 0, 0);
        }
        if (Mathf.Abs(Input.acceleration.y) > 0.05f)
        {
            this.gameObject.transform.position += new Vector3(0, -trueTilt.y, 0);
            if (Mathf.Abs(Input.acceleration.y) > 0.2f)
            {
                cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation,
                                         Quaternion.Euler(new Vector3(trueTilt.y * vertRotationMultiplier
                                         , 0, 0)), 750.0f * Time.deltaTime);
            }
        }

        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.GetComponent<BasicEnemy>())
               {
                  hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
               }
            }
        }
    }

}
