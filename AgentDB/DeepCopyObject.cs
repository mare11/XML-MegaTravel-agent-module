using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace AgentDB
{
    public class DeepCopyObject
    {
        public static T CloneData<T>(object source)
        {
            var target = (T)Activator.CreateInstance(typeof(T));

            Type objTypeBase = source.GetType();
            Type objTypeTarget = target.GetType();

            PropertyInfo _propinfo = null;
            var propInfos = objTypeBase.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propInfo in propInfos)
            {
                try
                {
                    _propinfo = objTypeTarget.GetProperty(propInfo.Name, BindingFlags.Instance | BindingFlags.Public);
                    if (_propinfo != null)
                    {
                        _propinfo.SetValue(target, propInfo.GetValue(source));
                    }
                }
                catch (ArgumentException aex) { if (!string.IsNullOrEmpty(aex.Message)) continue; }
                catch (Exception ex) { if (!string.IsNullOrEmpty(ex.Message)) return default(T); }
            }

            return target;
        }
    }
}
