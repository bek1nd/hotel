using System.Linq.Expressions;

namespace Mzl.Common.ExpressionHelper
{
    /// <summary>
    /// 建立新表达式
    /// </summary>
    internal class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression NewParameter { get; }
        public NewExpressionVisitor(ParameterExpression param)
        {
            this.NewParameter = param;
        }
        public Expression Replace(Expression exp)
        {
            return this.Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.NewParameter;
        }
    }
}
