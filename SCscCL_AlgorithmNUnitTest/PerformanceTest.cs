using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System;
using SCscCL_AlgorithmNUnitTest;


namespace SCscCL_AlgorithmNUnitTest
{
    internal class PerformanceTest
    {
        [SetUp]
        public void TestSetup()
        {

        }
        private class People
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public int Id;
        }
        private class PeopleSame
        {

            public int Age { get; set; }
            public string Name { get; set; }
            public int Id;
        }
        public static TOut SerializeTrans<TIn, TOut>(TIn tIn)
        {
            return JsonConvert.DeserializeObject<TOut>(JsonConvert.SerializeObject(tIn));
        }
        /// <summary>
        /// 反射
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        private TOut ReflectTrans<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var propIn = tIn.GetType().GetProperty(itemOut.Name);
                itemOut.SetValue(tOut, propIn.GetValue(tIn));
                //foreach (var itemIn in tIn.GetType().GetProperties())
                //{
                //    if (itemOut.Name.Equals(itemIn.Name))
                //    {
                //        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                //        break;
                //    }
                //}
            }
            foreach (var itemOut in tOut.GetType().GetFields())
            {
                var fieldIn = tIn.GetType().GetField(itemOut.Name);
                itemOut.SetValue(tOut, fieldIn.GetValue(tIn));
                //foreach (var itemIn in tIn.GetType().GetFields())
                //{
                //    if (itemOut.Name.Equals(itemIn.Name))
                //    {
                //        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                //        break;
                //    }
                //}
            }
            return tOut;
        }

        /// <summary>
        /// 字典缓存--hash分布
        /// </summary>
        private static Dictionary<string, object> _Dic = new Dictionary<string, object>();

        /// <summary>
        /// 字典缓存表达式树
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public TOut ExpressionTrans<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("funckey_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
                {
                    parameterExpression
                });
                Func<TIn, TOut> func = lambda.Compile();//拼装是一次性的
                _Dic[key] = func;
            }
            return ((Func<TIn, TOut>)_Dic[key]).Invoke(tIn);
        }

        /// <summary>
        /// 生成表达式目录树  泛型缓存
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public class ExpressionGenericMapper<TIn, TOut>//Mapper`2
        {
            private static Func<TIn, TOut> _FUNC = null;
            static ExpressionGenericMapper()
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
                {
                    parameterExpression
                });
                _FUNC = lambda.Compile();//拼装是一次性的
            }
            public static TOut Trans(TIn t)
            {
                return _FUNC(t);
            }
        }



        [Test]
        public void 性能测试_ClassAssignment()
        {

            People people = new People()
            {
                Id = 11,
                Name = "SCscHero",
                Age = 31
            };
            long ClassMemberAssign = 0;//对象间直接赋值
            long ExpressionGeneric = 0;//
            long cache = 0;
            long reflection = 0;
            long serialize = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleSame samePeople = new PeopleSame()
                    {
                        Id = people.Id,
                        Name = people.Name,
                        Age = people.Age
                    };
                }
                watch.Stop();
                ClassMemberAssign = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleSame samePeople = ReflectTrans<People, PeopleSame>(people);
                }
                watch.Stop();
                reflection = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleSame samePeople = SerializeTrans<People, PeopleSame>(people);
                }
                watch.Stop();
                serialize = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleSame samePeople = ExpressionTrans<People, PeopleSame>(people);
                }
                watch.Stop();
                cache = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleSame samePeople = ExpressionGenericMapper<People, PeopleSame>.Trans(people);
                }
                watch.Stop();
                ExpressionGeneric = watch.ElapsedMilliseconds;
            }
            { //AutoMapper
                //Stopwatch watch = new Stopwatch();
                //watch.Start();
                //for (int i = 0; i < 1_000_000; i++)
                //{
                //    var resMapper = AutoMapperConfigurationSE.Mapper.Map<samePeople>(people);
                //}
                //watch.Stop();
                //Console.WriteLine("Automapper = " + watch.ElapsedMilliseconds + " ms");
            }
            Console.WriteLine($"{nameof(ClassMemberAssign)} = {ClassMemberAssign} ms");
            Console.WriteLine($"{nameof(reflection)} = {reflection} ms");
            Console.WriteLine($"{nameof(serialize)} = {serialize} ms");
            Console.WriteLine($"{nameof(cache)} = {cache} ms");
            Console.WriteLine($"{nameof(ExpressionGeneric)} = {ExpressionGeneric} ms");
            Console.WriteLine("Automapper  700  ms");
            /*
                ClassMemberAssign = 59 ms
                ExpressionGeneric = 54 ms
                cache = 558 ms
                reflection = 1559 ms
                serialize = 5019 ms
                Automapper = 669 ms
             */
            //【总结】ClassMemberAssign=ExpressionGeneric>Cache>Automapper>Reflection>Serialize
        }

    }
}
