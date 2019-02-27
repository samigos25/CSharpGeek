using System;

namespace Task3
{
    /// <summary>
    /// Класс описывающий обыкновенную дробь.
    /// </summary>
    public class Fraction:IEquatable<Fraction>
    {

        private double _decimalFraction;
        #region Property
        /// <summary>
        /// Числитель, целое число
        /// </summary>
        private long _numerator = 1;

        /// <summary>
        /// Знаменатель, натуральное число больше 0,
        /// </summary>
        private long _denominator = 1;

        /// <summary>
        /// Числитель
        /// </summary>
        public long Numerator
        {
            get { return _numerator; }
            set
            {
                _numerator = value;
                DecimalFraction = Numerator / (double)Denominator;
            }
        }

        /// <summary>
        /// Знаменатель
        /// </summary>
        public long Denominator
        {
            get { return _denominator; }
            set
            {
                if (value > 0)
                {
                    _denominator = value;
                    DecimalFraction = Numerator / (double)Denominator;
                }
                else
                    throw new System.ArgumentException("Знаменатель не может быть меньше или равен 0", nameof(Denominator));
            }
        }

        public double DecimalFraction
        {
            get { return _decimalFraction; }
            private set { _decimalFraction = value; }
        }

        #endregion // end of MyRegion 

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель. Должен быть больше 0</param>
        /// /// <param name="simplify">Упростить дробь</param>
        public Fraction(long numerator, long denominator, bool simplify = false)
        {
            Numerator = numerator;
            Denominator = denominator;
            if (simplify) Simplify();
        }
        public Fraction() { }


        #region Перегрузка операторов

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return a.Add(b);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a.Substract(b);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return a.Multiply(b);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a.Devide(b);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a is null) return true;
            return !a.Equals(b);
        }
        #endregion // end of MyRegion 


        public Fraction Devide(Fraction x)
        {
            long numer = Numerator * x.Denominator;
            if (x.Numerator < 0) numer *= -1;
            return Simplify(numer, Denominator * (long)Math.Abs(x.Numerator));
        }
        public Fraction Multiply(Fraction x)
        {
            return Simplify(Numerator * x.Numerator, Denominator * x.Denominator);
        }
        public Fraction Add(Fraction x)
        {
            long denom = FindNok(Denominator, x.Denominator);
            long a = Numerator * (denom / Denominator);
            long b = x.Numerator * (denom / x.Denominator);
            return Simplify(a + b, denom);
        }
        public Fraction Substract(Fraction x)
        {
            long denom = FindNok(Denominator, x.Denominator);
            long a = Numerator * (denom / Denominator);
            long b = x.Numerator * (denom / x.Denominator);
            return Simplify(a - b, denom);
        }
        public override string ToString()
        {
            return String.Format($"{Numerator} / {Denominator}");
        }
        /// <summary>
        /// Поиск наименьшего общего кратного (знаменателя)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private long FindNok(long a, long b)
        {
            return a * b / FindNod(a, b);
        }
        /// <summary>
        /// Поиск наибольшего общего делителя
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private long FindNod(long a, long b)
        {
            long less, more;
            less = Math.Min(Math.Abs(a), b);
            more = Math.Max(Math.Abs(a), b);

            long remainder;

            while ((remainder = more % less) != 0)
            {
                more = remainder;
                (more, less) = (less, more);
            }

            return less;
        }
        
        /// <summary>
        /// Упрощение
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        private Fraction Simplify(long numerator, long denominator)
        {
            long nod = FindNod(numerator, denominator);
            return new Fraction(numerator / nod, denominator / nod);
        }

        /// <summary>
        ///Упрощение дроби
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возвращает новый экземпляр дроби</returns>
        public Fraction Simplify(Fraction a)
        {
            return Simplify(a.Numerator, a.Denominator);
        }

        /// <summary>
        /// Упрощает дробь
        /// </summary>
        public void Simplify()
        {
            long nod = FindNod(Numerator, Denominator);
            Numerator /= nod;
            Denominator /= nod;

        }

        public bool Equals(Fraction other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _numerator == other._numerator && _denominator == other._denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_numerator.GetHashCode() * 397) ^ _denominator.GetHashCode();
            }
        }
    }
}
