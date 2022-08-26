﻿using System;
using System.Linq;
using UnityEngine;

namespace PixelCrew.Model.Definition.Repositories.Items
{
    [CreateAssetMenu(menuName = "Defs/Items", fileName = "Items")]
    public class ItemsRepository : DefRepository<ItemDef>
    {

#if UNITY_EDITOR
        public ItemDef[] ItemsForEditor => _collection;
#endif
    }

    [Serializable]
    public struct ItemDef : IHaveId
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemTag[] _tags;

        public string Id => _id;
        public bool IsStackable => HasTag(ItemTag.Stackable);
        public Sprite Icon => _icon;

        public bool IsVoid => string.IsNullOrEmpty(_id);

        public bool HasTag(ItemTag tag)
        {
            return _tags?.Contains(tag) ?? false;
        }
    }
}
