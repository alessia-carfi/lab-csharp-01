using System;
using System.Collections.Generic;
using System.Linq;
using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        private List<Complex> _numbers = new List<Complex>();
        private List<char?> _operations = new List<char?>();
        private char? _operation;

        public Complex Value { get; set; }

        public char? Operation {
            get => _operation;
            set 
            {
                _operation = value;
                _operations.Add(Operation);
                _numbers.Add(Value);
                Value = null;
            }
        }

        public Complex ComputeResult()
        {
            if (Value != null)
                _numbers.Add(Value);

            Complex result = _numbers.ElementAt(0);
            for (int i = 1; i < _numbers.Count; i++)
            {
                Complex num = _numbers.ElementAt(i);
                char? op = _operations.ElementAt(i-1);

                result = op == OperationPlus ? result + num : result - num;
            }
            Reset();
            Value = result;
            return result;
        }

        public void Reset()
        {
            Value = null;
            _operation = null;
            _operations = new List<char?>();
            _numbers = new List<Complex>();
        }

        public override string ToString()
        {
            return $"{(Value == null ? "null" : Value)}, {(Operation == null ? "null" : Operation)}";
        }
    }
}