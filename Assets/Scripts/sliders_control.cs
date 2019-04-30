using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Required when Using UI elements.

public class sliders_control : MonoBehaviour
{
    public Slider speed;
    public Slider size;

    public Circle_Move Sphere;
    public Transform Ts_Sphere;

    public GameObject player;
    public GameObject sliders;

    private bool isShown;

    // Start is called before the first frame update
    void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        speed.onValueChanged.AddListener(delegate { speed_Value(); });
        size.onValueChanged.AddListener(delegate { size_Value(); });

        isShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Invoked when the value of the slider changes.
    public void speed_Value()
    {
        //Debug.Log(speed.value);
        Sphere.speed = 1 + 15 * speed.value;
        
    }

    public void size_Value()
    {
        float value = 0.1f + 5 * size.value;
        Ts_Sphere.localScale = new Vector3(value, value, value);
    }


    public void AddPlayer()
    {
        GameObject ball = Instantiate(player, new Vector3(0, 0, -10), Quaternion.identity);
        GameObject slidersp = Instantiate(sliders, new Vector3(100,0,0), Quaternion.identity);

        slidersp.GetComponent<sliders_control>().Sphere = ball.GetComponent<Circle_Move>();
        slidersp.GetComponent<sliders_control>().Ts_Sphere = ball.transform;
    }

    public void ShowPlayer()
    {
        if (isShown)
        {
            isShown = false;
            player.SetActive(false);
            sliders.SetActive(false);
        }
        else
        {
            isShown = true;
            player.SetActive(true);
            sliders.SetActive(true);
        }
    }
}
