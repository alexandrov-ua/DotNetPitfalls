using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetPitfalls
{
    public class InitOnlyProperties
    {
        private class MyAwesomeDto
        {
            public string Name { get; init; }
        }

        [Fact]
        public void LooksLegit()
        {
            var myAwesomeInstance = new MyAwesomeDto
            {
                Name = "Foo"
            };

            // can't do this:
            // myAwesomeInstance.Name = "Bar";
            // but fear not!
            LolWat(myAwesomeInstance);

            Assert.Equal("Bar", myAwesomeInstance.Name);
        }

        private static void LolWat(MyAwesomeDto instance)
            => typeof(MyAwesomeDto)
                .GetProperty(nameof(MyAwesomeDto.Name))
                .SetValue(instance, "Bar");
    }
}
