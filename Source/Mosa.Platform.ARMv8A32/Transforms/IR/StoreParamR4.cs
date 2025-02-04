// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// StoreParamR4
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class StoreParamR4 : BaseIRTransform
{
	public StoreParamR4() : base(IRInstruction.StoreParamR4, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		TransformStore(transform, context, ARMv8A32.Stf, transform.StackFrame, context.Operand1, context.Operand2);
	}
}
