using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CreateScene : MonoBehaviour
{
    // Declare variables
    public int forestSize;                  // Forest size and density

    public int pyramidHeight;               // Height of pyramid

    private GameObject[] trees;             // Array for tree objects
    private GameObject[] bricks;            // Array for pyramid bricks


    private GameObject sun;                 // Directional light

    private GameObject celestialCenter;     // Root game object for the celestial object
    private GameObject moon;                // Moon object in the celestial object

    // Start is called before the first frame update
    void Start()
    {
        CheckInput();
        CreateGround();
        CreateForest();
        CreatePyramid();
        CreateCelestial();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCelestial();
        ChangeCelestialColor();
    }

    void CheckInput()
    {
        if (forestSize <= 0 || forestSize > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(forestSize), "Value must be between 1 and 10");
        }

        if (pyramidHeight < 3 || pyramidHeight > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(pyramidHeight), "Value must be between 3 and 10");
        }
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);    // Create the plane primitive
        ground.transform.position = new Vector3(0, 0, 0);                       // Move it to the origin
        ground.transform.localScale = new Vector3(3, 1, 3);                     // Make it large enough to support everything
        ground.transform.rotation = Quaternion.identity;                        // Orient it so it's flat

        // Color the plane red
        Renderer groundRenderer = ground.GetComponent<Renderer>();
        groundRenderer.material.color = Color.red;
    }

    void CreateForest()
    {
        // Create an empty game object to serve as the center of the forest and position it off to the side
        GameObject forestCenter = new GameObject("Forest");
        forestCenter.transform.position = new Vector3(15, 0, 15);

        trees = new GameObject[forestSize];

        // Create each tree
        for (int i = 0; i < trees.Length; i++)
        {
            trees[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            trees[i].transform.SetParent(forestCenter.transform);
            trees[i].transform.position = new Vector3(UnityEngine.Random.Range(forestCenter.transform.position.x, forestSize), 0, UnityEngine.Random.Range(forestCenter.transform.position.y, forestSize));
            trees[i].transform.localScale = new Vector3(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));

            // Randomize the shade of green
            Color treeColor = new Color(0f, UnityEngine.Random.Range(0.5f, 1f), 0f);
            Renderer treeRenderer = trees[i].GetComponent<Renderer>();
            treeRenderer.material.color = treeColor;
        }
    }

    void CreatePyramid()
    {
        // Create an empty game object to serve as the center of the pyramid
        GameObject pyramidCenter = new GameObject("Pyramid");
        pyramidCenter.transform.position = new Vector3(-5, 0, -5);

        // Create each birck layer by layer
        for (int i = 0; i < pyramidHeight; i++)
        {
            GameObject pyramidLayer = new GameObject("Pyramid Layer " + (pyramidHeight - i));
            pyramidLayer.transform.position = new Vector3(pyramidCenter.transform.position.x, pyramidHeight - i, pyramidCenter.transform.position.z);
            pyramidLayer.transform.SetParent(pyramidCenter.transform);

            bricks = new GameObject[(i + 1) * (i + 1)];

            // Randomize the color of each brick on a color range from red to yellow to green
            Color brickColor = new Color(UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.Range(0.5f, 1f), 0f);

            for (int j = 0; j < bricks.Length; j++)
            {
                for (int k = 0; k < (i + 1); k++)
                {
                    for (int l = 0; l < (i + 1); l++)
                    {
                        bricks[j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bricks[j].transform.SetParent(pyramidLayer.transform);
                        bricks[j].transform.position = new Vector3((pyramidLayer.transform.position.x + (i * 0.5f) - k) * 1.125f, (pyramidLayer.transform.position.y * 1.125f) - 0.5f, (pyramidLayer.transform.position.z + (i * 0.5f) - l) * 1.125f);
                        Renderer brickRenderer = bricks[j].GetComponent<Renderer>();
                        brickRenderer.material.color = brickColor;
                    }
                }
            }
        }
    }

    void CreateCelestial()
    {
        // Create an empty game object above the middle of the plane
        celestialCenter = new GameObject("Celestial Object");
        celestialCenter.transform.position = new Vector3(0f, 15f, 0f);

        // Create the moon sphere
        moon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        moon.transform.position = new Vector3(celestialCenter.transform.position.x + 10f, celestialCenter.transform.position.y, celestialCenter.transform.position.z);
        moon.transform.SetParent(celestialCenter.transform);

        Light light = moon.AddComponent<Light>();
        light.color = Color.yellow;
        light.type = LightType.Point;
        light.intensity = 10f;
        light.range = 15f;
        
        // Get the directional light component to control the moon's light color
        sun = GameObject.Find("Directional Light");
    }

    void RotateCelestial()
    {
        // Rotate the moon by rotating the root parent object
        celestialCenter.transform.Rotate(Vector3.up * 20f * Time.deltaTime);
    }

    void ChangeCelestialColor()
    {
        // Change the color of the moon's light at night. "Night" is when the intensity of the directional light is bellow half (coulnd't make it properly check the direction of the light)
        if (sun.GetComponent<Light>().intensity < 0.5f)
        {
            moon.GetComponent<Light>().color = Color.cyan;
        }
        else
        {
            moon.GetComponent<Light>().color = Color.yellow;
        }
    }
}
