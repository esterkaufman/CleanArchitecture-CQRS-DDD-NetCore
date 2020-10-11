using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Moj.Keshet.Repositories.Extensions
{
    public static class ExpressionHelper
    {
        public static string GetPropertyNameFromExpression<T>(Expression<Func<T>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return memberExpression.Member.Name;
        }

        public static string GetPropertyName<TProperty>(Expression<Func<TProperty, object>> expression)
        {
            MemberExpression memberExpression;
            if (expression.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)expression.Body;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = expression.Body as MemberExpression;
            }
            if (memberExpression == null)
                throw new ArgumentException("Expression body must be a member expression");
            return memberExpression.Member.Name;
        }

        public static string GetPropertyName(List<string> expression)
        {
            string stringFormat = null;
            for (int i = 0; i < expression.Count; i++)
            {
                //stringFormat += "{" + i + "}";
                stringFormat += expression[i];
                if (i + 1 != expression.Count)
                    stringFormat += ".";
            }

            return stringFormat;
        }
   

    }
}
