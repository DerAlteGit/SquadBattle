using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField]private int maxHealth;
    [SerializeField]private int currentHealth;
    [SerializeField]private Image currentHealthSprite;
    [SerializeField]private float changeAnimationTime;
    [SerializeField]private float healthBarMaxLenght;
    private GameObject followTarget;
    [SerializeField] private Vector2 offset;
    public void InitHealthBar(GameObject followTarget)
    {
        this.followTarget = followTarget;
    }
    private void Update()
    {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(new Vector2(followTarget.transform.position.x + offset.x, 
            followTarget.transform.position.y + offset.y));
        transform.position = targetPosition;
    }
    public void UpdateHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
        StartCoroutine(ChangeHealth());
    }
    public IEnumerator ChangeHealth()
    {
        Vector2 startScale = new Vector2(healthBarMaxLenght,currentHealthSprite.transform.localScale.y);
        float maxScale = healthBarMaxLenght;
        float changeScale = (float)currentHealth / maxHealth;

        Vector2 newScale = new Vector2(startScale.x * changeScale, startScale.y);
        for(float currentTime = 0; currentTime < changeAnimationTime; currentTime += Time.deltaTime)
        {
            currentHealthSprite.transform.localScale = Vector2.Lerp(currentHealthSprite.transform.localScale, newScale, currentTime / changeAnimationTime);
            yield return null;
        }
    }
}
