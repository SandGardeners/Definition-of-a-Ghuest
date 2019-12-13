using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class SceneLoader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image image;
    public void LoadNextScene()
	{
        GetComponent<Button>().interactable = false;
        GetComponentInChildren<TMPro.TMP_Text>().text = "Checking in...";
        SceneManager.LoadSceneAsync("Demo");
        image.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.gameObject.SetActive(false);
    }
}
