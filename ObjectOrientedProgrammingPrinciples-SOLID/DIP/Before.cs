using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
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

        public Director()
        {
            _builder = new Builder();
        }

        public void BuildObject()
        {
            _builder.Build();
        }
    }

    public class Before
    {
        public void ClientCode()
        {
            Console.WriteLine("BEFORE");
            Director director = new Director();
            director.BuildObject();
            Console.WriteLine("Then builder will be destroyed");
        }
    }
}
