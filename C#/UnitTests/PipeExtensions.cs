using System;
using System.Diagnostics;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace UnitTests
{
    public static class PipeExtensions
    {
        /// <summary>Functional pipe operation. Maps any object to another one</summary>
        [DebuggerStepThrough]
        public static OutputType To<InputType, OutputType>(this InputType obj, Func<InputType, OutputType> fun)
            => fun(obj);
        
        /// <summary>Asynchronous functional pipe operation. Maps any object to another one</summary>
        [DebuggerStepThrough]
        public static async Task<OutputType> To<InputType, OutputType>(this Task<InputType> obj, Func<InputType, OutputType> fun)
            => fun(await obj);

        /// <summary>Asynchronous functional pipe operation with additional parameter. Maps any object to another one</summary>
        [DebuggerStepThrough]
        public static async Task<OutputType> To<InputType, AdditionalParam, OutputType>(this Task<InputType> obj, Func<InputType, AdditionalParam, OutputType> fun, AdditionalParam param)
            => fun(await obj, param);

        /// <summary>Functional pipe operation with side-effect. Executes action and returns (potentially changed) input object</summary>
        [DebuggerStepThrough]
        public static T Do<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
        
        /// <summary>Asynchronous functional pipe operation with side-effect. Executes action and returns (potentially changed) input object</summary>
        [DebuggerStepThrough]
        public static async Task<T> Do<T>(this Task<T> obj, Action<T> action)
        {
            var objAwaited = await obj;
            action(objAwaited);
            return objAwaited;
        }
    }
}
