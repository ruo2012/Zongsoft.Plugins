﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2013 Zongsoft Corporation <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.Plugins.
 *
 * Zongsoft.Plugins is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Zongsoft.Plugins is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Zongsoft.Plugins; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.Collections.Generic;

namespace Zongsoft.Plugins
{
	public class BuiltinType
	{
		#region 成员变量
		private Type _type;
		private Builtin _builtin;
		private string _typeName;
		private BuiltinTypeConstructor _constructor;
		#endregion

		#region 构造函数
		public BuiltinType(Builtin builtin, string typeName)
		{
			if(builtin == null)
				throw new ArgumentNullException("builtin");

			if(string.IsNullOrWhiteSpace(typeName))
				throw new ArgumentNullException("typeName");

			_type = null;
			_builtin = builtin;
			_typeName = typeName.Trim();
			_constructor = new BuiltinTypeConstructor(this);
		}
		#endregion

		#region 公共属性
		public Builtin Builtin
		{
			get
			{
				return _builtin;
			}
		}

		public Type Type
		{
			get
			{
				if(_type == null)
					_type = PluginUtility.GetType(this.TypeName);

				return _type;
			}
		}

		public string TypeName
		{
			get
			{
				return _typeName;
			}
			internal set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_typeName = value.Trim();
				_type = null;
			}
		}

		public BuiltinTypeConstructor Constructor
		{
			get
			{
				return _constructor;
			}
		}
		#endregion
	}
}