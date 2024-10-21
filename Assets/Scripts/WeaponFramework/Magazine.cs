using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WeaponFramework
{
    public class Magazine
    {
        public string DisplayName;
        
        private MagData _baseData;

        private int _maxAmmo;
        private CartridgeSize _cartridgeSize;
        private GameObject _model;
        private List<(AmmoType, int)> _contents;

        public Magazine(MagData baseData, GameObject model)
        {
            DisplayName = baseData.displayName;
            _baseData = baseData;
            _maxAmmo = baseData.maxCapacity;
            _cartridgeSize = baseData.cartridgeSize;
            _model = model;
        }

        public void FillMag(AmmoType ammoType)
        {
            _contents = new List<(AmmoType, int)> { (ammoType, _maxAmmo) };
        }

        public void InsertRounds(AmmoType ammoType, int count)
        {
            if (_contents[^1].Item1 != ammoType)
            {
                _contents.Add((ammoType, count));
            }
            else
            {
                int originalCount = _contents[^1].Item2;
                _contents[^1] = (ammoType, originalCount + count);
            }
        }

        public AmmoType TakeRound()
        {
            if (_contents.Count == 0)
            {
                return null;
            }
            
            AmmoType ammoType = _contents[^1].Item1;
            int count = _contents[^1].Item2;

            if (count - 1 == 0)
            {
                _contents.Remove(_contents[^1]);
            }
            else
            {
                _contents[^1] = (ammoType, count - 1);
            }
            
            return ammoType;
        }
        
        
    }
}
