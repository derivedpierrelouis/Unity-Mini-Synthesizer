using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDS : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
		if(Loop.StartLoop == 1)
		{
			gameObject.transform.Rotate(Vector3.up * 2 + Vector3.right * 2);
		}
		else
		{
			gameObject.transform.eulerAngles = new Vector3(0,0,0);
		}
    }
}
