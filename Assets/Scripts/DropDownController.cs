using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownController : MonoBehaviour
{
    [SerializeField]private Button button;
    [SerializeField]private GameObject list;
    [SerializeField]private Transform arrow;
    [SerializeField]private Text label;

    // Start is called before the first frame update
    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Destroy()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        list.SetActive(!list.activeInHierarchy);
        ToggleArrowScale(!list.activeInHierarchy);
    }

    public void SetItem(string text)
    {
        label.text = text;
        list.SetActive(false);
        ToggleArrowScale(true);
    }

    private void ToggleArrowScale(bool positive)
    {
        Vector3 scale = arrow.localScale;
        if(positive)
            scale.y = Mathf.Abs(scale.y);
        else
            scale.y = Mathf.Abs(scale.y) * -1f;
        arrow.localScale = scale;
    }
}
