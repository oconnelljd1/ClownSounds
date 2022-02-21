using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundController
{
    public class DropDownItem : MonoBehaviour
    {
        [SerializeField] DropDownController ddController;
        [SerializeField] Text label;
        [SerializeField] GameObject checkmark;
        [SerializeField] PlayMode playMode;
        [SerializeField] private Toggle toggle;

        // Start is called before the first frame update
        void Awake()
        {
            toggle.onValueChanged.AddListener(SetMode);
        }

        // Update is called once per frame
        void Destroy()
        {
            toggle.onValueChanged.RemoveListener(SetMode);
        }

        public void SetMode(bool active)
        {
            checkmark.SetActive(active);
            if(!active) return;

            ddController.SetItem(label.text);
            SoundController.Instance.SetMode(playMode);
        }
    }
}
