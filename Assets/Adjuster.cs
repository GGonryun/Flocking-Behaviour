using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adjuster : MonoBehaviour
{
    [SerializeField] FlockController controller;
    [SerializeField] Slider sizeSlider;
    [SerializeField] Slider speedSlider;
    [SerializeField] Slider alignmentSlider;
    [SerializeField] Slider cohesionSlider;
    [SerializeField] Slider separationSlider;
    [SerializeField] Slider followSlider;

    public void Awake()
    {
        sizeSlider.onValueChanged.AddListener(ChangeSize);
        speedSlider.onValueChanged.AddListener(SetSpeed);
        alignmentSlider.onValueChanged.AddListener(SetAlignment);
        cohesionSlider.onValueChanged.AddListener(SetCohesion);
        separationSlider.onValueChanged.AddListener(SetSeparation);
        followSlider.onValueChanged.AddListener(SetFollow);
    }

    private void ChangeSize(float size)
    {
        controller.SetFlockSize((int)Math.Floor(size));
    }

    public void SetSpeed(float speed)
    {
        controller.SpeedModifier = speed;
    }

    private void SetAlignment(float alignment)
    {
        controller.AlignmentWeight = alignment;
    }

    private void SetCohesion(float cohesion)
    {
        controller.CohesionWeight = cohesion;
    }

    private void SetSeparation(float separation)
    {
        controller.SeparationWeight = separation;
    }

    private void SetFollow(float follow)
    {
        controller.FollowWeight = follow;
    }







}
