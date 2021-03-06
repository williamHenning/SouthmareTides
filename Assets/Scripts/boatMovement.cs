using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boatMovement : MonoBehaviour
{

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private Vector3 m_currentDirection = Vector3.zero;

    private void Update()
    {
        DirectUpdate();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = transform.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);
            
            //Currently no rotating of the ship
            //transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Check if the boat collided with a normal explore island
        if (collision.collider.tag == "Island_Explore")
        {
            SceneManager.LoadScene("ExploreIsland");
        }

        //check if the boat collided with a shipwreck island
        else if (collision.collider.tag == "Island_Shipwreck")
        {
            SceneManager.LoadScene("ExploreShipwreck");
        }

        //check if the boat collided with another boat
        else if (collision.collider.tag == "Ship_Explore")
        {
            SceneManager.LoadScene("ExploreShip");
        }

        //Check if hit a border wall
        else if (collision.collider.tag == "Explore_Border")
        {
            //hit a borderwall
        }

        else
        {
            Debug.Log("The other collider, tag: "+collision.collider.tag);
            Debug.Log("The other collider, transform: " + collision.collider.transform);
        }
    }

}
