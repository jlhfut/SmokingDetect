using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.validate
{
    public class NumberValidor:ValidateBase
    {
        public NumberValidor(int expression, string errorText) : base(expression, errorText) { }
        public NumberValidor(int expression, int expression2, string errorText) : base(expression,expression2, errorText) { }
        /// <summary>
        /// 验证结果
        /// </summary>
        /// <param name="value">待验证值</param>
        /// <returns></returns>
        public override ValidateResult Validate(object value)
        {
            ValidateResult r = new ValidateResult();
            r.Valid = false;
            r.ErrorTextKey = this.ErrorText;
            int v = 0;
            if (Expression == null || value==null || !int.TryParse(value.ToString(), out v)) return r;
            if (Expression2 != null && Validator.IsInteger(Expression.ToString()) && Validator.IsInteger(Expression2.ToString()))
            {
                r.Valid = v >= int.Parse(Expression.ToString()) && v <= int.Parse(Expression2.ToString());
            }
            if (Expression2 == null && Validator.IsDecimal(Expression.ToString()))
            {
                r.Valid = v == int.Parse(Expression.ToString());
            }
            return r;
        }
    }
}
