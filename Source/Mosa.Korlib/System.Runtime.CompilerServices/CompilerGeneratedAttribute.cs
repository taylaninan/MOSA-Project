﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace System.Runtime.CompilerServices;

/// <summary>
/// Distinguishes a compiler-generated element from a user-generated element. This class cannot be inherited.
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public sealed class CompilerGeneratedAttribute : Attribute
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CompilerGeneratedAttribute"/> class.
	/// </summary>
	public CompilerGeneratedAttribute()
	{
	}
}
