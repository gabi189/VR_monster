using System;
using Leap.Unity.Interaction;
using UnityEngine;

public class HandColorOnGrasp : MonoBehaviour
{
    public SkinnedMeshRenderer ToDisable;

    //public Color GraspingColor;
    //private Color[] _originalColors;

    //public Material[] _materials;

    private InteractionController _controller;

    void Start()
    {
        _controller = GetComponent<InteractionController>();

        _controller.OnGraspBegin += _OnGraspBegin;
        _controller.OnGraspEnd += _OnGraspEnd;

        //_originalColors = new Color[_materials.Length];
        //for (int i = 0; i < _materials.Length; i++)
        //{
        //    _originalColors[i] = _materials[i].color;
        //}
    }

    private void _OnGraspBegin()
    {
        ToDisable.enabled = false;
    }

    private void _OnGraspEnd()
    {
        ToDisable.enabled = true;
    }

    //private void _SetColor(Color newColor, Material[] materials)
    //{
    //    for (int i = 0; i < materials.Length; i++)
    //    {
    //        materials[i].color = newColor;
    //    }
    //}

    //private void _SetColor(Color[] originalColors, Material[] materials)
    //{
    //    for (int i = 0; i < materials.Length; i++)
    //    {
    //        materials[i].color = originalColors[i];
    //    }
    //}
}
