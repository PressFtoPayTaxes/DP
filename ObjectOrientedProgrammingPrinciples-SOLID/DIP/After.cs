using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_After
{
    class Builder
    {
        public void Build()
        {
            Console.WriteLine("Building something");
        }
    }

    class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void BuildObject()
        {
            _builder.Build();
        }
    }

    public class After
    {
        public void ClientCode()
        {
            Console.WriteLine("AFTER");
            Builder builder = new Builder();
            Director director = new Director(builder);
            director.BuildObject();
            Console.WriteLine("Then builder will be saved");
        }
    }
}
