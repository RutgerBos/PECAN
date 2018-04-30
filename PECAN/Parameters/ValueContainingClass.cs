using System.Collections.Generic;

namespace PECAN.Parameters
{
    public abstract class ValueContainingClass<T> 
    {
        protected readonly T _Value;

        protected ValueContainingClass(T value)
        {
            _Value = value;
        }

        public T Value => _Value;
        public static implicit operator T(ValueContainingClass<T> obj) => obj.Value;

        public override bool Equals(object obj)
        {
            if (obj is ValueContainingClass<T> other)
            {
                return this.Equals(other);
            }
            else if (obj is T otherValue)
            {
                return this.Equals(otherValue);
            }
            else return false;
        }

        public bool Equals (T value)
        {
            return _Value.Equals(value);
        }

        public bool Equals(Parameter<T> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return -1997769401 + EqualityComparer<T>.Default.GetHashCode(_Value);
        }
    }
}