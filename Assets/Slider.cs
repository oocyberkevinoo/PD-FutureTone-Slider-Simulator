using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public Text DEBUGGER;

    public Sensor[] sensors1 = new Sensor[32];


    public int sliderBits = 0;
    public long resultBits = 0; 
    public string HEX_Result;
    public long RY;
    public long RX;
    public long LY;
    public long LX;

    public float Axis_RY;
    public float Axis_RX;
    public float Axis_LY;
    public float Axis_LX;

    private int bit_count = 31;



    void Update()
    {


        
        sliderBits = 0;
 
        foreach (Sensor sensor in sensors1)
        {

            if (sensor.state)
            {
                sliderBits |= (1 << bit_count);
            }
            bit_count -= 1;
                
        }

        resultBits = sliderBits ^ 0x80808080;
        HEX_Result = resultBits.ToString("X");


        // Bytes Axis Result, SEND THEM TO YOUR CONTROLLER
        RY = (resultBits >> 24) & 0xFF;
        RX = (resultBits >> 16) & 0xFF;
        LY = (resultBits >> 8) & 0xFF;
        LX = (resultBits) & 0xFF;

        // Float Result for checking
        Axis_RY = (RY / 255.0f) * 2.0f - 1.0f;
        Axis_RX = (RX / 255.0f) * 2.0f - 1.0f;
        Axis_LY = (LY / 255.0f) * 2.0f - 1.0f;
        Axis_LX = (LX / 255.0f) * 2.0f - 1.0f;

        DEBUG();
    }


    private void DEBUG()
    {
        DEBUGGER.text = "HEX Values | INT value | Float Axis Resulted value \n\n";
        DEBUGGER.text += $"" +
            $"   RY: {RY.ToString("X")} | {RY} | {Axis_RY}\n" +
            $"   RX: {RX.ToString("X")} | {RX} | {Axis_RX}\n" +
            $"   LY: {LY.ToString("X")} | {LY} | {Axis_LY}\n" +
            $"   LX: {LX.ToString("X")} | {LX} | {Axis_LX}\n";


    }
}
