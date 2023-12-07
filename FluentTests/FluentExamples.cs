using FluentAssertions;
using FluentAssertions.Extensions; // February, March extension methods

namespace FluentTests
{
    public class FluentExamples
    {
        [Fact]
        public void TestString()
        {
            string city = "London";
            string expectedCity = "London";

            city.Should().StartWith("Lo")
                .And.EndWith("on")
                .And.Contain("do")
                .And.HaveLength(6);

            city.Should().NotBeNull()
                .And.Be(expectedCity)
                .And.BeOfType<string>();

            city.Length.Should().Be(6);
        }

        [Fact]
        public void TestCollections()
        {
            string[] names = new[] { "Alice", "Bob", "Charly" };

            names.Should().HaveCountLessThan(4, "because the maximum items should be 3 or fever");

            names.Should().OnlyContain(name => name.Length <= 6);
        }

        [Fact]
        public void TestDateTimes() 
        {
            DateTime when = new(year: 2022, month: 3, day: 25, hour: 9, minute: 30, second: 0);

            when.Should().Be(25.March(2022).At(9, 30));

            when.Should().BeOnOrAfter(23.March(2022));

            when.Should().NotBeSameDateAs(12.February(2022));

            when.Should().HaveYear(2022);

            DateTime due = new(year: 2022, month:3, day: 25, hour:13, minute: 0, second: 0);

            when.Should().BeAtLeast(2.Hours()).Before(due);
        }
    }
}