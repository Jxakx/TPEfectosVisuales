using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Controls : MonoBehaviour
{
    [SerializeField] private Material _PPFreezeMaterial;
    [SerializeField] private Material _PPOutlineMaterial;
    [SerializeField] private bool _IsOn;
    [SerializeField] private bool _IsOnOutline;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TurnoOnOffFreeze();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            TurnoOnOffOutline();
        }
    }

    public void TurnoOnOffFreeze()
    {
        if (_IsOn)
        {
            _PPFreezeMaterial.SetFloat("_PPIntensity", 0f);
            _IsOn = false;
        }
        else
        {
            _PPFreezeMaterial.SetFloat("_PPIntensity", 1);
            _IsOn = true;
        }
    }

    public void TurnoOnOffOutline()
    {
        if (_IsOnOutline)
        {
            _PPOutlineMaterial.SetFloat("_Outline_Thickness", 0f);
            _IsOnOutline = false;
        }
        else
        {
            _PPOutlineMaterial.SetFloat("_Outline_Thickness", 0.02f);
            _IsOnOutline = true;
        }
    }
}
