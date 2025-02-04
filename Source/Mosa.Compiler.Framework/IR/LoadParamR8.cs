// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// LoadParamR8
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class LoadParamR8 : BaseIRInstruction
{
	public LoadParamR8()
		: base(1, 1)
	{
	}

	public override bool IsMemoryRead => true;

	public override bool IsParameterLoad => true;
}
