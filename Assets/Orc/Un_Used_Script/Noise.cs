using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Noise : MonoBehaviour
{
	// un-optimized version of a noise generator
	private System.Random RandomNumber = new System.Random();
	public float offset = 0;
	public float dataundefined;

	void OnAudioFilterRead(float[] data, int channels)
	{
		for (int i = 0; i < data.Length; i++)
		{
			dataundefined = offset -1.0f + (float)RandomNumber.NextDouble()*2.0f;
		}
	}
}