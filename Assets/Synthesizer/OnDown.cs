using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDown : MonoBehaviour
{
	public int type;
	public int End_Loop;
	public int waveType;
	public GameObject Base;
	public GameObject Filter;
	public int[] waveForm;
	public int result_Wave = 1;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if(type == 1)
		{
		Base.GetComponent<Indicator>().Right();
		}
		if(type == 2)
		{
		Base.GetComponent<Indicator>().Left();
		}
		
		if(type == 5)
		{
		if(Loop.StartLoop == 0 || Loop.StartLoop == 2)
		{
			Loop.StartLoop = 1;
		}
		if(Loop.EndLoop == 1)
		{
			Loop.StartLoop = 2;
			Loop.EndLoop = 0;
		}
		
		}
		if(type == 6)
		{
			waveType++;
			waveType = waveType % waveForm.Length;
			result_Wave = waveForm[waveType];
			Loop.waveForm_Type = result_Wave;
		}		
		
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,-0.0095f,gameObject.transform.localPosition.z);
    }

	void OnMouseUp()
    {
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,-0.0052f,gameObject.transform.localPosition.z);
	}
    // Update is called once per frame
    void Update()
    {
    }
	void Start()
	{
		Loop.waveForm_Type = result_Wave;
		waveForm = new int[3];
		waveForm[0] = 1;
		waveForm[1] = 2;
		waveForm[2] = 3;
	}
}
