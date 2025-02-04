// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// StoreParamR8
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class StoreParamR8 : BaseIRTransform
{
	public StoreParamR8() : base(IRInstruction.StoreParamR8, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		TransformStore(transform, context, ARMv8A32.Stf, transform.StackFrame, context.Operand1, context.Operand2);
	}
}
