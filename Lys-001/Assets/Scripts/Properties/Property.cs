using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityData.Biding.Internal
{
    public class Property 
    {

        private object _value;

        public Property(object value)
            => _value = value;

        public Property() { }

        /// <summary>
        /// onValueChanged를 위한 델리게이트
        /// </summary>
        public delegate void ValueChangedDelegate();

        /// <summary>
        /// 프로피터가 변경된 후 호출
        /// </summary>
        public event ValueChangedDelegate ValueChanged;

        public object Value
        {
            get => _value;
            set
            {
                var isChanged = !Equals(_value, value);
                if (!isChanged) return;
                _value = value;
                ValueChanged?.Invoke();
            }
        }
    }
}