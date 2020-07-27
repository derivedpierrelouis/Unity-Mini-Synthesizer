using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frequency : MonoBehaviour
{
	public Toggle toggle;	
	public Material ON;
	public Material OFF;
	public Renderer LED;
	public double frequency = 440.0;
	private double increment;
	private double phase;
	private double sampling_frequency = 48000.0;
	public float gain;


	
	void OnAudioFilterRead(float[] data, int channels)
	{
		if(toggle.isOn)
		{
			
		increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
		
		for(int i = 0; i < data.Length; i += channels)
		{
			phase += increment;
			if(Loop.waveForm_Type == 1)
			{
				data[i] = (float)(gain * Mathf.Sin((float)phase));
			}
			if(Loop.waveForm_Type == 2)
			{
				data[i] = (float)(gain * (double) Mathf.PingPong((float)phase, 1.0f));
			}
			if(Loop.waveForm_Type == 3)
			{
			if(gain * Mathf.Sin((float)phase) >= 0 * gain)
			{
			data[i] = (float)gain * 0.6f;
			}
			else
			{
			data[i] = (-(float)gain) * 0.6f;
			}
			}
			
			if(channels == 2)
			{
				data[i + 1] = data[i];
			}
			
			if(phase > (Mathf.PI * 2))
			{
				phase = 0.0;
			}
		}
		
		}

	}
	void Update()
	{
		LED.material = toggle.isOn ? ON : OFF;
	}
	
}
