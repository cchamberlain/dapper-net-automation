using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace Dapper.Net.Automation.Extensions
{
    public static class AssertExtensions
    {
        /// <summary>
        /// Logs a single-argument test assertion.
        /// </summary>
        /// <typeparam name="T">Type of the assertion argument.</typeparam>
        /// <param name="output">The output logger.</param>
        /// <param name="arg">The assertion argument.</param>
        /// <param name="action">The assertion.</param>
        /// <param name="caller">The calling test (automatic).</param>
        public static void TestLog<T>(this ITestOutputHelper output, T arg, Action<T> action, [CallerMemberName] string caller = null) {
            output.WriteLine($"Test [{caller}] => Asserting {action.GetMethodInfo().Name}\n\t({typeof (T).Name})\n\t{arg}");
            action(arg);
            output.WriteLine($"Test [{caller}] passed!");
        }

        /// <summary>
        /// Logs a double-argument test assertion.
        /// </summary>
        /// <typeparam name="T1">Type of the first assertion argument.</typeparam>
        /// <typeparam name="T2">Type of the second assertion argument.</typeparam>
        /// <param name="output">The output logger.</param>
        /// <param name="arg1">The first assertion argument.</param>
        /// <param name="arg2">The second assertion argument.</param>
        /// <param name="action">The assertion.</param>
        /// <param name="caller">The calling test (automatic).</param>
        public static void TestLog<T1, T2>(this ITestOutputHelper output, T1 arg1, T2 arg2, Action<T1, T2> action, [CallerMemberName] string caller = null) {
            output.WriteLine($"Test [{caller}] => Asserting {action.GetMethodInfo().Name}\n\t({typeof (T1).Name}, {typeof (T2).Name})\n\t{arg1}\n\t{arg2}");
            action(arg1, arg2);
            output.WriteLine($"Test [{caller}] passed!");
        }

        /// <summary>
        /// Logs a triple-argument test assertion.
        /// </summary>
        /// <typeparam name="T1">Type of the first assertion argument.</typeparam>
        /// <typeparam name="T2">Type of the second assertion argument.</typeparam>
        /// <typeparam name="T3">Type of the third assertion argument.</typeparam>
        /// <param name="output">The output logger.</param>
        /// <param name="arg1">The first assertion argument.</param>
        /// <param name="arg2">The second assertion argument.</param>
        /// <param name="arg3">The third assertion argument.</param>
        /// <param name="action">The assertion.</param>
        /// <param name="caller">The calling test (automatic).</param>
        public static void TestLog<T1, T2, T3>(this ITestOutputHelper output, T1 arg1, T2 arg2, T3 arg3, Action<T1, T2, T3> action, [CallerMemberName] string caller = null) {
            output.WriteLine($"Test [{caller}] => Asserting {action.GetMethodInfo().Name}\n\t({typeof (T1).Name}, {typeof (T2).Name}, {typeof (T3).Name})\n\t{arg1}\n\t{arg2}\n\t{arg3}");
            action(arg1, arg2, arg3);
            output.WriteLine($"Test [{caller}] passed!");
        }

        public static void AssertEqual(this string expected, string actual) => Assert.Equal(expected, actual);
        public static void AssertMatches(this string expected, string actual) => Assert.Matches(expected, actual);
    }
}
