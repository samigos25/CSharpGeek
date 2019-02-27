using System;

namespace Task1
{
    class ComplexClass : IEquatable<ComplexClass>
    {
        #region Private


        /// <summary>
        /// мнимая часть
        /// </summary>
        private double _im = 0;

        /// <summary>
        /// действительное число
        /// </summary>
        private double _re = 0;
        #endregion // end of MyRegion 

        #region Public

        /// <summary>
        /// мнимая часть
        /// </summary>
        public double Im
        {
            get { return _im; }
            set { _im = value; }
        }

        /// <summary>
        /// действительное число
        /// </summary>
        public double Re
        {
            get { return _re; }
            set { _re = value; }
        }
        #endregion // end of MyRegion 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="re">Действительная часть</param>
        /// <param name="im">Мнимая часть</param>
        public ComplexClass(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }

        public ComplexClass() { }
        
        #region Методы - операции над комплексными числами

        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public ComplexClass Subtract(ComplexClass b)
        {
            return new ComplexClass(this.Re - b.Re, this.Im - b.Im);
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Add(ComplexClass x)
        {
            return new ComplexClass(this.Re + x.Re, this.Im + x.Im);
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Multiply(ComplexClass x)
        {
            return new ComplexClass(this.Re * x.Re - this.Im * x.Im, this.Re * x.Im + this.Im * x.Re);
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexClass Devide(ComplexClass x)
        {
            return new ComplexClass((Re * x.Re + Im * x.Im) / (x.Re * x.Re + x.Im * x.Im),
                               (Im * x.Re - Re * x.Im) / (x.Re * x.Re + x.Im * x.Im));
        }
        #endregion // end of MyRegion 

        #region Перегрузка операторов
        public static ComplexClass operator *(ComplexClass a, ComplexClass b)
        {
            return a.Multiply(b);
        }
        public static ComplexClass operator /(ComplexClass a, ComplexClass b)
        {
            return a.Devide(b);
        }
        public static ComplexClass operator -(ComplexClass a, ComplexClass b)
        {
            return a.Subtract(b);
        }
        public static ComplexClass operator +(ComplexClass a, ComplexClass b)
        {
            return a.Add(b);
        }
        public static bool operator ==(ComplexClass a, ComplexClass b)
        {
            if (a is null) return false;
            return a.Equals(b);
        }
        public static bool operator !=(ComplexClass a, ComplexClass b)
        {
            if (a is null) return true;
            return !a.Equals(b);
        }
        #endregion // end of MyRegion 

        public override string ToString()
        {
            return Re + "+" + Im + "i";
        }

        public bool Equals(ComplexClass other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _im.Equals(other._im) && _re.Equals(other._re);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComplexClass)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_im.GetHashCode() * 397) ^ _re.GetHashCode();
            }
        }
    }
}
