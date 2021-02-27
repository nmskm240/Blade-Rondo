using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using BladeRondo.Game.Effect;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class AttachedEffect
    {
        public static readonly string _attachedeffectPros = "AttachedEffect";

        public static void SetAttachEffects(this Player player, IEnumerable<IEffect> effects)
        {
            if (player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            var effectNames = new List<string>();
            foreach (var effect in effects)
            {
                effectNames.Add(effect.GetType().FullName);
            }
            hashtable[_attachedeffectPros] = effectNames.ToArray();
            player.SetCustomProperties(hashtable);
        }

        public static void SetAttachEffect(this Player player, IEffect effect)
        {
            if (player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_attachedeffectPros] = effect.GetType().FullName;
            player.SetCustomProperties(hashtable);
        }

        public static List<IEffect> GetAttachedEffects(this Player player)
        {
            if (player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_attachedeffectPros))
            {
                return null;
            }

            var attachedEffects = new List<IEffect>();
            var effectNames = player.CustomProperties[_attachedeffectPros] as string[];
            foreach (var effectName in effectNames)
            {
                var type = Type.GetType(effectName);
                attachedEffects.Add(Activator.CreateInstance(type) as IEffect);
            }
            return attachedEffects;
        }

        public static void AttachEffect(this Player player, IEffect effect)
        {
            if (player == null || player.CustomProperties == null)
            {
                return;
            }

            var currentAttachedEffects = player.GetAttachedEffects();
            if (currentAttachedEffects == null)
            {
                player.SetAttachEffect(effect);
            }
            else
            {
                currentAttachedEffects.Add(effect);
                player.SetAttachEffects(currentAttachedEffects);
            }

        }
    }
}