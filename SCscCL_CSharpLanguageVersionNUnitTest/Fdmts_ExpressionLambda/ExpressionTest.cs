using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CsLangVersion.Fdmts_ExpressionLambda
{
    /// <summary>
    /// 合并表达式 And Or  Not扩展
    /// </summary>
    internal static class ExpressionExtend
    {
        /// <summary>
        /// 建立新表达式
        /// </summary>
        private class NewExpressionVisitor : ExpressionVisitor
        {
            public ParameterExpression _NewParameter { get; private set; }
            public NewExpressionVisitor(ParameterExpression param)
            {
                this._NewParameter = param;
            }
            public Expression Replace(Expression exp)
            {
                return this.Visit(exp);
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return this._NewParameter;
            }
        }

        /// <summary>
        /// 合并表达式 expr1 AND expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            //return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), expr1.Parameters);
            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);

            var left = visitor.Replace(expr1.Body);
            var right = visitor.Replace(expr2.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);

        }
        /// <summary>
        /// 合并表达式 expr1 or expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {

            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);

            var left = visitor.Replace(expr1.Body);
            var right = visitor.Replace(expr2.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
        {
            var candidateExpr = expr.Parameters[0];
            var body = Expression.Not(expr.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }
    }
    internal static class ExpressionExt
    {
        public static string ToSqlOperator(this ExpressionType type)
        {
            switch (type)
            {
                case (ExpressionType.AndAlso):
                case (ExpressionType.And):
                    return "AND";
                case (ExpressionType.OrElse):
                case (ExpressionType.Or):
                    return "OR";
                case (ExpressionType.Not):
                    return "NOT";
                case (ExpressionType.NotEqual):
                    return "<>";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case (ExpressionType.Equal):
                    return "=";
                default:
                    throw new Exception("不支持该方法");
            }
        }
    }
    /// <summary>s
    /// 表达式目录树
    /// </summary>
    internal class ExpressionTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void UseExpression_简单调用示例()
        {
            //优雅文法：Lambda，但注意这种写法不支持带大括号的多行写法，如写多行会报错。
            Func<int, int, int> func = (m, n) => m * n + 4;
            Expression<Func<int, int, int>> exp = (m, n) => m * n + 4;

            var funcRes = func.Invoke(5, 8);
            var expRes = exp.Compile().Invoke(5, 8);
        }
        [Test]
        public void UseExpression_简单构造示例()
        {
            Expression<Func<int>> exp = () => 25 + 2;
            //上面等同于下面一连串的构造
            Expression expressionContant25 = Expression.Constant(25, typeof(int));
            Expression expressionContant2 = Expression.Constant(2, typeof(int));
            //就是运算符加号左右两边求和
            BinaryExpression binaryExpression = Expression.Add(expressionContant25, expressionContant2);
            Expression<Func<int>> expression = Expression.Lambda<Func<int>>(binaryExpression, Array.Empty<ParameterExpression>());

        }
        [Test]
        public void UseExpression_简单构造示例1()
        {
            Expression<Func<int, int, int>> expNew = (m, n) => m * n + 2;
            //上面等同于下面一连串的构造
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
            ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");
            //等于两数相乘
            BinaryExpression multipley = Expression.Multiply(parameterExpression, parameterExpression2);
            Expression expressionContant2 = Expression.Constant(2, typeof(int));
            BinaryExpression binaryExpression = Expression.Add(multipley, expressionContant2);
            //传参数的写法
            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(binaryExpression, new ParameterExpression[]
            {
            parameterExpression,
            parameterExpression2
            });
            int iResult = expression.Compile().Invoke(10, 11);
        }
        [Test]
        public void UseExpression_实际应用场景之List()
        {
            //如List当中的Where方法接受的参数是一个Lambda表达式，同时也可以理解为一个表达式目录树。
            var query = new List<int>().AsQueryable();
            query = query.Where(c => c > 1);
            new List<int>().Where(i => i > 1);
						//可见以下的Where方法的定义
						//public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
				}

        private class People
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public int Id;
        }
        [Test]
        public void UseExpression_实际应用场景之实体List()
        {
            //1/2.如果熟悉Lambda表达式，可以先编写Lambda表达式。
            //2/2.反编译以及查看C#编译后代码得到一个相对底层的表达式目录树。

            var peopleQuery = new List<People>().AsQueryable();
            Expression<Func<People, bool>> expression = p => p.Id.ToString().Equals("5");
            peopleQuery.Where(expression);
            //上面等同于下面一连串的构造
            ParameterExpression p = Expression.Parameter(typeof(People), "p");
            FieldInfo fieldId = typeof(People).GetField("Id");
            MemberExpression exp = Expression.Field(p, fieldId);
            MethodInfo toString = typeof(int).GetMethod("ToString", new Type[0]); //如果有多个重载，只输入方法名，反射不知道找哪一个会抛出异常为找不到。第二个参数输入new Type[0]可以解决该问题。
            var toStringExp = Expression.Call(exp, toString, Array.Empty<Expression>());
            MethodInfo equals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
            //如果有多个重载，只输入方法名，反射不知道找哪一个会抛出异常为找不到。第二个参数输入new Type[] { typeof(string) }可以解决该问题。
            Expression expressionContant = Expression.Constant("5");
            var equalsExp = Expression.Call(toStringExp, equals, new Expression[]
            {
                  expressionContant
            });
            Expression<Func<People, bool>> expFinal = Expression.Lambda<Func<People, bool>>(equalsExp, new ParameterExpression[]
            {
                p
            });
            bool bResult = expFinal.Compile().Invoke(new People() { Id = 5 });
        }
        private class OperationsVisitor : ExpressionVisitor//继承Expression的访问者
        {
            public Expression Modify(Expression expression)
            {
                return this.Visit(expression);//来自于ExpressionVisitor的方法，访问者的入口：将表达式分派到该类中更专门化的访问方法之一。
                //可以理解为将更细分的Expression参数传入到对应的方法中去
            }
            protected override Expression VisitBinary(BinaryExpression b)//重写ExpressionVisitor方法中，根据参数类型如果是二元表达式会走到此方法。
            {
                if (b.NodeType == ExpressionType.Add)
                {
                    Expression left = this.Visit(b.Left);
                    Expression right = this.Visit(b.Right);
                    return Expression.Subtract(left, right);
                }
                else if (b.NodeType == ExpressionType.Multiply)
                {

                }
                else if (b.NodeType == ExpressionType.Subtract)
                {

                }
                return base.VisitBinary(b);//来自于ExpressionVisitor的方法
            }
            protected override Expression VisitConstant(ConstantExpression node)//重写ExpressionVisitor方法中，根据参数类型如果是常量表达式会走到此方法。
            {
                return base.VisitConstant(node);//来自于ExpressionVisitor的方法
            }
        }

        [Test]
        public void UseExpression_访问者模式重写_以此达到类似运算符重载的目的()
        {
            //修改表达式目录树
            Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
            OperationsVisitor visitor = new OperationsVisitor();
            //visitor.Visit(exp);
            Expression expNew = visitor.Modify(exp);
            //最终output
        }

        private class ConditionBuilderVisitor : ExpressionVisitor
        {
            private Stack<string> _StringStack = new Stack<string>();
            public string Condition()
            {
                string condition = string.Concat(this._StringStack.ToArray());
                this._StringStack.Clear();
                return condition;
            }

            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (node == null) throw new ArgumentNullException("BinaryExpression");

                this._StringStack.Push(")");
                base.Visit(node.Right);
                //【重点】不同的运算符转换成SQL运算符的方法
                this._StringStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
                base.Visit(node.Left);
                this._StringStack.Push("(");

                return node;
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (node == null) throw new ArgumentNullException("MemberExpression");
                this._StringStack.Push(" [" + node.Member.Name + "] ");
                return node;
            }
            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (node == null) throw new ArgumentNullException("ConstantExpression");
                this._StringStack.Push(" '" + node.Value + "' ");
                return node;
            }
            /// <summary>
            /// 【重点】方法表达式走这个方法
            /// </summary>
            /// <param name="m"></param>
            /// <returns></returns>
            protected override Expression VisitMethodCall(MethodCallExpression m)
            {
                if (m == null) throw new ArgumentNullException("MethodCallExpression");

                string format;
                switch (m.Method.Name)
                {
                    case "StartsWith"://判断方法名称
                        format = "({0} LIKE {1}+'%')";
                        break;

                    case "Contains":
                        format = "({0} LIKE '%'+{1}+'%')";
                        break;

                    case "EndsWith":
                        format = "({0} LIKE '%'+{1})";
                        break;

                    default:
                        throw new NotSupportedException(m.NodeType + " is not supported!");
                }
                this.Visit(m.Object);
                this.Visit(m.Arguments[0]);
                string right = this._StringStack.Pop();
                string left = this._StringStack.Pop();
                this._StringStack.Push(String.Format(format, left, right));

                return m;
            }
        }

        [Test]
        public void UseExpression_访问者模式重写_以此达到Linq2Sql的目的()
        {
            //将以下Lambda使用表达式目录树完成类似于SQL拼接的形式
            Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Id > 5
                                         && x.Name.StartsWith("1")
                                         && x.Name.EndsWith("1")
                                         && x.Name.Contains("1");
            ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
            vistor.Visit(lambda);
            Console.WriteLine(vistor.Condition());
        }
        private class LinqFilterDto
        {
            public Nullable<int> Id { get; set; }
            public string Name { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void UseExpression_实际应用场景之三种编程范式()
        {
            //1/3.拼接SQL方式
            var filterDto = new LinqFilterDto() { Id = 5, Name = "abcd" };
            string sql = "SELECT * FROM USER WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                sql += $" and Name like '%{filterDto.Name}%'";
            }
            if (filterDto.Id.HasValue)
            {
                sql += $" and Id like '%{filterDto.Id}%'";
            }
            //2/3.Linq_Where方式
            var query = new List<LinqFilterDto>().AsQueryable();
            if (filterDto.Id.HasValue)
            {
                query = query.Where(t => t.Id == filterDto.Id.Value);
            }
            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(t => t.Name == filterDto.Name);
            }
            var res = query.ToList();

            //3/3.Expression重新定义表达式通过逐个属性判断方式或者是如上实力使用Visitor
            Expression<Func<People, bool>> expression = null;
            if (filterDto.Id.HasValue)
            {
                expression = p => p.Id == filterDto.Id.Value;//TODO
            }
            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                expression = p => p.Name == filterDto.Name;//TODO
            }
        }
        private static void Do1(Func<People, bool> func)
        {
            List<People> people = new List<People>();
            people.Where(func);
        }
        private static void Do1(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            List<People> peopleList = people.Where(func.Compile()).ToList();
        }

        private static IQueryable<People> GetQueryable(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            return people.AsQueryable<People>().Where(func);
        }
        [Test]
        public void UseExpression_表达式链接()
        {
            #region 表达式链接
            {
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);
                Expression<Func<People, bool>> lambda5 = lambda1.Not();
                Do1(lambda3);
                Do1(lambda4);
                Do1(lambda5);
            }
            #endregion

        }

        [Test]
        public void UseExpression_应用场景之高性能对象赋值()
        {
            //【参考·性能测试】SCscCL_AlgorithmNUnitTest.PerformanceTest.性能测试_ClassAssignment
            //【参考·公共方法】SCscCL_AlgorithmNUnitTest.PerformanceTest.ExpressionGenericMapper
        }
        private class AU_Menu : ISoftDeleted
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public bool IsDeleted { get; set; }
        }
        private interface ISoftDeleted
        {
            public bool IsDeleted { get; set; }
        }
        private Expression<Func<T, bool>> CreateSoftDeletedExpression<T>()
        {
            var param = Expression.Parameter(typeof(T));
            var left = Expression.Property(param, nameof(ISoftDeleted.IsDeleted));
            var right = Expression.Constant(false);
            var body = Expression.Equal(left, right);//判断相等表达式
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }
        [Test]
        public void UseExpression_应用场景之框架封装()
        {
            try
            {
                if (typeof(ISoftDeleted).IsAssignableFrom(typeof(AU_Menu)))
                {
                    CreateSoftDeletedExpression<AU_Menu>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}