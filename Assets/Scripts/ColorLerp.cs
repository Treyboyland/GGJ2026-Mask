using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    [SerializeField]
    Gradient gradient;

    [SerializeField]
    Image image;

    [SerializeField]
    AnimationCurve multiplier;

    [SerializeField]
    float secondsPerLoop;

    [SerializeField]
    float startingProgress;

    float progress;

    float elapsed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progress = startingProgress;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed = (elapsed + Time.deltaTime * multiplier.Evaluate(progress)) % secondsPerLoop;
        UpdateColor(gradient.Evaluate(elapsed / secondsPerLoop));
    }

    void UpdateColor(Color c)
    {
        c.a = image.color.a;
        image.color = c;
    }

    public void UpdateProgess(float newProgress)
    {
        progress = newProgress;
    }
}
