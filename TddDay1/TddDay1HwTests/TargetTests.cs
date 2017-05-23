using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TddDay1Hw;

namespace TddDay1HwTests
{
    [TestClass]
    public class TargetTest1
    {
        #region 基本

        [TestMethod]
        public void 三筆一組_取Cost總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                6,15,24,21
            };

            List<int> actual = target.GroupingBy3ProductsReturnSumCost().ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void 四筆一組_取Revenue總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                55,60,66
            };

            List<int> actual = target.GroupingBy4ProductsReturnSumRevenue().ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        #endregion

        #region 任意型別

        [TestMethod]
        public void 任意型別_三筆一組_取Cost總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                6,15,24,21
            };

            List<int> actual = target.GroupingBy3ProductsReturnSumCost<int>().ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void 任意型別_四筆一組_取Revenue總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                55,60,66
            };

            List<int> actual = target.GroupingBy4ProductsReturnSumRevenue<int>().ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        #endregion

        #region 指定筆數

        [TestMethod]
        public void 指定筆數_任意型別_三筆一組_取Cost總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                6,15,24,21
            };
            int count = 3;

            List<int> actual = target.GroupingByNProductsReturnSumCost<int>(count).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void 指定筆數_任意型別_四筆一組_取Revenue總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                55,60,66
            };
            int count = 4;

            List<int> actual = target.GroupingByNProductsReturnSumRevenue<int>(count).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        #endregion

        #region sigma

        [TestMethod]
        public void sigma_指定筆數_任意型別_三筆一組_取Cost總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                6,15,24,21
            };
            int count = 3;

            List<int> actual = target.GroupingByNProductsReturnSum<int>(count, r => r.Cost).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void sigma_指定筆數_任意型別_四筆一組_取Revenue總和()
        {
            var target = new Target();
            var expected = new List<int>
            {
                55,60,66
            };
            int count = 4;

            List<int> actual = target.GroupingByNProductsReturnSumRevenue<int>(count, r => r.Revenue).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        #endregion
    }
}
