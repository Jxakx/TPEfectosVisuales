using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Controls : MonoBehaviour
{
    [SerializeField] private Material _PPFreezeMaterial;
    //[SerializeField] private Material _PPOutlineMaterial;
    [SerializeField] private bool _IsOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TurnoOnOff();
        }
       
    }

    public void TurnoOnOff()
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
}
