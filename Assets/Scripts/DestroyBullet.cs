using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    private float destoryTime = 5.0f; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyThis(destoryTime));
    }

    private IEnumerator DestroyThis(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
