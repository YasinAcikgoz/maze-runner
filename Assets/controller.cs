using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class controller : MonoBehaviour
{


    private bool walking = true;
    private Vector3 spanPoint;

    void Start()
    {
        spanPoint = transform.position;
    }

   
    void Update()
    {
        if (walking)
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
        

        // oyunu yeniden baslat
        if (transform.position.y < -10f)
            transform.position = spanPoint;
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
		{
			//asagiya bakinca veya duvara gelince dur
			if (hit.collider.name.Contains("plane") || hit.collider.name.Contains("cube") )
            {
                walking = false;
            }
            else
            {
                walking = true;
            }
        }
    }
}