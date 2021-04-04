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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("ally") || collision.gameObject.CompareTag("player"))
        {
            // do damage
        }
        Destroy(this.gameObject);

    }
}
