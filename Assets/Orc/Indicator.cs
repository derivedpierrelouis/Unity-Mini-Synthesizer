using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
	public IList<Ind_Main> Sets;
	public List<Ind_Main> SetPoint = new List<Ind_Main>();
	public int thisFreq;
	public static float CurrentFreq;
	public Renderer Point;
	public static AudioDistortionFilter distort;
	public static AudioReverbFilter reverb;
	public Material ON;
	public Material OFF;
	public Slider slider;
	public Slider slider_DST;
	public Slider slider_RVB;
	public Slider slider_RVB2;
	public Slider slider_BPM;
	public Transform Button_slider;
	public Transform Mini_slider_DST;
	public Transform Mini_slider_RVB;
	public Transform Mini_slider_RVB2;
	public Transform Mini_slider_BPM;
	
	void Start()
	{
		Sets = SetPoint;
		distort = Sets[thisFreq].df;
		reverb = Sets[thisFreq].rf;
		slider.value = (float)Sets[thisFreq].pt.GetComponent<Frequency>().frequency;
		slider_DST.value = distort.distortionLevel;
		slider_RVB.value = reverb.reverbLevel;
		slider_RVB2.value = 0;
		slider_BPM.value = (float)Loop.speed;
		Button_slider.localPosition = new Vector3(slider.value/1500,Button_slider.position.y,Button_slider.position.z);
		Mini_slider_DST.localPosition = new Vector3(Mini_slider_DST.localPosition.x,Mini_slider_DST.localPosition.y,slider_DST.value);
		Mini_slider_RVB.localPosition = new Vector3(Mini_slider_RVB.localPosition.x,Mini_slider_RVB.localPosition.y,slider_RVB.value/2000);
		Mini_slider_RVB2.localPosition = new Vector3(Mini_slider_RVB2.localPosition.x,Mini_slider_RVB2.localPosition.y,slider_RVB2.value/20);
		Mini_slider_BPM.localPosition = new Vector3(Mini_slider_BPM.localPosition.x,Mini_slider_BPM.localPosition.y,slider_BPM.value/10);
	}	

    public void Right()
    {
		Point.material = OFF;
		thisFreq++;
		thisFreq = thisFreq % Sets.Count;
        Point = Sets[thisFreq].indication;
        distort = Sets[thisFreq].df;
        reverb = Sets[thisFreq].rf;
		slider.value = (float)Sets[thisFreq].pt.GetComponent<Frequency>().frequency;
		slider_DST.value = distort.distortionLevel;
		slider_RVB.value = reverb.reverbLevel;
		slider_RVB2.value = reverb.decayTime;
		Button_slider.localPosition = new Vector3(slider.value/1500,Button_slider.position.y,Button_slider.position.z);
		Mini_slider_DST.localPosition = new Vector3(Mini_slider_DST.localPosition.x,Mini_slider_DST.localPosition.y,slider_DST.value);
		Mini_slider_RVB.localPosition = new Vector3(Mini_slider_RVB.localPosition.x,Mini_slider_RVB.localPosition.y,slider_RVB.value/2000);
		Mini_slider_RVB2.localPosition = new Vector3(Mini_slider_RVB2.localPosition.x,Mini_slider_RVB2.localPosition.y,slider_RVB2.value/20);
		Point.material = ON;
    }
	
	public void Left()
    {
		Point.material = OFF;
		thisFreq--;
		if(thisFreq == -1)
		{
			thisFreq = 7;
		}
        Point = Sets[thisFreq].indication;
		distort = Sets[thisFreq].df;
		reverb = Sets[thisFreq].rf;
		slider.value = (float)Sets[thisFreq].pt.GetComponent<Frequency>().frequency;
		slider_DST.value = distort.distortionLevel;
		slider_RVB.value = reverb.reverbLevel;
		slider_RVB2.value = reverb.decayTime;
		Button_slider.localPosition = new Vector3(slider.value/1500,Button_slider.position.y,Button_slider.position.z);
		Mini_slider_DST.localPosition = new Vector3(Mini_slider_DST.localPosition.x,Mini_slider_DST.localPosition.y,slider_DST.value);
		Mini_slider_RVB.localPosition = new Vector3(Mini_slider_RVB.localPosition.x,Mini_slider_RVB.localPosition.y,slider_RVB.value/2000);
		Mini_slider_RVB2.localPosition = new Vector3(Mini_slider_RVB2.localPosition.x,Mini_slider_RVB2.localPosition.y,slider_RVB2.value/20);
		Point.material = ON;
	}

    // Update is called once per frame
    void Update()
    {
        distort = Sets[thisFreq].df;
        reverb = Sets[thisFreq].rf;
		if(slider_RVB.value == 0)
		 {
			 reverb.enabled = false;
		 }
		 else if(slider_RVB.value > 0)
		 {
			 reverb.enabled = true;
		 }
		if(slider_RVB2.value <= 1 )
		 {
			 reverb.enabled = false;
		 }
		 else if(slider_RVB2.value > 1)
		 {
			 reverb.enabled = true;
		 }
		 CurrentFreq = (float)Sets[thisFreq].pt.GetComponent<Frequency>().frequency;
    }
	
	void Awake ()
     {
         // Assign a callback for when this slider changes
         this.slider.onValueChanged.AddListener (this.OnSliderChanged);
         this.slider_DST.onValueChanged.AddListener (this.OnSliderChanged_DST);
         this.slider_RVB.onValueChanged.AddListener (this.OnSliderChanged_RVB);
         this.slider_RVB2.onValueChanged.AddListener (this.OnSliderChanged_RVB2);
         this.slider_BPM.onValueChanged.AddListener (this.OnSliderChanged_BPM);
         
     }

    void OnSliderChanged (float value)
     {
		Sets[thisFreq].pt.GetComponent<Frequency>().frequency = (double)slider.value;
		Button_slider.localPosition = new Vector3(slider.value/1500,Button_slider.position.y,Button_slider.position.z);
	 }
	 
    void OnSliderChanged_DST (float value)
     {
		distort.distortionLevel = slider_DST.value;
		Mini_slider_DST.localPosition = new Vector3(Mini_slider_DST.localPosition.x,Mini_slider_DST.localPosition.y,slider_DST.value);
	 }
	 
    void OnSliderChanged_RVB (float value)
     {
		reverb.reverbLevel = slider_RVB.value;
		Mini_slider_RVB.localPosition = new Vector3(Mini_slider_RVB.localPosition.x,Mini_slider_RVB.localPosition.y,slider_RVB.value/2000);
	 }
    void OnSliderChanged_RVB2 (float value)
     {
		reverb.decayTime = slider_RVB2.value;
		Mini_slider_RVB2.localPosition = new Vector3(Mini_slider_RVB2.localPosition.x,Mini_slider_RVB2.localPosition.y,slider_RVB2.value/20);
	 }
    void OnSliderChanged_BPM (float value)
     {
		Loop.speed = (int)slider_BPM.value;
		Mini_slider_BPM.localPosition = new Vector3(Mini_slider_BPM.localPosition.x,Mini_slider_BPM.localPosition.y,slider_BPM.value/10);
	 }
}
