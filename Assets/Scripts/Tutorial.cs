using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Transform _target;

    public void ShowHint(int index)
    {
        _target = transform.GetChild(index);

        _target.gameObject.SetActive(true);

        StartCoroutine(Effect());
    }

    public void HideHint(int index)
    {
        //StopCoroutine("ToggleActive"); //почему-то так не работает

        StopAllCoroutines();
        
        transform.GetChild(index).gameObject.SetActive(false);
    }

    private IEnumerator Effect()
    {
        for (float t = 0; t < 1.9f; t += Time.deltaTime)
        {
            float scale = Mathf.Sin(t * 5f) * 0.1f + 0.5f;

            _target.localScale = Vector3.one * scale;

            yield return null;
        }

        _target.localScale = Vector3.one*0.5f;
    }
}
