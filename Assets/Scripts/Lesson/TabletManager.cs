using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletManager : MonoBehaviour
{
    public List<Texture> slides;
    public List<AudioClip> explanations;

    private int _actualSlideIndex = 0;
    private RawImage _actualSlide;
    private AudioSource _sound;

    // Start is called before the first frame update
    void Start()
    {
        _actualSlide = GetComponentInChildren<RawImage>();
        _sound = GetComponent<AudioSource>();
        _actualSlide.texture = slides[_actualSlideIndex];
    }

    public void Next()
    {
        if (_actualSlideIndex < slides.Count-1)
        {
            _actualSlideIndex++;
            _actualSlide.texture = slides[_actualSlideIndex];
        }
    }
    
    public void Previous()
    {
        if (_actualSlideIndex > 0)
        {
            _actualSlideIndex--;
            _actualSlide.texture = slides[_actualSlideIndex];
        }
    }
    
    public void Explain()
    {
        _sound.Stop();
        _sound.clip = explanations[_actualSlideIndex];
        _sound.Play();
    }
}
