namespace ComplexAlgebra
{
    using System;
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        public double Phase => Math.Atan2(Imaginary, Real);
    
        public Complex(double re, double im)
        {
            Real = re;
            Imaginary = im;
        }

        public Complex Complement()
        {
            return new Complex(Real, -Imaginary);
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary &&
                   Modulus == complex.Modulus &&
                   Phase == complex.Phase;
        }

        public override string ToString()
        {   
            if (Real == 0 && Imaginary == 0)
                return "0.0";
            String result = Real == 0 ? "" : Real.ToString();
            if (Imaginary == 0)
                return result;
            result += Imaginary > 0 ? $"{(Real > 0 ? "+" : "")}{(Imaginary > 1 ? Imaginary : "")}i" : $"-{(Imaginary > 1 ? Imaginary : "")}i";
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Complex operator +(Complex num1, Complex num2)
        {
            Complex result = new Complex(0, 0);
            result.Real = num1.Real + num2.Real;
            result.Imaginary = num1.Imaginary + num2.Imaginary;
            return result;
        }

        public static Complex operator -(Complex num1, Complex num2)
        {
            Complex result = new Complex(0, 0);
            result.Real = num1.Real - num2.Real;
            result.Imaginary = num1.Imaginary - num2.Imaginary;
            return result;
        }

    }
}