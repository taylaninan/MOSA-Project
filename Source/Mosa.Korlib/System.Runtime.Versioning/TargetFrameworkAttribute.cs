// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace System.Runtime.Versioning;

[AttributeUsageAttribute(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
public sealed class TargetFrameworkAttribute : Attribute
{
	public string FrameworkName
	{
		get;
		private set;
	}

	public string FrameworkDisplayName
	{
		get;
		set;
	}

	public TargetFrameworkAttribute(string frameworkName)
	{
		FrameworkName = frameworkName;
	}
}
