using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private GameObject character;
    public bool IsFull { get; private set; } = false;
    

    [Header("Animation Setting")]
    [SerializeField] private Animator cellAnimator;

    [SerializeField] private string EnterTrigger;
    [SerializeField] private string ExitTrigger;
    [SerializeField] private string ClickTrigger;

    [SerializeField]private Vector3 baseScaleAlpha; // x,y - scales, z - alpha
    [SerializeField] private float upscaleValue;
    [SerializeField] private float alphaValue;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private float upscaleDuration;
    [SerializeField] private float downscaleDuration;
    [SerializeField]private float explosionDuration;

    
    private void Awake()
    {
        
    }
    public void Insert(GameObject character)
    {
        IsFull = true;
        this.character = character;
        particles.Play();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
    }
    public void Remove()
    {
        IsFull = false;
        Destroy(character);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.749f);
    }


    //Animations
    private void OnMouseEnter()
    {
        transform.localScale = new Vector2(baseScaleAlpha.x * upscaleValue, baseScaleAlpha.y * upscaleValue);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector2(baseScaleAlpha.x, baseScaleAlpha.y);
    }
    private IEnumerator UpScale()
    {
        Vector2 resultScale = new Vector2(baseScaleAlpha.x * upscaleValue, baseScaleAlpha.y * upscaleValue);
        Debug.Log(resultScale.x + " " + resultScale.y);
        for (float i = 0; i < upscaleDuration; i += Time.deltaTime)
        {
            
            transform.localScale = Vector2.Lerp(new Vector2(baseScaleAlpha.x, baseScaleAlpha.y), resultScale, i / upscaleDuration);
            yield return null;
        }
    }
    private IEnumerator DownScale()
    {
        Vector2 resultScale = new Vector2(baseScaleAlpha.x, baseScaleAlpha.y);
        Vector2 currentScale = transform.localScale;
        Debug.Log(resultScale.x + " " + resultScale.y);
        for (float i = 0; i < downscaleDuration; i += Time.deltaTime)
        {
           
            transform.localScale = Vector2.Lerp(currentScale, resultScale, i / downscaleDuration);
            yield return null;
        }
    }
    /*private IEnumerator Explosion()
    {

    }
*/

}
