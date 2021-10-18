using DevExpress.Data.Filtering;
using DevExpress.DataAccess.ExpressionEditor;
using DevExpress.DataProcessing.Criteria;
using System;
using System.Collections.Generic;

namespace Dashboard_StringConcatAggregate {
    class StringConcatFunction : ICustomAggregateFunction, ICustomFunctionOperatorBrowsable, 
        ICustomFunctionCategory {
        public string Name => "StringConcat";

        public int MinOperandCount => 1;

        public int MaxOperandCount => 1;

        public string Description => "Takes strings, aggregates by input value, and displays them separated by commas.";

        public FunctionCategory Category => DevExpress.Data.Filtering.FunctionCategory.Text;

        public string FunctionCategory => "Aggregate";

        public object Evaluate(params object[] operands) {
            throw new NotImplementedException();
        }

        public Type GetAggregationContextType(Type inputType) {	
            return typeof(StringConcatState);	
        }

        public bool IsValidOperandCount(int count) {
            return count <= MaxOperandCount && count >= MinOperandCount;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type) {
            return IsValidOperandCount(operandCount) && operandIndex == 0 && type == typeof(string);
        }

        public Type ResultType(params Type[] operands) {
            return typeof(string);
        }
    }

    class StringConcatState : ICustomAggregateFunctionContext<string, string> {
        List<string> enumeration = new List<string>();
        ISet<string> names = new HashSet<string>();
        public string GetResult() {
            return String.Join(", ", enumeration.ToArray());
        }

        public void Process(string value) {
            if (names.Add(value)) {
                enumeration.Add(value);
            }
        }
    }
}
