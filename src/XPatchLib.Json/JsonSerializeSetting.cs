﻿// Copyright © 2013-2018 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;

namespace XPatchLib
{
    /// <summary>
    ///     JSON类型写入器的默认设置。
    /// </summary>
    /// <seealso cref="XPatchLib.ISerializeSetting" />
    public class JsonSerializeSetting : SerializeSetting
    {
        private const char _afc = '@';
        private string _sain = "#text";

        private Type _ignoreAttributeType = 
#if (NET || NETSTANDARD_2_0_UP)
            typeof(JsonIgnoreAttribute);
#else
            null;
#endif

        /// <summary>
        ///     获取或设置指示 <see cref="T:XPatchLib.Serializer" /> 方法
        ///     <see cref="M:XPatchLib.Serializer.Divide(XPatchLib.ITextWriter,System.Object,System.Object)" />
        ///     进行序列化的公共字段或公共读/写属性值。
        /// </summary>
        /// <remarks>
        ///     用于控制如何 <see cref="T:XPatchLib.Serializer" /> 方法
        ///     <see cref="M:XPatchLib.Serializer.Divide(XPatchLib.ITextWriter,System.Object,System.Object)" /> 序列化对象。
        /// </remarks>
        /// <seealso cref="P:Newtonsoft.Json.JsonIgnoreAttribute" />
        public override Type IgnoreAttributeType
        {
            get { return _ignoreAttributeType; }
            set
            {
                if (_ignoreAttributeType != value)
                {
                    _ignoreAttributeType = value;
                    OnPropertyChanged(nameof(IgnoreAttributeType));
                }
            }
        }

        /// <summary>
        ///     获取读写特性时开头的字符
        /// </summary>
        /// <value>默认值是 <c>@</c> 。</value>
        //AttributeFirsChar
        internal char AFC
        {
            get { return _afc; }
        }

        /// <summary>
        ///     获取或设置 Json 序列化/反序列化时，文本中标记 '<b>值</b>' 的文本。
        /// </summary>
        /// <value>
        ///     默认值是 <c>#text</c> 。
        /// </value>
        /// <exception cref="ArgumentNullException">当设置值是传入 <b>null</b> 时。</exception>
        /// <exception cref="ArgumentException">当设置值为空时。</exception>
        //SimpleArrayItemName
        public string SAIN
        {
            get { return _sain; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(SAIN));
                if (_sain != value)
                {
                    _sain = value;
                    OnPropertyChanged(nameof(SAIN));
                }
            }
        }

        /// <summary>创建作为当前实例副本的新对象。</summary>
        /// <returns>作为此实例副本的新对象。</returns>
        /// <filterpriority>2</filterpriority>
        public override object Clone()
        {
            JsonSerializeSetting result = new JsonSerializeSetting();
            result.MemberType = MemberType;
#if NET || NETSTANDARD_2_0_UP
            result.EnableOnDeserializedAttribute = EnableOnDeserializedAttribute;
            result.EnableOnSerializedAttribute = EnableOnSerializedAttribute;
            result.EnableOnDeserializingAttribute = EnableOnDeserializingAttribute;
            result.EnableOnSerializingAttribute = EnableOnSerializingAttribute;
#endif
            result.ActionName = ActionName;
            result.Mode = Mode;
            result.Modifier = Modifier;
            result.SerializeDefalutValue = SerializeDefalutValue;
#if NET_40_UP || NETSTANDARD_2_0_UP
            result.AssemblyQualifiedName = AssemblyQualifiedName;
#endif
            result.IgnoreAttributeType = IgnoreAttributeType;
            result.SAIN = SAIN;
            return result;
        }
    }
}