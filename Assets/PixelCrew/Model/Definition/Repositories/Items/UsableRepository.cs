﻿using System;
using UnityEngine;

namespace PixelCrew.Model.Definition.Repositories.Items
{
    [CreateAssetMenu(menuName = "Defs/UsableItems", fileName = "UsableItems")]
    public class UsableRepository : DefRepository<UsableDef>
    {
    }

    [Serializable]
    public struct UsableDef : IHaveId
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private float _value;
        [SerializeField] private UseActionDef _action;

        public string Id => _id;
        public float Value => _value;
        public UseActionDef Action => _action;

        public bool IsVoid => string.IsNullOrEmpty(_id);
    }

    public enum UseActionDef
    {
        Heal,
        BoostSpeed
    }
}