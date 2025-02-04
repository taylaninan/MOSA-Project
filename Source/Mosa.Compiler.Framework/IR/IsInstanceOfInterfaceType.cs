// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// IsInstanceOfInterfaceType
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class IsInstanceOfInterfaceType : BaseIRInstruction
{
	public IsInstanceOfInterfaceType()
		: base(2, 1)
	{
	}

	public override bool IsMemoryRead => true;
}
