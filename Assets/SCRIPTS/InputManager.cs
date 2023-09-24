using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private float turnAround;
    private Dictionary<string, float> axisValues = new Dictionary<string, float>();
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = new InputManager();

            return instance;
        }
    }

    public void SetAxis(string inputName,float value)
    {
        axisValues.TryAdd(inputName, value);

        axisValues[inputName] = value;
    }

    public float GetOrAddAxis(string inputName)
    {
        axisValues.TryAdd(inputName, 0f);
        return axisValues[inputName];
    }

    public float GetAxis(string inputName)
    {
#if UNITY_EDITOR
        return GetOrAddAxis(inputName) + Input.GetAxis(inputName);
#endif
#if UNITY_ANDROID || UNITY_IOS
        return GetOrAddAxis(inputName);
#endif
#if UNITY_STANDALONE
        Input.GetAxis(inputName);
#endif
    }
}