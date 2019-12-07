using System;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;

namespace BusinessOpClassLibrary
{
    /// <summary>
    /// Generic class that encapsulates the singleton pattern as seen on
    /// http://www.codeproject.com/KB/architecture/GenericSingletonPattern.aspx
    /// and on
    /// http://www.yoda.arachsys.com/csharp/singleton.html
    /// Usage:
    /// In your singleton class, add a property called Instance (for instance)
    /// and implement it like that (supposing that your class is
    /// named ClassToUseAsSingleton):
    /// <code>
    /// public static ClassToUseAsSingleton Instance
    /// {
    ///   get
    ///   {
    ///     return Singleton&lt;ClassToUseAsSingleton&gt;.Instance;
    ///   }
    /// }
    /// </code>
    /// </summary>
    /// <typeparam name="T">The class that must be instantiated like a Singleton.</typeparam>
    [DebuggerStepThrough]
    public static class Singleton<T>
        where T : class
    {
        /// <summary>
        /// static constructor of the <see cref="Singleton&lt;T&gt;"/> class that
        /// make sure that the initialization of the Instance field is lazy
        /// (that is, the single instance will be created the first time the field
        /// is used and not before).
        /// Please refer to C# and beforefieldinit for more details about this issue.
        /// (http://www.yoda.arachsys.com/csharp/beforefieldinit.html)
        /// </summary>
        static Singleton()
        {
        }

        /// <summary>
        /// The initialization of the Instance field is made by reflection using
        /// the type parameter.
        /// typeof(T) first gets the type of the type parameter, then InvokeMethod
        /// calls its constructor and returns the new instance.
        /// The BindingFlags tells InvokeMethod to create a new instance (CreateInstance)
        /// and to search the constructor in the non-public (NonPublic) instance members
        /// (Instance) of the type.
        /// Using non-public constructors is what makes
        /// it possible for Singleton&lt;T&gt; to, as an example, create an instance
        /// of an internal class from another assembly.
        /// The search doesn't include public members, as it is a best practice to keep
        /// Singleton constructors private (you don't want anybody else to instantiate
        /// these classes).
        /// We use here the default Binder (null), and pass no object reference as
        /// we want to create it (null) nor parameters to the ctor (null).
        /// Beware that InvokeMember can throw an exception if the type parameter
        /// is not a class, as the class constraint also allows interface, delegate,
        /// or array types. There's just so much you can do with these constraints.
        /// </summary>
        public static readonly T Instance = BuildInstance();

        /// <summary>
        /// Builds the instance.
        /// </summary>
        /// <returns></returns>
        private static T BuildInstance()
        {
            try
            {
                return
                    typeof(T).InvokeMember(
                        null, // BindingFlags.CreateInstance => name is ignored
                        BindingFlags.CreateInstance | // Call to .ctor().
                        BindingFlags.Instance | // Method of instance.
                        BindingFlags.NonPublic, // Not public required for a real singleton pattern.
                        null, // No specific binder.
                        null, // Creating instance so, target does not exist yet.
                        null, // No parameters.
                        CultureInfo.InvariantCulture
                        ) as T;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in the .ctor of the singleton for " + typeof(T).FullName, ex);
            }
        }
    }
}
