using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject cube;
    public CubeController cubeController;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        cube = GameObject.Find("Cube");
        cubeController = cube.GetComponent<CubeController>();
    }

    void Update()
    {
        scoreText.text = cubeController.counter.ToString();
    }
}