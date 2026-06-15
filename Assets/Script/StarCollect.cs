using UnityEngine;

public class StarCollect : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!collected)
            {
                collected = true;

                GameManager.Instance.CollectStar();

                gameObject.SetActive(false);
            }
        }
    }

    public void ResetStar()
    {
        collected = false;
        gameObject.SetActive(true);
    }
}