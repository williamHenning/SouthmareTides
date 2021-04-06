using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float destoryTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyThis(destoryTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyThis(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ally") || collision.gameObject.CompareTag("Player"))
        {
            // do damage
            Debug.Log("True");
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(1);
        }
        Destroy(this.gameObject);

    }
}
