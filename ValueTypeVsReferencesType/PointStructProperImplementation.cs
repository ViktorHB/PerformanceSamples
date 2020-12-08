using System;

namespace ValueTypeVsReferencesType
{
    /// <summary>
    /// A value type that properly imlpements the equals method to avoid boxin and reflection
    /// </summary>
    internal struct PointStructProperImplementation : IEquatable<PointStructProperImplementation>
    {
        public int x;
        public int y;

        public override bool Equals(object obj)
        {
            return obj is PointStructProperImplementation && Equals((PointStructProperImplementation)obj);
        }

        public bool Equals(PointStructProperImplementation other)
        {
            return x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PointStructProperImplementation point1, PointStructProperImplementation point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(PointStructProperImplementation point1, PointStructProperImplementation point2)
        {
            return !(point1 == point2);
        }
    }
}