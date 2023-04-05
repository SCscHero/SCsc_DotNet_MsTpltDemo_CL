﻿using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCsc_DesignPattern.FactoryCorrelation.FactoryMethod
{
    /// <summary>
    /// 工厂类    框架原始工厂
    /// </summary>
    public class SixFactory : IFactory
    {
        public virtual IRace CreateInstance()
        {
            IRace race = new Six("Yoyo", 123, new Undead(), new Undead(), new Human(), new NE());//一些具体业务
            return race;
        }
    }


    /// <summary>
    /// 我们扩展的工厂
    /// </summary>
    public class SixFactoryExtend : SixFactory
    {
        public override IRace CreateInstance()
        {
            Console.WriteLine("这里是我们扩展的工厂");

            return base.CreateInstance();
        }
    }

}
