using System;
using System.Linq.Expressions;
using ReactiveUI;

namespace Commands
{
    public static class WhenAnyValueMixin
    {
        public static IObservable<bool> ObservesProperty<TSource>(
            this TSource target,
            Expression<Func<bool>> property1)
        {
            return target.WhenAnyValue(
                GetExpression<TSource>(property1));
        }
        
        public static IObservable<bool> ObservesProperty<TSource>(
            this TSource target,
            Expression<Func<bool>> property1,
            Expression<Func<bool>> property2)
        {
            return target.WhenAnyValue( 
                GetExpression<TSource>(property1),
                GetExpression<TSource>(property2), 
                (p1, p2) => p1 && p2);
        }

        private static Expression<Func<TSource, bool>> GetExpression<TSource>(
            Expression<Func<bool>> property1)
        {
            // This expression is our goal for the ObservableForProperty():
            // Expression<Func<ReactiveCmdViewModel, bool>> target;
            // And this parameter is a MemberExpression (=> Enabled) (because is a member?)
            if (!(property1.Body is MemberExpression exp)) 
            {    
                // Let user know if is not MemberExpression
                throw new NotSupportedException("MemberExpression expected!");
            }

            // Expression for the Parameter type we need in the goal above, assuming we have a member on TSource.
            var parameter = Expression.Parameter(typeof(TSource));
            // Create Member Access Expression, as in vm => vm.Enabled from the Member Info from the above of course.
            var memberAccess = Expression.MakeMemberAccess(parameter, exp.GetMemberInfo());
            // Create target expression from the member access and parameter expressions so we get vm => vm.Enabled to get it's observable below
            var lambda = Expression.Lambda<Func<TSource, bool>>(memberAccess, parameter);

            return lambda;
            // Fpr reference, started with this
            // return this.ObservableForProperty(lambda,  false, false)
            //     .Select((change, i) => change.Value);
        }
    }
}