using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prjShoeStore.PageLists
{
    public enum ELogic
    {
        And, Or
    }
    public enum EOrder
    {
        Ascending, Descending
    }
    public class PropFilter
    {
        public ELogic Logic { get; set; } = ELogic.And;
        public bool IsExactly { get; set; } = true;
        public string FieldName { get; set; }
        public string Value { get; set; }
        public IList<PropFilter> Scopes { get; set; }
        [JsonIgnore]
        public bool IsScope { get => Scopes?.Count > 1; }
        [JsonIgnore]
        public bool IsSingleField { get => !string.IsNullOrWhiteSpace(FieldName); }
    }
    public class PropOrderBy
    {
        public EOrder Type { get; set; } = EOrder.Ascending;
        public string FieldName { get; set; }
    }
    public class ModelFilter<TModel> where TModel : class
    {
        public int? Page { get; set; }
        public int? Amount { get; set; }

        public IList<PropFilter> PropFilters { get; set; }
        public IList<PropOrderBy> PropOrders { get; set; }
        public LinqWhereBuild<TModel> GetBuilder()
        {
            return new LinqWhereBuild<TModel>(this);
        }


    }
    public class LinqWhereBuild<TModel> where TModel : class
    {
        public ModelFilter<TModel> ModelFilter { get; set; }
        public Type TypeModel { get; set; }
        public Type StringType = typeof(string);
        public MethodInfo ContainsMethod { get => StringType.GetMethod("Contains", new[] { StringType }); }
        public ParameterExpression ModelExpr { get; set; }
        public LinqWhereBuild(ModelFilter<TModel> modelFilter)
        {
            ModelFilter = modelFilter;
            TypeModel = typeof(TModel);
            ModelExpr = Expression.Parameter(TypeModel);
        }
        public Expression StringContainExpress(string Name, string Value)
        {
            var PropExpr = PropToStringMethod(Name);


            return Expression.Call(PropExpr, ContainsMethod, Expression.Constant(Value));
        }

        public Expression StringExpress(string Name, string Value)
        {
            var PropExpr = PropToStringMethod(Name);

            var tmps = Value.Split(" ").Select(x => x.Trim()).ToArray();
            var Operator = "";
            if (tmps.Length == 2 && tmps[0] == "!=")
            {
                Operator = tmps[0];
                Value = tmps[1];
            }

            var ExpressOperator = SelectExpresion(Operator);

            return ExpressOperator(PropExpr, Expression.Constant(Value));
        }
        public Expression PropToStringMethod(string Name)
        {
            //var PropInfo = TypeModel.GetProperty(Name);
            //var ToString = PropInfo.PropertyType.GetMethod("ToString", Type.EmptyTypes);
            //var PropExpr = Expression.Property(ModelExpr, PropInfo);
            //return Expression.Call(PropExpr, ToString);

            var PropInfo = TypeModel.GetProperty(Name);
            var PropExpr = Expression.Property(ModelExpr, PropInfo);
            return PropExpr;
        }
        public Expression ScopeExpress(IList<PropFilter> propFilters)
        {
            Expression expression = null;// SingleExpress(propFilters.First());

            var propsFirst = propFilters.First();
            if (propsFirst.IsSingleField)
            {
                expression = SingleExpress(propsFirst);
            }
            else if (propsFirst.IsScope)
            {
                expression = ScopeExpress(propsFirst.Scopes);
            }

            for (int i = 1; i < propFilters.Count; i++)
            {
                var prop = propFilters[i];
                Expression expr = null;
                if (prop.IsSingleField)
                {
                    expr = SingleExpress(prop);
                }
                else if (prop.IsScope)
                {
                    expr = ScopeExpress(prop.Scopes);
                }
                else
                {
                    continue;
                }

                expression = prop.Logic == ELogic.And ?
                  prop.IsScope ? Expression.AndAlso(expression, expr) : Expression.And(expression, expr) :
                   prop.IsScope ? Expression.OrElse(expression, expr) : Expression.Or(expression, expr);
            }

            return expression;
        }
        public static bool IsNumericType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public Func<Expression, Expression, BinaryExpression> SelectExpresion(string Operator)
        {
            switch (Operator)
            {
                case ">":
                    {
                        return Expression.GreaterThan;
                    }
                case "<":
                    {
                        return Expression.LessThan;
                    }
                case ">=":
                    {
                        return Expression.GreaterThanOrEqual;
                    }
                case "<=":
                    {
                        return Expression.LessThanOrEqual;
                    }
                case "!=":
                    {
                        return Expression.NotEqual;
                    }
                default:
                    return Expression.Equal;
            }
        }

        public Expression SingleExpress(PropFilter prop)
        {
            var PropInfo = TypeModel.GetProperty(prop.FieldName);
            if (PropInfo.PropertyType == StringType)
            {
                return !prop.IsExactly ? StringContainExpress(prop.FieldName, prop.Value) : StringExpress(prop.FieldName, prop.Value);
            }
            else 
            {
                var Value = prop.Value.Trim();
                var tmps = Value.Split(" ");
                var Operator = "";
                if (tmps.Length == 2)
                {
                    Operator = tmps[0].Trim();
                    Value = tmps[1].Trim();
                }

                var ExpressOperator = SelectExpresion(Operator);
                var typeConverter = TypeDescriptor.GetConverter(PropInfo.PropertyType);

                var valueExpr = Expression.Constant(typeConverter.ConvertFromString(Value));

                var PropExpr = Expression.Property(ModelExpr, PropInfo);

                return ExpressOperator(PropExpr, valueExpr);
            }
            //else
            //{
            //    throw new Exception("Does not support different numbers and strings!");
            //}

        }

        public Expression<Func<TModel, bool>> BuildLinq()
        {

            RemoveFieldNotExist(ModelFilter.PropFilters, x => x.FieldName);

            var propFilter = ModelFilter.PropFilters;
            if (propFilter == null || propFilter.Count < 1)
            {
                return null;
            }

            var exprBody = ScopeExpress(ModelFilter.PropFilters);
            return Expression.Lambda<Func<TModel, bool>>(exprBody, ModelExpr);
        }


        public IList<TProp> RemoveFieldNotExist<TProp>(IList<TProp> props, Func<TProp, string> selector) where TProp : class
        {
            if (props == null) return null;
            var Fields = TypeModel.GetProperties().Select(x => x.Name).ToHashSet();
            var tmp = new List<TProp>();
            foreach (var prop in props)
            {
                if (!Fields.Contains(selector(prop)))
                {
                    tmp.Add(prop);
                }
            }
            foreach (var item in tmp)
            {
                props.Remove(item);
            }
            return tmp;
        }

        private Expression<Func<TModel, dynamic>> BuildOrderby(PropOrderBy propOrderBy)
        {

            var propInfo = TypeModel.GetProperty(propOrderBy.FieldName);
            var propExpr = Expression.Property(ModelExpr, propInfo);
            var typeLabel = Expression.Label(propInfo.PropertyType);
            var labelReturn = Expression.Return(typeLabel, propExpr);
            return Expression.Lambda<Func<TModel, dynamic>>(labelReturn, ModelExpr);
        }

        public IQueryable<TModel> OrderBy(IQueryable<TModel> models)
        {
            RemoveFieldNotExist(ModelFilter.PropOrders, x => x.FieldName);

            var PropOrders = ModelFilter.PropOrders;
            if (PropOrders == null || PropOrders.Count < 1)
            {
                return models;
            }
            IOrderedQueryable<TModel> qrOrderBy = null;
            var proporder = PropOrders.First();
            if (proporder.Type == EOrder.Descending)
            {
                qrOrderBy = models.OrderByDescending(BuildOrderby(proporder));
            }
            else
            {
                qrOrderBy = models.OrderBy(BuildOrderby(proporder));
            }

            for (int i = 1; i < PropOrders.Count; i++)
            {
                proporder = PropOrders[i];
                if (proporder.Type == EOrder.Descending)
                {
                    qrOrderBy = qrOrderBy.ThenByDescending(BuildOrderby(proporder));
                }
                else
                {
                    qrOrderBy = qrOrderBy.ThenBy(BuildOrderby(proporder));
                }
            }

            return qrOrderBy;
        }

    }
}
