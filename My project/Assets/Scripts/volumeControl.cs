using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    public Volume volume;
    void Start()
    {
        this.GetComponent<Slider>().value = volume.volume;
    }
    public void SliderChange(float value)
    {
        volume.volume = value;
    }
}
