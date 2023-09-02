using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DumpsterSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemType _allowedType;
    [SerializeField] private Image correctImage;
    [SerializeField] private Image falseImage;
    [SerializeField] private Image correctText;
    [SerializeField] private Image falseText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Coroutine imageCoroutine;
    private Coroutine textCoroutine;
    private Coroutine dropCoroutine;




    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        ItemType droppedItemType = dropped.GetComponent<InventoryItem>().item.type;

        dropCoroutine = StartCoroutine(ShowDropCoroutine(dropped, droppedItemType));
    }



    private void OnDisable()
    {
        correctImage.gameObject.SetActive(false);
        correctText.gameObject.SetActive(false);
        falseImage.gameObject.SetActive(false);
        falseText.gameObject.SetActive(false);
    }



    public IEnumerator ShowImage(Image _image, float time)
    {
        _image.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        _image.gameObject.SetActive(false);
    }


    public IEnumerator ShowDropCoroutine(GameObject _dropped, ItemType _droppedItemType)
    {
        if (_droppedItemType == _allowedType)
            Destroy(_dropped);

        if (imageCoroutine != null
        || textCoroutine != null)
        {
            StopCoroutine(imageCoroutine);
            StopCoroutine(textCoroutine);
            OnDisable();
            yield return new WaitForSeconds(0.1f);
        }

        if (_droppedItemType == _allowedType)
        {
            AudioManager.Instance.PlaySFX("Correct Answer");
            ScoreManager.Instance.score++;
            scoreText.text = ScoreManager.Instance.score.ToString() + "/" + Timer.Instance.level.score;
            imageCoroutine = StartCoroutine(ShowImage(correctImage, 1f));
            textCoroutine = StartCoroutine(ShowImage(correctText, 1f));
        }
        else
        {
            AudioManager.Instance.PlaySFX("Wrong Answer");
            imageCoroutine = StartCoroutine(ShowImage(falseImage, 1f));
            textCoroutine = StartCoroutine(ShowImage(falseText, 1f));
        }
    }
}
