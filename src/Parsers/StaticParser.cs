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
using System.Reflection;
using System.Collections.Generic;

namespace Zongsoft.Plugins.Parsers
{
	public class StaticParser : Parser
	{
		public override object Parse(ParserContext context)
		{
			if(string.IsNullOrWhiteSpace(context.Text) || string.Equals(context.Text, "null", StringComparison.OrdinalIgnoreCase))
				return null;

			var member = PluginUtility.GetStaticMember(context.Text);

			if(member != null)
			{
				switch(member.MemberType)
				{
					case (MemberTypes.Field):
						return ((FieldInfo)member).GetValue(null);
					case (MemberTypes.Property):
						return ((PropertyInfo)member).GetValue(null, null);
				}
			}

			return null;
		}
	}
}
