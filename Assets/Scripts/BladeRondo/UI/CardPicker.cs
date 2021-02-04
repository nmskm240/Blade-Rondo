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
        private GameObject Contents;

        private List<int> PickedCards;
        private IFactory<GameObject> CheckmarkFactory;

        private void Awake()
        {
            Hide();
            CheckmarkFactory = new CheckmarkFactory();
            PickedCards = new List<int>();
        }

        public void OnPointerClick(PointerEventData e)
        {
            var go = e.pointerEnter;
            if (go.GetComponent<Card>() != null)
            {
                var attachedAbility = go.transform.Find("AttachedAbility").gameObject;
                if (attachedAbility.transform.childCount == 0)
                {
                    var checkmark = CheckmarkFactory.Create();
                    checkmark.transform.SetParent(attachedAbility.transform);
                    checkmark.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    checkmark.transform.localPosition = new Vector3(0, 0, 0);
                    PickedCards.Add(go.GetComponent<Card>().Id);
                }
                else
                {
                    foreach(Transform tf in attachedAbility.transform)
                    {
                        Destroy(tf.gameObject);
                    }
                    PickedCards.Remove(go.GetComponent<Card>().Id);
                }
            }
        }

        public void SetOptions(IEnumerable<GameObject> cards)
        {
            foreach (var card in cards)
            {
                card.transform.SetParent(Contents.transform);
                card.transform.localScale = new Vector3(1, 1, 1);
            }
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
            foreach(Transform tf in Contents.transform)
            {
                Destroy(tf.gameObject);
            }
        }

        public void OnClickCompletButton()
        {
            PhotonNetwork.LocalPlayer.SetHand(PickedCards);
            PhotonNetwork.LocalPlayer.SetStartCheck(false);
            Hide();
            DestroyAll();
        }
    }
}