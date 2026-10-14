using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FlightCalc : MonoBehaviour
{
    private float tempMultiplier;
    private float PAMultiplier;
    private TMP_InputField PAField;
    private TMP_InputField TempField;
    
    private TextMeshProUGUI ClearanceField;
    public bool ground = false;
    private TextMeshProUGUI ResultField;
    public float PA;
    public float Temp;
    public float result;
    void Start() 
    {
        PAField = GameObject.Find("PAfield").GetComponent<TMP_InputField>();
        TempField = GameObject.Find("Tempfield").GetComponent<TMP_InputField>(); 
        ResultField = GameObject.Find("Result").GetComponent<TextMeshProUGUI>(); 
        ClearanceField = GameObject.Find("Clearance").GetComponent<TextMeshProUGUI>();   
    }
    public void Clearance()
    {
        if(ground == true)
        {
            ground = false;
            ClearanceField.text = "Clear 50ft";
        }else
        {
            ground = true;
            ClearanceField.text = "Ground";
        }
    }
    public void Calculate()
    {
        //Ground
        int[] tempChart0Ground = {640, 705, 775, 855, 940, 1040, 1145, 1270, 1405};
        int[] tempChart10Ground = {695, 765, 840, 925, 1020, 1125, 1245, 1375, 1525};
        int[] tempChart20Ground = {755, 825, 910, 1000, 1100, 1215, 1345, 1490, 1655};
        int[] tempChart30Ground = {810, 890, 980, 1080, 1190, 1315, 1455, 1615, 1795};
        int[] tempChart40Ground = {875, 960, 1055, 1165, 1285, 1420, 1570, 1745, 1940};
        int[][] tempChartGroundMaster = {tempChart0Ground, tempChart10Ground, tempChart20Ground, tempChart30Ground, tempChart40Ground};
        //50ft Clearance
        int[] tempChart0Clear = {1190, 1310, 1445, 1600, 1775, 1970, 2200, 2470, 2800};
        int[] tempChart10Clear = {1290, 1420, 1565, 1730, 1920, 2140, 2395, 2705, 3080};
        int[] tempChart20Clear = {1390, 1530, 1690, 1870, 2080, 2320, 2610, 2960, 3395};
        int[] tempChart30Clear = {1495, 1645, 1820, 2020, 2250, 2525, 2855, 3255, 3765};
        int[] tempChart40Clear = {1605, 1770, 1960, 2185, 2440, 2750, 3125, 3590, 4195};
        int[][] tempChartClearMaster = {tempChart0Clear, tempChart10Clear, tempChart20Clear, tempChart30Clear, tempChart40Clear};
        tempMultiplier = 0;
        PAMultiplier = 0;
        //between first temperature
        float firstInterpolation;
        //between second temperature
        float secondInterpolation;
        int tempChartPos = -1;
        int PAChartPos = -1;
        if (float.TryParse(PAField.text, out float PA))
        {
            // Parsing successful
            // PA variable now contains the parsed float value
        }
        else
        {
            // Parsing failed, handle the error
            PA = -1f;

        }
        if (float.TryParse(TempField.text, out float Temp))
        {
            // Parsing successful
            // PA variable now contains the parsed float value
        }
        else
        {
            // Parsing failed, handle the error
            Temp = -1f;
        }
//        PA = float.Parse(PAField.text);
//        Temp = float.Parse(TempField.text);
//        Mult = float.Parse(MultField.text);
        if(Temp < 0 || PA < 0)
        {   
            result = -1;

        }else
        {
            if((Temp >= 0) && (Temp < 10))
            {
                tempMultiplier = (Temp) / 10;
                tempChartPos = 0;
                if((PA >= 0) && (PA < 1000))
                {
                    PAMultiplier = (PA - 0) / 1000;
                    PAChartPos = 0;
                    
                }else if((PA >= 1000) && (PA < 2000))
                {    
                    PAMultiplier = (PA - 1000) / 1000;
                    PAChartPos = 1;
                }else if((PA >= 2000) && (PA < 3000))
                {
                    PAMultiplier = (PA - 2000) / 1000;
                    PAChartPos = 2;   
                }else if((PA >= 3000) && (PA < 4000))
                {
                    PAMultiplier = (PA - 3000) / 1000;
                    PAChartPos = 3;
                }else if((PA >= 4000) && (PA < 5000))
                {
                    PAMultiplier = (PA - 4000) / 1000;
                    PAChartPos = 4;
                }else if((PA >= 5000) && (PA < 6000))
                {
                    PAMultiplier = (PA - 5000) / 1000;
                    PAChartPos = 5;
                }else if((PA >= 6000) && (PA < 7000))
                {
                    PAMultiplier = (PA - 6000) / 1000;
                    PAChartPos = 6;
                }else if((PA >= 7000) && (PA < 8000))
                {
                    PAMultiplier = (PA - 7000) / 1000;
                    PAChartPos = 7;
                }else
                {
                    result = -1;
                }
            }else if((Temp >= 10) && (Temp < 20))
            {
                tempMultiplier = (Temp-10) / 10;
                tempChartPos = 1;
                if((PA >= 0) && (PA < 1000))
                {
                    PAMultiplier = (PA - 0) / 1000;
                    PAChartPos = 0;
                    
                }else if((PA >= 1000) && (PA < 2000))
                {    
                    PAMultiplier = (PA - 1000) / 1000;
                    PAChartPos = 1;
                }else if((PA >= 2000) && (PA < 3000))
                {
                    PAMultiplier = (PA - 2000) / 1000;
                    PAChartPos = 2;   
                }else if((PA >= 3000) && (PA < 4000))
                {
                    PAMultiplier = (PA - 3000) / 1000;
                    PAChartPos = 3;
                }else if((PA >= 4000) && (PA < 5000))
                {
                    PAMultiplier = (PA - 4000) / 1000;
                    PAChartPos = 4;
                }else if((PA >= 5000) && (PA < 6000))
                {
                    PAMultiplier = (PA - 5000) / 1000;
                    PAChartPos = 5;
                }else if((PA >= 6000) && (PA < 7000))
                {
                    PAMultiplier = (PA - 6000) / 1000;
                    PAChartPos = 6;
                }else if((PA >= 7000) && (PA < 8000))
                {
                    PAMultiplier = (PA - 7000) / 1000;
                    PAChartPos = 7;
                }else
                {
                    result = -1;
                }
            }else if((Temp >= 20) && (Temp < 30))
            {
                tempMultiplier = (Temp-20) / 10;
                tempChartPos = 2;
                if((PA >= 0) && (PA < 1000))
                {
                    PAMultiplier = (PA - 0) / 1000;
                    PAChartPos = 0;
                    
                }else if((PA >= 1000) && (PA < 2000))
                {    
                    PAMultiplier = (PA - 1000) / 1000;
                    PAChartPos = 1;
                }else if((PA >= 2000) && (PA < 3000))
                {
                    PAMultiplier = (PA - 2000) / 1000;
                    PAChartPos = 2;   
                }else if((PA >= 3000) && (PA < 4000))
                {
                    PAMultiplier = (PA - 3000) / 1000;
                    PAChartPos = 3;
                }else if((PA >= 4000) && (PA < 5000))
                {
                    PAMultiplier = (PA - 4000) / 1000;
                    PAChartPos = 4;
                }else if((PA >= 5000) && (PA < 6000))
                {
                    PAMultiplier = (PA - 5000) / 1000;
                    PAChartPos = 5;
                }else if((PA >= 6000) && (PA < 7000))
                {
                    PAMultiplier = (PA - 6000) / 1000;
                    PAChartPos = 6;
                }else if((PA >= 7000) && (PA < 8000))
                {
                    PAMultiplier = (PA - 7000) / 1000;
                    PAChartPos = 7;
                }else
                {
                    result = -1;
                }
            }else if((Temp >= 30) && (Temp < 40))
            {
                tempMultiplier = (Temp-30) / 10;
                tempChartPos = 3;
                if((PA >= 0) && (PA < 1000))
                {
                    PAMultiplier = (PA - 0) / 1000;
                    PAChartPos = 0;
                    
                }else if((PA >= 1000) && (PA < 2000))
                {    
                    PAMultiplier = (PA - 1000) / 1000;
                    PAChartPos = 1;
                }else if((PA >= 2000) && (PA < 3000))
                {
                    PAMultiplier = (PA - 2000) / 1000;
                    PAChartPos = 2;   
                }else if((PA >= 3000) && (PA < 4000))
                {
                    PAMultiplier = (PA - 3000) / 1000;
                    PAChartPos = 3;
                }else if((PA >= 4000) && (PA < 5000))
                {
                    PAMultiplier = (PA - 4000) / 1000;
                    PAChartPos = 4;
                }else if((PA >= 5000) && (PA < 6000))
                {
                    PAMultiplier = (PA - 5000) / 1000;
                    PAChartPos = 5;
                }else if((PA >= 6000) && (PA < 7000))
                {
                    PAMultiplier = (PA - 6000) / 1000;
                    PAChartPos = 6;
                }else if((PA >= 7000) && (PA < 8000))
                {
                    PAMultiplier = (PA - 7000) / 1000;
                    PAChartPos = 7;
                }else
                {
                    result = -1;
                }
            }else
            {
                result = -1;
            }
        }
        
        if(result == -1 || tempChartPos == -1 || PAChartPos == -1)
        {
            ResultField.text = result.ToString();
        }else
        {
            if(ground == true)
            {
                firstInterpolation = tempChartGroundMaster[tempChartPos][PAChartPos] + (PAMultiplier * (tempChartGroundMaster[tempChartPos][PAChartPos+1] - tempChartGroundMaster[tempChartPos][PAChartPos]));
                secondInterpolation = tempChartGroundMaster[tempChartPos+1][PAChartPos] + (PAMultiplier * (tempChartGroundMaster[tempChartPos+1][PAChartPos+1] - tempChartGroundMaster[tempChartPos+1][PAChartPos]));  
                result = firstInterpolation + (tempMultiplier * (secondInterpolation - firstInterpolation));
            }else
            {
                firstInterpolation = tempChartClearMaster[tempChartPos][PAChartPos] + (PAMultiplier * (tempChartClearMaster[tempChartPos][PAChartPos+1] - tempChartClearMaster[tempChartPos][PAChartPos]));
                secondInterpolation = tempChartClearMaster[tempChartPos+1][PAChartPos] + (PAMultiplier * (tempChartClearMaster[tempChartPos+1][PAChartPos+1] - tempChartClearMaster[tempChartPos+1][PAChartPos]));  
                result = firstInterpolation + (tempMultiplier * (secondInterpolation - firstInterpolation));
            }
            ResultField.text = result.ToString();
        }
        
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
