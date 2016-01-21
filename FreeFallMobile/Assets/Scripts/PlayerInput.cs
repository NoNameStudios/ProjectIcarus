using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public GameObject cam = null;
    public GameObject[] damageImages;
    public GameObject gameManager;
    int damageCount = 0;
    int health = 5;

    float vertRotationMultiplier = 60;
    Vector3 startVector;
    bool invinc = false;
    void Awake()
    {
        if (cam == null)
            cam = GameObject.Find("Main Camera");
        damageImages = GameObject.FindGameObjectsWithTag("DmgImg");
        
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
       /* Vector3 tempPos = this.gameObject.transform.position;
        tempPos.x = Mathf.Clamp(tempPos.x,-10, 10);
        tempPos.x = Mathf.Clamp(tempPos.y, -10, 10);
        this.gameObject.transform.position = tempPos;*/


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.GetComponent<BasicEnemy>())
               {
                    gameManager.GetComponent<GameManagerScript>().EnemyDeath(10, hit.transform.gameObject);
                }
            }
        }

    
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.GetComponent<BasicEnemy>())
        {
            gameManager.GetComponent<GameManagerScript>().EnemyDeath(0, other.transform.gameObject);
            TakeDamage();
        }
       
    }
    IEnumerator InvinceTimer()
    {
        invinc = true;
        yield return new WaitForSeconds(.5f);
        invinc = false;
    }
    void TakeDamage()
    {
        if (damageCount / health > damageImages.Length)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            return;
        }
        if (!invinc)
        {
            if (damageCount == health)
            {
                damageImages[0].GetComponent<Image>().enabled = true;
            }
            else if (damageCount == health * 2)
            {
                damageImages[1].GetComponent<Image>().enabled = true;
            }
            Debug.Log(damageCount);
            damageCount++;
            StartCoroutine("InvinceTimer");
        }
    } 
}
