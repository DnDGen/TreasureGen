using Ninject.Activation;
using Ninject.Syntax;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.IoC.Extensions
{
    public static class WhenExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<T> WhenInjectedInto<T>(
            this IBindingWhenSyntax<T> syntax, Type parentType, string name)
        {
            var condition = ComputeMatchCondition<T>(syntax, parentType);
            return syntax.When(request => condition(request)
                && request.ActiveBindings.Any(b => b.Metadata.Name == name));
        }

        private static Func<IRequest, bool> ComputeMatchCondition<T>(
            IBindingWhenSyntax<T> syntax, Type parentType)
        {
            syntax.WhenInjectedInto(parentType);
            return syntax.BindingConfiguration.Condition;
        }
    }
}
