﻿using PixelCrew.Model;
using PixelCrew.Model.Definition;
using PixelCrew.Model.Definition.Repositories;
using PixelCrew.Utils.Disposables;
using UnityEngine;

namespace PixelCrew.UI.Widgets
{
    public class ActivePerksContainer : MonoBehaviour
    {
        [SerializeField] private ActivePerkWidget _prefab;
        
        private DataGroup<PerkDef, ActivePerkWidget> _dataGroup;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private GameSession _session;

        public void Start()
        {
            _session = GameSession.Instance;
            _dataGroup = new DataGroup<PerkDef, ActivePerkWidget>(_prefab, transform);
            _disposable.Retain(_session.PerksModel.Subscribe(OnPerksChanged));
        }
        
        private void OnPerksChanged()
        {
            var perks = _session.PerksModel.GetActivePerks();
            if (perks.Count == 0) return;
            
            var perkDefs = DefsFacade.I.Perks.Get(perks);
            _dataGroup.SetData(perkDefs);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}