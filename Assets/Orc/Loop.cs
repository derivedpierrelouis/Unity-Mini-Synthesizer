using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loop : MonoBehaviour
{
	public double frequency = 1;
	public int thisFreq;
	public float time;
	public int active;
	public static int StartLoop = 0;
	public static int EndLoop = 0;
	public IList<Element> frequencies;
	public List<Element> PointArray = new List<Element>();
	public Toggle activePoint;
	public static int speed = 4;
	public static GameObject this_Audio;
	public GameObject start_Audio;
	public GameObject type1;
	public GameObject type2;
	public GameObject type3;
	public static int waveForm_Type;
	
	void Start()
	{
		frequencies = PointArray;
		active = 1;
		this_Audio = start_Audio;
	}

    // Update is called once per frame
    void Update()
    {

		if(StartLoop == 1)
		{
		if(active == 1)
		{
			time += Time.deltaTime * speed;
		}
		
		if(time > 2)
		{
			active = 0;
			time = 0;
			activePoint = frequencies[thisFreq].point;
			this_Audio = frequencies[thisFreq].audio;
			activePoint.isOn = true;
			thisFreq++;
			thisFreq = thisFreq % frequencies.Count;
			active = 1;
			EndLoop = 1;
			
			
		}
		}
		else if(StartLoop == 2)
		{
			time = 0;
			this_Audio = start_Audio;
			thisFreq = 0;
			activePoint.isOn = false;
			
		}	
		
		
		if(waveForm_Type == 1)
		{	
		type1.SetActive(true); 
		type2.SetActive(false); 
		type3.SetActive(false);  
		}
		if(waveForm_Type == 2)
		{	
		type2.SetActive(true);  
		type1.SetActive(false);  
		type3.SetActive(false);  
		}
		if(waveForm_Type == 3)
		{	
		type3.SetActive(true); 
		type2.SetActive(false);  
		type1.SetActive(false); 
		}
		
		
		
    }
}
