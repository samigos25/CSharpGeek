using System;

namespace Task1
{
    struct ComplexStruct: IEquatable<ComplexStruct>
    {
        /// <summary>
        /// мнимая единица
        /// </summary>
        public double Im { get; set; }

        /// <summary>
        /// действительное число
        /// </summary>
        public double Re { get; set; }

        public ComplexStruct(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public ComplexStruct Subtract(ComplexStruct b)
        {
            return new ComplexStruct(this.Re - b.Re, this.Im - b.Im);
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Add(ComplexStruct x)
        {
            return new ComplexStruct(this.Re + x.Re, this.Im + x.Im);
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Multiply(ComplexStruct x)
        {
            return new ComplexStruct(this.Re * x.Re - this.Im * x.Im, this.Re * x.Im + this.Im * x.Re);
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Devide(ComplexStruct x)
        {
            return new ComplexStruct((Re * x.Re + Im * x.Im) / (x.Re * x.Re + x.Im * x.Im), 
                               (Im * x.Re - Re * x.Im) / (x.Re * x.Re + x.Im * x.Im));
        }
        public static ComplexStruct operator *(ComplexStruct a, ComplexStruct b)
        {
            return a.Multiply(b);
        }
        public static ComplexStruct operator / (ComplexStruct a, ComplexStruct b)
        {
            return a.Devide(b);
        }
        public static ComplexStruct operator - (ComplexStruct a, ComplexStruct b)
        {
            return a.Subtract(b);
        }
        public static ComplexStruct operator + (ComplexStruct a, ComplexStruct b)
        {
            return a.Add(b);
        }

        public override string ToString()
        {
            return Re + "+" + Im + "i";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Im.GetHashCode() * 397) ^ Re.GetHashCode();
            }
        }

        public static bool operator == (ComplexStruct a, ComplexStruct b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ComplexStruct a, ComplexStruct b)
        {
            return !a.Equals(b);
        }

        public bool Equals(ComplexStruct other)
        {
            return Im.Equals(other.Im) && Re.Equals(other.Re);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ComplexStruct other && Equals(other);
        }
    }

}
