using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace ihaiu.NDraws
{
    public static class CustomAttributeHelpers
    {
        private static readonly Dictionary<Type, object[]>          TypeCustomAttributesLookup  = new Dictionary<Type, object[]>();
        private static readonly Dictionary<FieldInfo, object[]>     FieldCustomAttributesLookup = new Dictionary<FieldInfo, object[]>();
        public static object[] GetCustomAttributes(Type type)
        {
            object[] customAttributes;
            if (!TypeCustomAttributesLookup.TryGetValue(type, ref customAttributes))
            {
                customAttributes = type.GetCustomAttributes(true);
                TypeCustomAttributesLookup.Add(type, customAttributes);
            }
            return customAttributes;
        }
        public static IEnumerable<Attribute> GetAttributes(Type type, Type attributeType)
        {
            object[] customAttributes = GetCustomAttributes(type);
            List<Attribute> list = new List<Attribute>();
            object[] array = customAttributes;
            for (int i = 0; i < array.Length; i++)
            {
                object obj = array[i];
                if (obj.GetType() == attributeType)
                {
                    list.Add(obj as Attribute);
                }
            }
            return list;
        }
        public static IEnumerable<T> GetAttributes<T>(Type type) where T : Attribute
        {
            return GetAttributes<T>(type.GetCustomAttributes(true));
        }
        public static IEnumerable<T> GetAttributes<T>(FieldInfo field) where T : Attribute
        {
            return GetAttributes<T>(field.GetCustomAttributes(true));
        }
        public static IEnumerable<T> GetAttributes<T>(IEnumerable<object> attributes) where T : Attribute
        {
            List<T> list = new List<T>();
            using (IEnumerator<object> enumerator = attributes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    if (current is T)
                    {
                        list.Add(current as T);
                    }
                }
            }
            return list;
        }
        public static object[] GetCustomAttributes(FieldInfo field)
        {
            object[] customAttributes;
            if (!FieldCustomAttributesLookup.TryGetValue(field, ref customAttributes))
            {
                customAttributes = field.GetCustomAttributes(true);
                FieldCustomAttributesLookup.Add(field, customAttributes);
            }
            return customAttributes;
        }
        public static bool HasAttribute<T>(IEnumerable<object> attributes) where T : Attribute
        {
            if (attributes == null)
            {
                return false;
            }
            using (IEnumerator<object> enumerator = attributes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Attribute attribute = (Attribute)enumerator.Current;
                    if (attribute is T)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool HasAttribute<T>(FieldInfo field) where T : Attribute
        {
            return HasAttribute<T>(field.GetCustomAttributes(true));
        }
        public static bool HasAttribute<T>(Type type) where T : Attribute
        {
            return HasAttribute<T>(type.GetCustomAttributes(true));
        }
        public static T GetAttribute<T>(FieldInfo fieldInfo) where T : Attribute
        {
            return GetAttribute<T>(fieldInfo.GetCustomAttributes(true));
        }
        public static T GetAttribute<T>(Type type) where T : Attribute
        {
            return GetAttribute<T>(GetCustomAttributes(type) as Attribute[]);
        }
        public static T GetAttribute<T>(IEnumerable<object> attributes) where T : Attribute
        {
            if (attributes == null)
            {
                return default(T);
            }
            using (IEnumerator<object> enumerator = attributes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Attribute attribute = (Attribute)enumerator.Current;
                    T t = attribute as T;
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return default(T);
        }
        public static string GetTitle(IEnumerable<object> attributes)
        {
            TitleAttribute attribute = GetAttribute<TitleAttribute>(attributes);
            if (attribute == null)
            {
                return null;
            }
            return attribute.Text;
        }
        public static string GetNote(IEnumerable<object> attributes)
        {
            NoteAttribute attribute = GetAttribute<NoteAttribute>(attributes);
            if (attribute == null)
            {
                return null;
            }
            return attribute.Text;
        }
        public static string GetActionSection(IEnumerable<object> attributes)
        {
            ActionSection attribute = GetAttribute<ActionSection>(attributes);
            if (attribute == null)
            {
                return null;
            }
            return attribute.Section;
        }
        public static string GetTooltip(Type type, IEnumerable<object> attributes)
        {
            string text = Labels.GetTypeTooltip(type);
            TooltipAttribute attribute = GetAttribute<TooltipAttribute>(attributes);
            if (attribute != null)
            {
                text = text + Environment.NewLine + attribute.Text;
            }
            return text;
        }
        public static Type GetObjectType(object[] attributes, Type defaultType = null)
        {
            ObjectTypeAttribute attribute = GetAttribute<ObjectTypeAttribute>(attributes);
            if (attribute != null)
            {
                return attribute.ObjectType;
            }
            return defaultType ?? typeof(System.Object);
        }
        public static UIHint GetUIHint(object[] attributes)
        {
            UIHintAttribute attribute = GetAttribute<UIHintAttribute>(attributes);
            if (attribute == null)
            {
                return 0;
            }
            return attribute.Hint;
        }
        public static bool HasUIHint(FieldInfo field, UIHint uiHintValue)
        {
            return HasUIHint(field.GetCustomAttributes(true), uiHintValue);
        }
        public static bool HasUIHint(object[] attributes, UIHint uiHintValue)
        {
            IEnumerable<UIHintAttribute> attributes2 = GetAttributes<UIHintAttribute>(attributes);
            return Enumerable.Any<UIHintAttribute>(attributes2, (UIHintAttribute uiHint) => uiHint.Hint == uiHintValue);
        }
        public static bool IsObsolete(Type type)
        {
            if (type == null)
            {
                return true;
            }
            object[] customAttributes = GetCustomAttributes(type);
            return Enumerable.Any<ObsoleteAttribute>(Enumerable.OfType<ObsoleteAttribute>(customAttributes));
        }
        public static string GetObsoleteMessage(Type type)
        {
            if (type == null)
            {
                return "";
            }
            object[] customAttributes = GetCustomAttributes(type);
            object[] array = customAttributes;
            for (int i = 0; i < array.Length; i++)
            {
                object obj = array[i];
                ObsoleteAttribute obsoleteAttribute = obj as ObsoleteAttribute;
                if (obsoleteAttribute != null)
                {
                    return obsoleteAttribute.Message;
                }
            }
            return "";
        }
    }
}
