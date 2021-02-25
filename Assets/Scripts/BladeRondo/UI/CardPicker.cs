using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.UI
{
    public class CardPicker : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private GameObject _contents;

        private List<int> _pickedCards;
        private IFactory<GameObject> _checkmarkFactory;
        private int _pickMax = 1;
        private int _pickMin = 1;

        private void Awake()
        {
            Hide();
            _checkmarkFactory = new CheckmarkFactory();
            _pickedCards = new List<int>();
        }

        public void OnPointerClick(PointerEventData e)
        {
            var go = e.pointerEnter;
            if (go.GetComponent<Card>() != null)
            {
                var attachedEffect = go.transform.Find("AttachedEffect").gameObject;
                if (attachedEffect.transform.childCount == 0)
                {
                    var checkmark = _checkmarkFactory.Create();
                    checkmark.transform.SetParent(attachedEffect.transform);
                    checkmark.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    checkmark.transform.localPosition = new Vector3(0, 0, 0);
                    _pickedCards.Add(go.GetComponent<Card>().ID);
                }
                else
                {
                    foreach(Transform tf in attachedEffect.transform)
                    {
                        Destroy(tf.gameObject);
                    }
                    _pickedCards.Remove(go.GetComponent<Card>().ID);
                }
            }
        }

        public void SetOptions(IEnumerable<GameObject> cards)
        {
            foreach (var card in cards)
            {
                card.transform.SetParent(_contents.transform);
                card.transform.localScale = new Vector3(1, 1, 1);
                card.GetComponent<CardView>().ToggleFace(true);
            }
        }

        public void SetPickMinAndMax(int min, int max)
        {
            _pickMax = max;
            _pickMin = min;
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void DestroyAll()
        {
            foreach(Transform tf in _contents.transform)
            {
                Destroy(tf.gameObject);
            }
        }

        public void OnClickCompletButton()
        {
            if(_pickMin <= _pickedCards.Count && _pickedCards.Count <= _pickMax)
            {
                PhotonNetwork.LocalPlayer.SetPickCards(_pickedCards);
                PhotonNetwork.LocalPlayer.SetStartCheck(false);
                Hide();
                DestroyAll();
                _pickedCards.Clear();
            }
        }
    }
}