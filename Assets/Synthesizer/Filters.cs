using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Filters : MonoBehaviour
{
	public AudioDistortionFilter Current_Distort;
	public AudioReverbFilter Current_Reverb;
	public TMP_Text Num;
	public TMP_Text Num2;
	public TMP_Text Num3;
	public TMP_Text Num4;
	public TMP_Text Num5;
	public double Divide_Num;
	public double Final_Num;
	public int loopSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Current_Distort = Indicator.distort;
        Current_Reverb = Indicator.reverb;
		Num.text = Math.Round(Current_Distort.distortionLevel, 2).ToString();
		Num2.text = Math.Round(Current_Reverb.reverbLevel, 2).ToString();
		Num3.text = Math.Round(Current_Reverb.decayTime, 2).ToString();
		Num4.text = Math.Round(Indicator.CurrentFreq, 2).ToString();
		loopSpeed = Loop.speed;
		Divide_Num = 2/(double)loopSpeed;
		Final_Num = 60/Divide_Num;
		Num5.text = Final_Num.ToString();
    }
	

}
