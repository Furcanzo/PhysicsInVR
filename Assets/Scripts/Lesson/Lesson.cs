using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour
{
    public List<Texture> slides;
    public List<AudioClip> explanations;
    public RawImage actualSlide;

    private int _actualSlideIndex;
    private AudioSource _sound;

    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponentInChildren<AudioSource>();
    }
    
    public void ButtonPressed()
    {
        if (_sound.isPlaying)
        {
            Debug.Log("is");
            CancelInvoke();
            Rewind();
        }
        else
        {
            Debug.Log("isn't");
            CancelInvoke();
            Rewind();
            Explain();
        }
    }

    private void Next()
    {
        if (_actualSlideIndex < slides.Count -1)
        {
            _actualSlideIndex++;
            actualSlide.texture = slides[_actualSlideIndex];
            Explain();
        }
        else
        {
            actualSlide.color = Color.clear;
        }
    }
    
    private void Rewind()
    {
        _sound.Stop();
        actualSlide.color = Color.clear;
        _actualSlideIndex = 0;
        actualSlide.texture = slides[_actualSlideIndex];
    }
    
    private void Explain()
    {
        actualSlide.color = Color.white;
        _sound.clip = explanations[_actualSlideIndex];
        _sound.Play();
        Invoke(nameof(Next), _sound.clip.length);
    }
}
