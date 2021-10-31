using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Linq;

namespace AssetManager.Utils
{
    public abstract class Enumeration : IComparable
    {

        public int Id { get; init; }

        public string Label { get; init; }

        protected Enumeration(int id, string label) {
            Id = id;
            Label = label;
        }

        private static readonly IReadOnlyCollection<Enumeration> _allOptions 
            = ImmutableList<Enumeration>.Empty;

        public static T FromLabel<T>(string label) where T : Enumeration {
            return GetAll<T>().First((e) => e.Label == label);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly
            )
                .Select(fi => fi.GetValue(null) as T)
                .Where((v) => v != null);
        }
        
        public int CompareTo(object obj) {
            return Id.CompareTo(((Enumeration) obj).Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}