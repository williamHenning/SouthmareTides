using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{
    public Button btn;

    // Update is called once per frame
    void Update()
    {
        //Ensures that the button will be the same location as the building it corresponds to
        Vector3 btnPos = Camera.main.WorldToScreenPoint(this.transform.position);
        btn.transform.position = btnPos;
    }
}
